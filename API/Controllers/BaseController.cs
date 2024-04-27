using System.Security.Claims;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
/// <summary>
/// Base controller for all controllers
/// </summary>
public class BaseController: Controller
{
    /// <summary>
    /// User ID 
    /// </summary>
    public long? UserID {
        get {
            return Convert.ToInt64(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }

    /// <summary>
    /// Get source IP address
    /// </summary>
    /// <returns></returns>

    public string GetSourceIpAddress()
    {
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "-";
    }

    /// <summary>
    /// Get language from header
    /// </summary>
    /// <returns></returns>

    public string? GetLanguageFromHeader()
    {
        if (Request.Headers.TryGetValue("Accept-Language", out var languageValues))
        {
            var languages = languageValues.ToString();

            var preferredLanguage = languages.Split(',').FirstOrDefault()?.Split(';').FirstOrDefault();




            return preferredLanguage; 
                }
        return null;
    }
}

