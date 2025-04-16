using OpenApiToolsDemo.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApiConfiguration(builder.Environment);

var app = builder.Build();

app.UseOpenApiConfiguration();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
