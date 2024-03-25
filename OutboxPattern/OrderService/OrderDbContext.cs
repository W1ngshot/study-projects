using Microsoft.EntityFrameworkCore;
using OrderService.Models;

namespace OrderService;

public class OrderDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; } = null!;

    public DbSet<OutboxOrder> OutboxOrders { get; set; } = null!;
}