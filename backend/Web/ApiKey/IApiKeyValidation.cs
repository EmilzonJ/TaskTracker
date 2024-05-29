namespace Web.ApiKey;

public interface IApiKeyValidation
{
    bool IsValidApiKey(string apiKey);
}
