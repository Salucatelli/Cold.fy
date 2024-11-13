using ma2_banco_de_dados.Authorization;
using ma2_banco_de_dados.Data;
using ma2_banco_de_dados.Models;
using ma2_banco_de_dados.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

//Loading .env
DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//builder.Services.AddControllers().AddJsonOptions(x =>
//   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

// Add services to the container.

//DataBase Settings--------------------------
var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

builder.Services.AddDbContext<UserDbContext>(opts =>
{
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


//Identity Settings--------------------------
builder.Services
    .Configure<IdentityOptions>(options => 
    {
        options.Password.RequireNonAlphanumeric = false;  //Password requirements
    })
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => 
{ 
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABABABABABABABABA203984u208ru20ru0")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options => //Adicionando politicas para autorização
{
    options.AddPolicy("IdadeMinima", policy =>   
    policy.AddRequirements(new IdadeMinima(18))); // verificação de idade minima
});

builder.Services.AddSingleton<IAuthorizationHandler ,IdadeAuthorization>(); //Injeção do authorization

//Other settings-----------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Mapper
builder.Services.AddScoped<UserService>(); // Injeção de dependencia do userService
builder.Services.AddScoped<TokenService>(); // Injeção de dependencia do tokenService
builder.Services.AddScoped<ArtistService>(); // Injeção de dependencia do artistService

//Fixing cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500", "http://127.0.0.1:5501")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy"); // Using cors policy

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
