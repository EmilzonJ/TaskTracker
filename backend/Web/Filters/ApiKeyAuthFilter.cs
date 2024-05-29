using Application.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Web.ApiKey;

namespace Web.Filters;

public class ApiKeyAuthFilter(
    IApiKeyValidation apiKeyValidation
) : IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var clientApiKey = context.HttpContext.Request.Headers[Constants.ApiKey.ApiKeyHeader];

        if (string.IsNullOrWhiteSpace(clientApiKey))
        {
            throw new BadRequestException("API Key is missing");
        }

        if (!apiKeyValidation.IsValidApiKey(clientApiKey!))
        {
            throw new UnauthorizedException("Invalid API Key");
        }
    }
}
