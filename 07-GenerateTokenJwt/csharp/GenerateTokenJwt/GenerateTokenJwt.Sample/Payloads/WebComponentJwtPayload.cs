namespace GenerateTokenJwt.Sample.Payloads;

public class WebComponentJwtPayload
{
    public const string Audience = "https://app.4xdigital.ai/";

    public Guid SellerId { get; init; }
    public string Email { get; init; }
    public long Exp { get; init; } // Unix timestamp representing expiration

    public WebComponentJwtPayload(
        Guid sellerId,
        string email
    )
    {
        Guard.IsNotDefault(sellerId, nameof(sellerId));
        GuardExtensions.IsValidEmail(email, nameof(email));

        SellerId = sellerId;
        Email = email;
        Exp = DateTimeOffset.UtcNow.AddMinutes(15).ToUnixTimeSeconds();
    }

    public string GenerateSignedToken(string secretKey)
    {
        Guard.IsNotNullOrEmpty(secretKey, nameof(secretKey));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(type: Claims.SellerId, SellerId.ToString()),
            new Claim(type: Claims.Email, Email),
            new Claim(type: Claims.Exp, Exp.ToString()) // Optional: JWT handler will automatically add "exp" if you use `Expires`
        };

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTimeOffset.FromUnixTimeSeconds(Exp).UtcDateTime,
            SigningCredentials = credentials,
            Audience = Audience
            // Optionally add: Issuer
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(securityTokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}