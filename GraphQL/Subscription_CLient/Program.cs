using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Subscription_CLient;

var graphClient = new GraphQLHttpClient("https://localhost:44347/api", new NewtonsoftJsonSerializer());
var sub = new GraphQLRequest()
{
	Query = $@"
	subscription {{
		onItemAdded {{
			name
		}}
	}}"
};

var stream = graphClient.CreateSubscriptionStream<ItemResult>(sub);

stream.Subscribe(response => {Console.WriteLine(response.Data.OnItemAdded.Name);});

Console.ReadKey();