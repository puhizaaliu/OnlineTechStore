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

app.MapGet("/health", () => Results.Ok("Notification Service is running"));

app.MapGet("/api/notifications", () =>
{
    var notifications = new[]
    {
        new { Id = 1, Message = "Order created successfully.", Type = "OrderConfirmation" },
        new { Id = 2, Message = "Payment completed successfully.", Type = "PaymentConfirmation" }
    };

    return Results.Ok(notifications);
});

app.Run();