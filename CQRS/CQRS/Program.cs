using CQRS;
using CQRS.Mediator.Command;
using CQRS.Mediator.Command.Decorators;
using CQRS.Mediator.Query;
using CQRS.Mediator.Query.Decorators;
using CQRS.Routing;
using CQRS.SecurityHandlers;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHandlers(typeof(ICommandHandler<>));
builder.Services.AddHandlers(typeof(IQueryHandler<,>));
builder.Services.AddHandlers(typeof(ISecurityHandler<>));
builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>()
    .Decorate<ICommandDispatcher, CommandValidationDecorator>()
    .Decorate<ICommandDispatcher, CommandSecurityDecorator>()
    .Decorate<ICommandDispatcher, CommandLoggingDecorator>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>()
    .Decorate<IQueryDispatcher, QueryValidationDecorator>()
    .Decorate<IQueryDispatcher, QueryLoggingDecorator>();

builder.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomEndpoints();

app.Run();