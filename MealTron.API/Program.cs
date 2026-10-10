using System.Text;
using MealTron.API.Interfaces;
using MealTron.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<MealTron.API.Data.AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenKey = builder.Configuration["TokenKey"] ?? throw new Exception("TokenKey is not configured.");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false, // for dev only
            ValidateAudience = false // for dev only
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(policy =>
    policy.AllowAnyHeader()
          .AllowAnyMethod()
          .WithOrigins("http://localhost:4200", "https://localhost:4200")
);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
