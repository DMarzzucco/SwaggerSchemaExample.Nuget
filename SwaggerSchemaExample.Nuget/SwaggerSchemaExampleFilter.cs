using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Any;
using System.Reflection;
namespace SwaggerSchemaExample.Nuget
{
    /// <summary>
    /// Attributes
    /// </summary>
    /// <param name="example"></param>
    [AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Struct |
    AttributeTargets.Parameter |
    AttributeTargets.Parameter |
    AttributeTargets.Enum |
    AttributeTargets.Property, AllowMultiple = false)]
    public class SwaggerSchemaExampleAttribute(string example) : Attribute { public string Example { get; set; } = example; }

    /// <summary>
    /// Filter to inxect
    /// </summary>
    public class SwaggerSchemaExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.MemberInfo is null || schema is null) return;

            var schemaAttribute = context.MemberInfo.
                    GetCustomAttributes<SwaggerSchemaExampleAttribute>().FirstOrDefault();

            if (schemaAttribute is null) return;

            ApplySchemaAttribute(schema, schemaAttribute);
        }

        private static void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute schemaAttribute)
        {
            schema.Example = new OpenApiString(schemaAttribute.Example);
        }
    }
}
