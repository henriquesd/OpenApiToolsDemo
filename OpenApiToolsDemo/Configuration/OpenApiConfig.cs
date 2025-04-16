using Scalar.AspNetCore;

namespace OpenApiToolsDemo.Configuration
{
    public static class OpenApiConfig
    {
        public static void AddOpenApiConfiguration(this IServiceCollection services, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                services.AddOpenApi();
            }
        }

        public static void UseOpenApiConfiguration(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                // Swagger
                app.UseSwaggerUI(options =>
                {
                    //options.RoutePrefix = string.Empty; // change relative path to the UI
                    options.SwaggerEndpoint("/openapi/v1.json", "Open API - Swagger");
                });

                // Scalar
                //app.MapScalarApiReference();
                app.MapScalarApiReference(options =>
                {
                    options
                    .WithTitle("Open API - Scalar")
                    .WithTheme(ScalarTheme.BluePlanet)
                    .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
                });

                // ReDoc
                app.UseReDoc(options =>
                {
                    //options.RoutePrefix = "docs"; // change relative path to the UI
                    options.DocumentTitle = "Open API - ReDoc";
                    options.SpecUrl("/openapi/v1.json");
                });
            }
        }
    }
}
