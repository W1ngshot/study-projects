using Microsoft.EntityFrameworkCore;
using OrderService;
using OrderService.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDbContext>(options =>
        options.UseNpgsql("Host=localhost;Port=5450;Database=order;Username=postgres;Password=password"));
builder.Services.AddSingleton<IPublisher, Publisher>();
builder.Services.AddHostedService<OutboxPublisher>();

var app = builder.Build();
await app.TryMigrateDatabaseAsync();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/order", async (OrderDto orderDto, OrderDbContext context) =>
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Name = orderDto.Name,
            CustomerId = orderDto.CustomerId,
            Price = orderDto.Price,
            Weight = orderDto.Weight
        };

        var orderOutbox = new OutboxOrder
        {
            Id = Guid.NewGuid(),
            IdempotencyKey = Guid.NewGuid(),
            Name = order.Name,
            UserId = orderDto.CustomerId,
            AddDate = DateTime.UtcNow
        };

        await using var transaction = context.Database.BeginTransaction();
        context.Orders.Add(order);
        await context.SaveChangesAsync();

        context.OutboxOrders.Add(orderOutbox);
        await context.SaveChangesAsync();

        await transaction.CommitAsync();

        return order.Id;
    })
    .WithName("Create Order")
    .WithOpenApi();

app.MapGet("/order/{id:guid}",
    async (Guid id, OrderDbContext context) => { return await context.Orders.FirstOrDefaultAsync(x => x.Id == id); });

app.MapGet("/orders", async (OrderDbContext context) => await context.Orders.ToListAsync());

app.Run();