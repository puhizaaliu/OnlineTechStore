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

app.MapGet("/health", () => Results.Ok("Order Service is running"));

app.MapGet("/api/orders", () =>
{
    var orders = new[]
    {
        new { Id = 1, CustomerName = "Test Customer", Status = "Pending", TotalAmount = 1299.99 },
        new { Id = 2, CustomerName = "Demo Customer", Status = "Completed", TotalAmount = 149.99 }
    };

    return Results.Ok(orders);
});

app.Run();