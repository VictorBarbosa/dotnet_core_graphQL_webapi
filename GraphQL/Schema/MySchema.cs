using dotnet_core_graphql.GraphQL.Queries;
using GraphQL;
namespace dotnet_core_graphql.GraphQL.Schema
{
  public class MySchema:  global::GraphQL.Types.Schema
  {
    public MySchema(IDependencyResolver resolver) : base(resolver)
    {
      Query = resolver.Resolve<FamilyQuery>();
      //Mutation = resolver.Resolve<>();
    }
  }
}
