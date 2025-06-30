namespace GenerateTokenJwt.Sample;

public static class Messages
{
    public static string NotParsed<T>() => $"{typeof(T)}NotParsed";
    public static string NotFound(string field) => $"{field}NotFound";
}