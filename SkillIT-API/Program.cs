using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SkillIT_API.Hubs;
using SkillIT_API.Middleware;
using SkillIT_Models.Data;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System.Text;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Load authentication key from configuration
AuthenticationHelper.AuthenticationKey = builder.Configuration["JwtSettings:SecretKey"] 
    ?? throw new InvalidOperationException("JWT Secret Key not configured");

// Add services to the container.
builder.Services.AddControllers();

// Add memory cache
builder.Services.AddMemoryCache();

// Add SignalR for real-time features
builder.Services.AddSignalR();

// Add health checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>("database");

// Add rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 100,
                QueueLimit = 0,
                Window = TimeSpan.FromMinutes(1)
            }));
    
    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;
        await context.HttpContext.Response.WriteAsync("Too many requests. Please try again later.", cancellationToken: token);
    };
});

// Configure database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    if (string.IsNullOrEmpty(connectionString) || connectionString == "CONFIGURE_IN_USER_SECRETS")
    {
        throw new InvalidOperationException("Database connection string not configured. Please set up user secrets.");
    }
    
    options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
            mySqlOptions.CommandTimeout(60);
            mySqlOptions.MigrationsAssembly("SkillIT-Models");
        });
});

// Register services with dependency injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();
builder.Services.AddScoped<IUserSocialService, UserSocialService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserAchievementService, UserAchievementService>();
builder.Services.AddScoped<IUserCertificateService, UserCertificateService>();
builder.Services.AddScoped<IOTPService, OTPService>();
builder.Services.AddScoped<IEngagementService, EngagementService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "SkillIT API", 
        Version = "v1",
        Description = "SkillIT Learning Management System API"
    });
    
    // Add JWT authentication to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Configure JWT authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationHelper.AuthenticationKey)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// Configure CORS with specific origins for production
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() 
    ?? new[] { "https://localhost:7000", "http://localhost:5000" };

builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy", build =>
    {
        build.WithOrigins(allowedOrigins)
             .AllowAnyMethod()
             .AllowAnyHeader()
             .AllowCredentials(); // Required for SignalR
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "SkillIT API v1");
    });
}

// Add global exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Add request/response logging middleware (only in development)
if (app.Environment.IsDevelopment())
{
    app.UseMiddleware<RequestResponseLoggingMiddleware>();
}

// Enable rate limiting
app.UseRateLimiter();

app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Map controllers and SignalR hubs
app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

// Map health checks
app.MapHealthChecks("/health");

app.Run();
