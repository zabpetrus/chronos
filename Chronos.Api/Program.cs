using AutoMapper;
using Chronos.Application.Tokens;
using Chronos.Domain.Entities;
using Chronos.Infraestructure.Context;
using Chronos_CrossCutting.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
DependencyInjectionService.RegisterDependencies(builder.Configuration, builder.Services);


var key = Encoding.ASCII.GetBytes(Key.Secret);

// Configuração para usuários internos
builder.Services.AddAuthentication("JwtInterno")
    .AddJwtBearer("JwtInterno", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
});

// Configuração para usuários externos
builder.Services.AddAuthentication("JwtExterno")
    .AddJwtBearer("JwtExterno", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
});


builder.Services.AddAuthorization(options =>
{
    // Política para usuários internos
    options.AddPolicy("Interno", policy =>
        policy.RequireAuthenticatedUser().AddAuthenticationSchemes("JwtInterno"));

    // Política para usuários externos
    options.AddPolicy("Externo", policy =>
        policy.RequireAuthenticatedUser().AddAuthenticationSchemes("JwtExterno"));
});



builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    // Definição para JWT interno
    c.AddSecurityDefinition("BearerInterno", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "JWT Interno"
    });

    // Definição para JWT externo
    c.AddSecurityDefinition("BearerExterno", new OpenApiSecurityScheme
    {

        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "JWT Externo"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BearerInterno"
                }
            },
            new List<string>()
        },
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "BearerExterno"
                }
            },
            new List<string>()
        }
    });
});





var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
