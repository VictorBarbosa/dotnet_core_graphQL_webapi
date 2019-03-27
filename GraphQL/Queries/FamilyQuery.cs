using dotnet_core_graphql.GraphQL.Types;
using dotnet_core_graphql.Models;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL;

namespace dotnet_core_graphql.GraphQL.Queries
{
  public class FamilyQuery : ObjectGraphType<Object>
  {
    private readonly FamilyModel _dbSample;

    public FamilyQuery(FamilyModel dbSample)
    {
      _dbSample = dbSample;

      Name = "Query";
      /**
       *
       */
      Field<ListGraphType<FamilyType>>("AllFamilies", resolve: context => GetAllFamilies());

     
      /**
       *
       */
      var argument = new QueryArguments(
       new QueryArgument<IntGraphType> { Name = "Id" }
       , new QueryArgument<StringGraphType> { Name = "Name" }
      );


      Field<FamilyType>("Family", arguments: argument, resolve: context => GetFamily(context));


      /**
       *
       */

      var memberArg = new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "MemberName" });
      Field<FamilyType>("SearchByMember", arguments: memberArg, resolve: context => GetByMembers(context));
    }

    private FamilyModel GetByMembers(ResolveFieldContext<object> arg)
    {
      var name = arg.GetArgument<string>("memberName");

      var retorno = _dbSample.DBSample().Where(x => x.Members.Any(c => c.Name.ToLower() == name.ToLower())).FirstOrDefault();
      return retorno;
    }


    private FamilyModel GetFamily(ResolveFieldContext<object> arg)
    {

      var id = arg.GetArgument<int?>("id");
      var name = arg.GetArgument<string>("name");

      return _dbSample.DBSample().FirstOrDefault(x => x.Name == name || x.Id == id);
    }

    private List<FamilyModel> GetAllFamilies()
    {
      return _dbSample.DBSample().ToList();
    }


   

  }
}
