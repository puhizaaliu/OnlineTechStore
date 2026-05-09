var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/health", () => Results.Ok("Product Service is running"));

app.MapGet("/api/products", () =>
{
    var products = new[]
    {
        new { Id = 1, Name = "Gaming Laptop", Category = "Laptops", Price = 1299.99 },
        new { Id = 2, Name = "Smartphone", Category = "Phones", Price = 899.99 },
        new { Id = 3, Name = "Wireless Headphones", Category = "Audio", Price = 149.99 }
    };

    return Results.Ok(products);
});

app.Run();