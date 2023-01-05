using ControlePonto.DAL.Context;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Text;
using ControlePonto.API.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ControlePonto.Utils.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ControlePontoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ControlePonto")), ServiceLifetime.Scoped);

InjectionDependencyCore.ConfigureServices(builder.Services);

IMapper mapperConfig = MapperConfig.RegisterMappers();
builder.Services.AddSingleton(mapperConfig);

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(TipoUsuarioEnum.Colaborador.ToString(), policy => policy.RequireClaim("ControlePonto", TipoUsuarioEnum.Colaborador.ToString()));
    options.AddPolicy(TipoUsuarioEnum.Administrador.ToString(), policy => policy.RequireClaim("ControlePonto", TipoUsuarioEnum.Administrador.ToString()));
});

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:AuthenticationKey").Value);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
