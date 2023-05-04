namespace WebApi;

public class EmailConfig : IConfig
{
    public required string ApiKey { get; init; }
    public required string Provider { get; init; }
}

public interface IConfig
{
}
