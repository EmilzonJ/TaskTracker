namespace Web.ApiKey;

public class ApiKeyValidation(
    IConfiguration configuration
) : IApiKeyValidation
{

    public bool IsValidApiKey(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey)) return false;

        var apiKeyValue = configuration.GetValue<string>(Constants.ApiKey.ApiKeyName);
        if(string.IsNullOrWhiteSpace(apiKeyValue)) return false;

        return apiKey == apiKeyValue;
    }
}
