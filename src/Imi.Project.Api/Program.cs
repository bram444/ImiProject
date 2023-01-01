using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Sevices;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Dto.User;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwtOptions =>
{
    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"],
        ValidAudience = builder.Configuration["JWTConfiguration:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigninKey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("onlyAdults", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var adultClaimValue = context.User.Claims
                         .SingleOrDefault(c => c.Type == ClaimTypes.DateOfBirth)?.Value;
            if(DateTime.TryParseExact(adultClaimValue, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                                      DateTimeStyles.AdjustToUniversal, out var birthDay))
            {
                return birthDay.AddYears(18) < DateTime.UtcNow;
            }
            return false;
        });
    });
    options.AddPolicy("approved", policy =>
    {
        policy.RequireAssertion(context => Convert.ToBoolean(context.User.Claims.SingleOrDefault(claim => claim.Type == "approved")?.Value));
    });

    options.AddPolicy("onlyOwner", policy =>
    {
        policy.RequireAssertion(async context =>
        {
            if(context.User.IsInRole("Admin"))
            {
                return true;
            }

            var request = new HttpContextAccessor().HttpContext.Request;
            request.EnableBuffering();

            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var idRoute = request.RouteValues["id"];

            if(idRoute != null)
            {
                if(idRoute.Equals(userId))
                {
                    return true;
                }
            }

            string jsonString;
            var body = request.Body;

            using(var stream = new StreamReader(body, Encoding.UTF8, true, 1024, true))
            {
                jsonString = await stream.ReadToEndAsync();
            }

            request.Body.Position = 0;

            if(jsonString != null)
            {
                UserResponseDto user = JsonConvert.DeserializeObject<UserResponseDto>(jsonString);

                if(user != null)
                {
                    if(user.Id.ToString() == userId)
                    {
                        return true;
                    }
                }
            }

            return false;
        });
    });

    options.AddPolicy("adminOnly", policy =>
    {
        policy.RequireRole("Admin");
    });
});

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IGameGenreService, GameGenreService>();
builder.Services.AddScoped<IUserGameService, UserGameService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IGenreService, GenreService>();

builder.Services.AddScoped<IGameGenreRepository, GameGenreRepository>();
builder.Services.AddScoped<IUserGameRepository, UserGameRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "IMI.Project", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();