public class RabbitMQ
{
    private const string DeathHeader = "x-death";
    private const string DeathHeaderCount = "count";

    public long? GetRetryCount(IBasicProperties properties)
    {
        if (properties.Headers.ContainsKey(DeathHeader))
        {
            var deathProperties = (List<object>)properties.Headers[DeathHeader];
            var lastRetry = (Dictionary<string, object>)deathProperties[0];
            var count = lastRetry[DeathHeaderCount];
            return (long)count;
        }
        else
        {
            return null;
        }
    }
}