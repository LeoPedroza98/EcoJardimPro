using AutoMapper;
using EcoJardimProject.Data.Context;
using EcoJardimProject.Data.Mapper;
using EcoJardimProject.Domain.Entities;
using EcoJardimProject.Domain.IdentityBase;
using EcoJardimProject.Utils.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Text;
using EcoJardimProject.API.Extensions;
using EcoJardimProject.API.Identity;

var builder = WebApplication.CreateBuilder(args);


//var connection = builder.Configuration["ConnectionStrings:DefaultConnection"];

//builder.Services.AddDbContext<EcoJardimProjectContext>(options =>
//    options.UseSqlServer(connection)
//);

builder.Services.AddDbContext<EcoJardimProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "EcoJardimPro",
        Version = "v1"
    }
    );
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Header de autoriza��o JWT usando o esquema Bearer. Digite 'Bearer' seguido do JWT para autorizar.",
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
            },new String[]{}
        }
    });
});

builder.Services.AddControllers(mvc => mvc.EnableEndpointRouting = false)
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    options.UseCamelCasing(true);
});

builder.Services.AddCors(o => o.AddPolicy("CorsLibera", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddInjections();


builder.Configuration.AddEnvironmentVariables(prefix: "ConnectionStrings:DefaultConnection");

builder.Services.AddIdentity<Usuario, Role>()
    .AddEntityFrameworkStores<EcoJardimProjectContext>()
    .AddDefaultTokenProviders()
    .AddErrorDescriber<IdentityDescricaoDeErroEmPtBr>();


builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudience = builder.Configuration["TokenConfigurations:Audience"],
            ValidIssuer = builder.Configuration["TokenConfigurations:Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"] ?? string.Empty))
        }
);

var app = builder.Build();

UpdateDatabase(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./swagger/v1/swagger.json", "EcoJardimProject");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CorsLibera");
app.UseMiddleware(typeof(ErrorHandlingMiddleware));
app.UseMiddleware<TokenValidationMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<EcoJardimProjectContext>())
        {
            context.Database.Migrate();
            new IdentityInitializer(serviceScope.ServiceProvider.GetService<EcoJardimProjectContext>(), serviceScope.ServiceProvider.GetService<UserManager<Usuario>>()).Initialize().Wait();
        }
    }
}