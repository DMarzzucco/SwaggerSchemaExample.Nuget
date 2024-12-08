namespace WebApplication1.Filter.Attributes
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Parameter |
        AttributeTargets.Property |
        AttributeTargets.Enum, AllowMultiple = false
        )]
    public class SwaggerSchemaExampleAttribute : Attribute
    {
        public SwaggerSchemaExampleAttribute(string example)
        {
            Example = example;
        }
        public string Example { get; set; }
    }
}
