using TimetableApi;
using TimetableApi.Handlers;
using TimetableApi.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TimetableStoreDatabaseSettings>(
    builder.Configuration.GetRequiredSection("TimetableStoreDatabase"));

//Handlers
builder.Services.AddScoped<CreateTimetableHandler>();

builder.Services.AddSingleton<TimetableService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var timetable = app.MapGroup("/timetable")
    .WithName("TimetableApi")
    .WithOpenApi();

app.UseCustomEndpoints();
app.Run();