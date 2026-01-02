using Blazored.LocalStorage;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillIT_Models.Data;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using SkillIT_Models.Constants;
using SkillIT_UI.Authentication;
using SkillIT_UI.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load authentication key from configuration
AuthenticationHelper.AuthenticationKey = builder.Configuration["JwtSettings:SecretKey"] 
    ?? throw new InvalidOperationException("JWT Secret Key not configured");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers();

// Configure database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Default");
    if (string.IsNullOrEmpty(connectionString) || connectionString == "CONFIGURE_IN_USER_SECRETS")
    {
        throw new InvalidOperationException("Database connection string not configured. Please set up user secrets.");
    }
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAuthenticationCore();

// Register services with dependency injection
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();
builder.Services.AddScoped<IUserSocialService, UserSocialService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserAchievementService, UserAchievementService>();
builder.Services.AddScoped<IUserCertificateService, UserCertificateService>();
builder.Services.AddScoped<IOTPService, OTPService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<IEngagementService, EngagementService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IEntityService, EntityService>();
builder.Services.AddScoped<IMailingService, MailingService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddEndpointsApiExplorer();

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

// Configure authorization policies using constants
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AppConstants.Roles.Admin, policy =>
    {
        policy.RequireClaim("Role", AppConstants.Roles.Admin);
    });
    options.AddPolicy(AppConstants.Roles.User, policy =>
    {
        policy.RequireClaim("Role", AppConstants.Roles.User);
    });
    options.AddPolicy(AppConstants.Roles.Creator, policy =>
    {
        policy.RequireClaim("Role", AppConstants.Roles.Creator);
    });
    options.AddPolicy(AppConstants.Roles.Author, policy =>
    {
        policy.RequireClaim("Role", AppConstants.Roles.Author);
    });
});

// Configure CORS
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	//app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
	//app.UseSwagger();
	//app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
