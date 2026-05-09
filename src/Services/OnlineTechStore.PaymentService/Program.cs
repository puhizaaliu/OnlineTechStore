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

app.MapGet("/health", () => Results.Ok("Payment Service is running"));

app.MapGet("/api/payments", () =>
{
    var payments = new[]
    {
        new { Id = 1, OrderId = 1, Amount = 1299.99, Status = "Pending" },
        new { Id = 2, OrderId = 2, Amount = 149.99, Status = "Paid" }
    };

    return Results.Ok(payments);
});

app.Run();