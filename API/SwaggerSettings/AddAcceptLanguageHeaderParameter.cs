using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Any;

namespace API.SwaggerSettings;
/// <summary>
/// swagger class to 
/// request custom header 
/// on sending Request form swagger 
/// </summary>
public class AddAcceptLanguageHeaderParameter : IOperationFilter
{
    /// <summary>
    /// method that DoTHE fill and 
    /// send the laguage Header 
    /// </summary>
    /// <param name="operation"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        
        if (operation.Parameters == null)
        {
            operation.Parameters = new List<OpenApiParameter>();
        }

       
        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "Accept-Language",
            In = ParameterLocation.Header,
            Description = "Language preference",
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Default = new OpenApiString("en-US"), 
            }
        });
    }
}