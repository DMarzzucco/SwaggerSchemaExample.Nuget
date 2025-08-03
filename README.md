# SwaggerSchemaExample

This library allows you to document models and DTOs with Swagger.

## These are the steps to follow.


### Swagger Settings
- Add `EnableAnnotations` and implement `SwaggerSchemaExampleFilter`in SchemaFilter.

```cs
builder.Services.AddSwaggerGen(
    options =>
    {
        options.EnableAnnotations();
        // options.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoSwaggerAnnotation", Version = "v1" });
         options.SchemaFilter<SwaggerSchemaExampleFilter>();
    });
```
### Finished

Now we can add the annotations to our models and DTOs

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

Dario Marzzucco