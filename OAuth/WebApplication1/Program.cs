using WebApplication1.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GoogleExchangeCodeOnTokenEndpointHandler>();
builder.Services.AddScoped<GoogleUserAuthenticationEndpointHandler>();
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy => policy.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

var app = builder.Build();

app.MapGet("/auth/google-code-token", async (string code, GoogleExchangeCodeOnTokenEndpointHandler handler) =>
    await handler.Handle(code));

app.MapGet("/auth/google-token-auth", async (string token, GoogleUserAuthenticationEndpointHandler handler) =>
    await handler.Handle(token));

app.UseCors();

app.Run();