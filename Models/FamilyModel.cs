using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.WebEncoders.Testing;

namespace dotnet_core_graphql.Models
{
  public class FamilyModel : Common
  {

    /// <summary>
    /// The family name
    /// </summary>
    public string Name { get; set; }
    private string _Name { get; set; }
    /// <summary>
    /// All members of family
    /// </summary>
    public List<MemberFamilyModel> Members { get; set; }



    public List<FamilyModel> DBSample()
    {
      int idIncrementer = 1;
      int idFamily = 1;

      List<FamilyModel> list = new List<FamilyModel>
        {
          new FamilyModel
          {
            Id =idFamily++,
            Name =  "Simpson",
            Photo = ImgBase64("simpsons"),
            Members = new List<MemberFamilyModel>
            {
              new MemberFamilyModel{Id= idIncrementer++,Name = "Homer" ,  Photo = ImgBase64("homer"),  },
              new MemberFamilyModel{Id= idIncrementer++,Name = "Marge",  Photo = ImgBase64("marge"),  },
              new MemberFamilyModel{Id =idIncrementer++,Name = "Bart",   Photo = ImgBase64("bart"),  },
              new MemberFamilyModel{Id =idIncrementer++,Name = "Lisa",   Photo = ImgBase64("lisa"),  },
              new MemberFamilyModel{Id =idIncrementer++,Name = "Meggie", Photo = ImgBase64("meggie"),  },
            }
          }
          ,new FamilyModel
          {
            Id =idFamily++,
            Name = "Griffin",
            Photo = ImgBase64("griffins"),
            Members = new List<MemberFamilyModel>
            {
              new MemberFamilyModel{Id=  idIncrementer++,Name = "Peter", Photo = ImgBase64("peter"),  },
              new MemberFamilyModel{Id=  idIncrementer++,Name = "Lois",  Photo = ImgBase64("lois"),  },
              new MemberFamilyModel{Id = idIncrementer++,Name = "Meg",   Photo = ImgBase64("meg"),  },
              new MemberFamilyModel{Id = idIncrementer++,Name = "Chris", Photo = ImgBase64("chris"),  },
              new MemberFamilyModel{Id = idIncrementer++,Name = "Stewie",Photo = ImgBase64("stewie"),  },
            }
          }, new FamilyModel
          {
            Id =idFamily++,
            Name = "Jetson",
            Photo = ImgBase64("jetsons"),
            Members = new List<MemberFamilyModel>
            {
              new MemberFamilyModel{Id=  idIncrementer++,Name = "George", Photo = ImgBase64("george"),  },
              new MemberFamilyModel{Id=  idIncrementer++,Name = "Jane" ,  Photo = ImgBase64("jane"),  },
              new MemberFamilyModel{Id = idIncrementer++,Name = "Judy",   Photo = ImgBase64("judy"),  },
              new MemberFamilyModel{Id = idIncrementer++,Name = "Elroy",  Photo = ImgBase64("elroy"),  },
            }
          },
        };
      return list;
    }

    private string ImgBase64(string img)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
      return builder.Build()[string.Format("imgs:{0}", img)];
    }
  }
}