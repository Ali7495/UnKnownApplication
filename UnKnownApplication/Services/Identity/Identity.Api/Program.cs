using Identity.Infra.Context;
using Identity.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UnKnownDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnectionString")));


//Add Jwt Authentication Token

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        // To validate token in server side
        ValidateIssuer = true,

        // To Validate token in client side
        ValidateAudience = true,

        // Expire date for Token
        ValidateLifetime = true,

        // Validate Token
        ValidateIssuerSigningKey = true,

        // Determine valid server

        //ValidIssuers = []
        ValidIssuer = "http://localhost",

        // Key for signing
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VerifiableToken"))
    };
});

// To enable for other applications
builder.Services.AddCors(options =>
{
    options.AddPolicy("IdentityServiceCors", builder =>
     {
         // To give access to other application to this api (with authentication)
         // To set in http header
         // To check in every method
         // To check if they have credentials
         // Build
         builder.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials()
                 .Build();
     });
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.User.RequireUniqueEmail = true;
})
                .AddEntityFrameworkStores<UnKnownDbContext>();

DependencyContainer.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("IdentityServiceCors");
app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.Run();
