using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PostIT_API.EF;
using PostIT_API.Helpers;
using PostIT_API.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);
var key = Encoding.ASCII.GetBytes(jwtSettings.Get<JwtSettings>().Secret);


// Add services to the container.
builder.Services.AddDbContext<PostITContext>();

//builder.Services.AddSingleton<IOCREngine>(new TessOCR());
builder.Services.AddSingleton<IOCREngine>(new GoogleOCR());


//Add JWT Bearer authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings.Get<JwtSettings>().Issuer,
        ValidateAudience = true,
        ValidAudience = jwtSettings.Get<JwtSettings>().Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = JwtBearerDefaults.AuthenticationScheme
        }
    };
    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement
                    {
                        { securitySchema, new[] { JwtBearerDefaults.AuthenticationScheme } }
                    };
    x.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
