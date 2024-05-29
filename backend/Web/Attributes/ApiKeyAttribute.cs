using Microsoft.AspNetCore.Mvc;
using Web.Filters;

namespace Web.Attributes;

public class ApiKeyAttribute() : ServiceFilterAttribute(typeof(ApiKeyAuthFilter));
