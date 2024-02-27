using Minio;
using Minio.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var endpoint = "localhost:9000";
var accessKey = "qk1r9OhHRLF0ejdiwayn";
var secretKey = "tX1UWnXJM3kqNF6j0FsO81LqiigmnHiefJHpKHVQ";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMinio(options =>
{
    options.Endpoint = endpoint;
    options.SecretKey = secretKey;
    options.AccessKey = accessKey;
    options.ConfigureClient(client =>
    {
        client.WithSSL(false);
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.WithOrigins("http://localhost:3000")
            .WithMethods("POST", "GET", "PUT", "DELETE")
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();