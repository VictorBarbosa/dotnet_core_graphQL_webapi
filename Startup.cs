using System;
using System.Collections.Generic;
using dotnet_core_graphql.GraphQL.Queries;
using dotnet_core_graphql.GraphQL.Schema;
using dotnet_core_graphql.GraphQL.Types;
using dotnet_core_graphql.Models;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace dotnet_core_graphql
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }
    public IConfiguration Configuration { get; }


    

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      

      services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<IDocumentWriter, DocumentWriter>();

      

      services.AddSingleton<MySchema>();
      services.AddSingleton<FamilyType>( );
      services.AddSingleton<MemberFamilyType>( );
      services.AddSingleton<FamilyQuery>();
      services.AddSingleton<FamilyModel>();
      services.AddSingleton<MemberFamilyModel>();


      services.AddSingleton<ISchema, MySchema>();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddGraphQL();

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }



      loggerFactory.AddConsole();
      app.UseDeveloperExceptionPage();

      // add http for Schema at default url /graphql
      app.UseGraphQL<ISchema>("/graphql");

      // use graphql-playground at default url /ui/playground
      app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
      {
        Path = "/ui/playground"
      });
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
