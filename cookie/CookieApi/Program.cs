using CookieApi.Bootstrap;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddHelperServices();
builder.Services.AddServices();
builder.Services.AddRepositories();

builder.Services.AddCookieAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerWithCookie();

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();