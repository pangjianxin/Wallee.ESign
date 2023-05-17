namespace Wallee.ESign;

public static class ESignDbProperties
{
    public static string DbTablePrefix { get; set; } = "ESign";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "ESign";
}
