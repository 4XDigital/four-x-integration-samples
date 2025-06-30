namespace GenerateTokenJwt.Sample.Extensions;

public static partial class GuardExtensions
{
    private static readonly Regex EmailRegex = EmailValidationRegex();

    public static string IsValidEmail(string text, string paramName)
    {
        Guard.IsNotNullOrWhiteSpace(text, paramName);

        if (!EmailRegex.IsMatch(text))
            throw new ArgumentException($"Parameter '{paramName}' is not a valid email address.", paramName);

        return text;
    }

    [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex EmailValidationRegex();
}