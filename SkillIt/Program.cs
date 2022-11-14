using BusinessLogic;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using SkillItModels.DatabaseModels;
using SkillItModels.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SkillItModels.DatabaseModels.skillit_dbContext>(options =>
{
	options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IAccountDetailService, AccountDetailService>();
builder.Services.AddScoped<IUserSkillService, UserSkillService>();
builder.Services.AddScoped<IUserSocialService, UserSocialService>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddScoped<IAuthenticationManager, AuthenticationManager>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Authentication.AuthenticationKey)),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});


builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
	build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
