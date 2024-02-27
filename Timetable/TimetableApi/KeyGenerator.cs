namespace TimetableApi;

public static class KeyGenerator
{
    private const string Base58Alphabet = "123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";

    private const int ReadKeyLength = 11;
    private const int WriteKeyLength = 22;

    public static string GenerateReadKey() => GenerateBase58String(ReadKeyLength);

    public static string GenerateWriteKey() => GenerateBase58String(WriteKeyLength);

    private static string GenerateBase58String(int length)
    {
        var random = new Random();
        var randomString = new string(Enumerable.Repeat(Base58Alphabet, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        
        return randomString;
    }
}