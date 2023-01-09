using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using SkillIT_Models.DatabaseModels;
using SkillIT_Models.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<skill_it_dbContext>(options =>
{
    //options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
    options.UseMySQL(builder.Configuration.GetConnectionString("SmarterAspDb"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IAccountDetailService, AccountDetailService>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();
builder.Services.AddScoped<IUserSocialService, UserSocialService>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddScoped<IUserAchievementService, UserAchievementService>();
builder.Services.AddScoped<IUserCertificateService, UserCertificateService>();
builder.Services.AddScoped<IOTPService, OTPService>();
builder.Services.AddScoped<IEngagementService, EngagementService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IAuthenticationManager>(new AuthenticationManager(Authentication.AuthenticationKey));


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationHelpers.AuthenticationKey)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

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
