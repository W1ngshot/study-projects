using Jwt;
using Jwt.Db;
using Jwt.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<UserContext>(options => options
    .UseNpgsql("Host=db;Port=5432;Database=jwt;Username=postgres;Password=123456"));

builder.Services.AddControllers();
builder.Services.AddJwtAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddAuthorization();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy  =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
            policy.WithOrigins("http://localhost:3000");
        });
});
builder.Services.AddScoped<IJwt, Jwts>();   

var app = builder.Build();

try
{
    await using var scope = app.Services.CreateAsyncScope();
    var sp = scope.ServiceProvider;
    var db = sp.GetRequiredService<UserContext>();
    
    await db.Database.MigrateAsync();

    await using var conn = (NpgsqlConnection)db.Database.GetDbConnection();
    await conn.OpenAsync();
    await conn.ReloadTypesAsync();
}
catch (Exception e)
{
    app.Logger.LogError(e, "Error while migrating the database");
    Environment.Exit(-1);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();