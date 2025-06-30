namespace GenerateTokenJwt.Sample.Extensions;

public static class JwtExtensions
{
    public static Result Validate(string token, string secretKey)
    {
        Guard.IsNotNullOrWhiteSpace(token, nameof(token));
        Guard.IsNotNullOrWhiteSpace(secretKey, nameof(secretKey));

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(secretKey);

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidAudience = WebComponentJwtPayload.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };

        try
        {
            jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

            if (validatedToken is not JwtSecurityToken jwtSecurityToken)
                return Result.Failure(Messages.NotParsed<JwtSecurityToken>());

            if (!jwtSecurityToken.TryGetClaimType(claimType: Claims.SellerId, value: out var sellerId))
                return Result.Failure(Messages.NotFound(nameof(Claims.SellerId)));

            if (!jwtSecurityToken.TryGetClaimType(claimType: Claims.Email, value: out var email))
                return Result.Failure(Messages.NotFound(nameof(Claims.Email)));

            if (!jwtSecurityToken.TryGetClaimType(claimType: Claims.Exp, out var exp))
                return Result.Failure(Messages.NotFound(nameof(Claims.Exp)));

            Console.WriteLine($"SellerId: {sellerId}");
            Console.WriteLine($"Email: {email}");
            Console.WriteLine($"Exp: {exp}");
            Console.WriteLine($"Audience: {jwtSecurityToken.Audiences.First()}");

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    private static bool TryGetClaimType(
        this JwtSecurityToken token,
        string claimType,
        out string? value
    )
    {
        value = token.Claims.FirstOrDefault(c => c.Type == claimType)?.Value;

        return !string.IsNullOrWhiteSpace(value);
    }
}