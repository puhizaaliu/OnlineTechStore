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

app.MapGet("/health", () => Results.Ok("Inventory Service is running"));

app.MapGet("/api/inventory", () =>
{
    var inventory = new[]
    {
        new { ProductId = 1, ProductName = "Gaming Laptop", StockQuantity = 15 },
        new { ProductId = 2, ProductName = "Smartphone", StockQuantity = 30 },
        new { ProductId = 3, ProductName = "Wireless Headphones", StockQuantity = 50 }
    };

    return Results.Ok(inventory);
});

app.Run();