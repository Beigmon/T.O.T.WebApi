using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TOT.DTO;
using TOT.Services.Caching;
using TOT.Services.Caching.Interfaces;
using TOT.Services.ControllerServices;
using TOT.Services.ControllerServices.Interfaces;

var builder = WebApplication.CreateBuilder(args);

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddStackExchangeRedisCache(options =>
{
    var connection = builder.Configuration.GetConnectionString("Redis");
    options.Configuration = connection;
});

// Register services
builder.Services.AddDbContext<TotContext>(options => options.UseNpgsql(builder.Configuration["CONNECTION_STRING"]));
builder.Services.AddTransient<ICachingService, CachingService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();
builder.Services.AddTransient<IStationService, StationService>();

// Security
builder.Services.AddRateLimiter(option =>
    option.AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 100;
        options.Window = TimeSpan.FromMinutes(1);
    }));

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = true;
        x.SaveToken = true;
        var key = Encoding.UTF8.GetBytes("SECRET SECRET SECRET SECRET SECRET SECRET");
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidIssuer = "test.com",
            ValidAudience = "test.com",
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
