using GraphQL_Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddInMemorySubscriptions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddSorting();

var app = builder.Build();
app.UseWebSockets();
app.MapGraphQL((PathString) "/api");
app.Run();