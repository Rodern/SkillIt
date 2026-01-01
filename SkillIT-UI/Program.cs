using Blazored.LocalStorage;
using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkillIT_Models.DatabaseModels;
using SkillIT_UI.Authentication;
using SkillIT_UI.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options =>
{
	options.RootComponents.RegisterForJavaScript<NotificationPanel>("fl-notification-panel");
});

builder.Services.AddBlazoredLocalStorage();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<skill_it_dbContext>(options =>
{
	options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
	//options.UseMySQL(builder.Configuration.GetConnectionString("NeilsAspDb"));
	//options.UseMySQL(builder.Configuration.GetConnectionString("SkillAspDb"));
});

builder.Services.AddAuthenticationCore();

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
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthenticationHelper.AuthenticationKey)),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("admin", policy =>
	{
		policy.RequireClaim("Role", "admin");
	});
	options.AddPolicy("user", policy =>
	{
		policy.RequireClaim("Role", "user");
	});
	options.AddPolicy("creator", policy =>
	{
		policy.RequireClaim("Role", "creator");
	});
	options.AddPolicy("author", policy =>
	{
		policy.RequireClaim("Role", "author");
	});
});


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
