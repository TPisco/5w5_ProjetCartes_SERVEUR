namespace WebApi.Configuration;

public class JwtSettings
{
    public string Secret { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}

public static class AppConfiguration
{
    public static string ResolveConnectionString(IConfiguration configuration)
    {
        return configuration.GetConnectionString("DefaultConnection")
            ?? Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING")
            ?? throw new InvalidOperationException(
                "Database connection not configured. Set ConnectionStrings:DefaultConnection or DATABASE_CONNECTION_STRING.");
    }

    public static JwtSettings ResolveJwtSettings(IConfiguration configuration, IWebHostEnvironment environment)
    {
        var settings = configuration.GetSection("Jwt").Get<JwtSettings>() ?? new JwtSettings();

        settings.Secret = FirstNonEmpty(
            settings.Secret,
            Environment.GetEnvironmentVariable("JWT_SECRET"));

        settings.Issuer = FirstNonEmpty(
            settings.Issuer,
            Environment.GetEnvironmentVariable("JWT_ISSUER"),
            environment.IsDevelopment() ? "https://localhost:7179" : null);

        settings.Audience = FirstNonEmpty(
            settings.Audience,
            Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            environment.IsDevelopment() ? "http://localhost:4200" : null);

        if (string.IsNullOrWhiteSpace(settings.Secret))
        {
            throw new InvalidOperationException("JWT secret not configured. Set Jwt:Secret or JWT_SECRET.");
        }

        if (string.IsNullOrWhiteSpace(settings.Issuer) || string.IsNullOrWhiteSpace(settings.Audience))
        {
            throw new InvalidOperationException("JWT issuer/audience not configured. Set Jwt:Issuer/Jwt:Audience or JWT_ISSUER/JWT_AUDIENCE.");
        }

        return settings;
    }

    public static string[] ResolveCorsOrigins(IConfiguration configuration, IWebHostEnvironment environment)
    {
        var configuredOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
        if (configuredOrigins is { Length: > 0 })
        {
            return configuredOrigins;
        }

        var envOrigins = Environment.GetEnvironmentVariable("CORS_ORIGINS");
        if (!string.IsNullOrWhiteSpace(envOrigins))
        {
            return envOrigins.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        }

        if (environment.IsDevelopment())
        {
            return ["http://localhost:4200", "https://localhost:4200"];
        }

        throw new InvalidOperationException("CORS origins not configured. Set Cors:AllowedOrigins or CORS_ORIGINS.");
    }

    private static string FirstNonEmpty(params string?[] values)
    {
        foreach (var value in values)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
        }

        return string.Empty;
    }
}
