using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_graphql.Models;
using GraphQL.Types;

namespace dotnet_core_graphql.GraphQL.Types
{
  public class MemberFamilyType:ObjectGraphType<MemberFamilyModel>
  {
    public MemberFamilyType()
    {
      Name = "MemberFamily";
      Field(x => x.Id);
      Field(x => x.Name);
      Field(x => x.Photo);
      Field<FamilyType>().Name("Family");
    }
  }
}
