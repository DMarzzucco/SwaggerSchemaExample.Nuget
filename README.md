# Swagger Documentation Annotation ASP.NET

This alternative allows you to add examples to your models and DTOs through annotations, in a simple way and without the need to generate XML files.

## These are the steps to follow.

- Install swagger annotations

```shell
dotnet add package Swashbuckle.AspNetCore.Annotations
```

- Enable Annotations in Swagger Settings

```cs
builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoSwaggerAnnotation", Version = "v1" });
    });
```
- In a dedicated module, configure the attributes, which will allow you to add examples, models and DTOs.

```cs
  [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Parameter |
        AttributeTargets.Property |
        AttributeTargets.Enum,
        AllowMultiple = false)]
    public class SwaggerSchemaExampleAttribute : Attribute
    {
        public SwaggerSchemaExampleAttribute(string example)
        {
            Example = example;
        }

        public string Example { get; set; }
    }
```

- Made a filter that allows us to integrate these examples into the Swagger UI
```cs
public class SwaggerSchemaExampleFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if(context.MemberInfo != null)
            {
                var schemaAttribute = context.MemberInfo.GetCustomAttributes<SwaggerSchemaExampleAttribute>()
               .FirstOrDefault();
                if (schemaAttribute != null) ApplySchemaAttribute(schema, schemaAttribute);
            }
        }

        private void ApplySchemaAttribute(OpenApiSchema schema, SwaggerSchemaExampleAttribute schemaAttribute)
        {
            if (schemaAttribute.Example != null)
            {
                schema.Example = new Microsoft.OpenApi.Any.OpenApiString(schemaAttribute.Example);
            }
        }
    }
```

- Finally we must add the filter to the Swagger configurations
```cs

builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SchemaFilter<SwaggerSchemaExampleFilter>();
    });
```

- Now we can add the annotations to our models and DTOs

```cs
 public class WeatherForecast
    {

        [SwaggerSchema(Description = "Date and time for weather")]
        [SwaggerSchemaExample("2021-10-30T10:42:53.531Z")]
        public DateOnly Date { get; set; }

        [SwaggerSchema(Description = "Temperature in celcius")]
        [SwaggerSchemaExample("40")]
        public int TemperatureC { get; set; }

        [SwaggerSchema(Description = "Temperature in fahrenheit")]
        [SwaggerSchemaExample("103")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [SwaggerSchema(Description = "Summary weather forecast ")]
        [SwaggerSchemaExample("Sweltering")]
        public string? Summary { get; set; }
    }
```

## Original Source
[link](https://medium.com/@niteshsinghal85/enhance-swagger-documentation-with-annotations-in-asp-net-core-d2981803e299)

## Author 
@niteshsinghal85 Nitesh Singhal
