using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Memo4me.UI.Extensions;

public static class AddAuthOpenIdExtension
{
    public static void AddAuthOpenId(this IServiceCollection services,  ConfigurationManager configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = configuration["Authentication:OpenIdConnect:Authority"];
                options.ClientId = configuration["Authentication:OpenIdConnect:ClientId"];
                options.ClientSecret = configuration["Authentication:OpenIdConnect:ClientSecret"];
                options.ResponseType = configuration["Authentication:OpenIdConnect:ResponseType"];
                options.RequireHttpsMetadata = configuration.GetValue<bool>("Authentication:OpenIdConnect:RequireHttpsMetadata");
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                };
            });
    }
}