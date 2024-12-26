using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

var authenticationProviderKey = "IdentityApiKey";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.Authority = "https://localhost:5005";

        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };

    });

builder.Services.AddOcelot();

var app = builder.Build();

app.MapControllers();

await app.UseOcelot();

app.Run();
