using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_graphql.Models;
using GraphQL.Types;

namespace dotnet_core_graphql.GraphQL.Types
{
  public class FamilyType : ObjectGraphType<FamilyModel>
  {
    public FamilyType(FamilyModel dbSample)
    {
      Name = "Family";

      Field(x => x.Id).Name("Id");
      Field(x => x.Name).Name("Name");
      Field(x => x.Photo).Name("Photo");
      Field<ListGraphType<MemberFamilyType>>().Name("Members");
    }

    
  }
}
