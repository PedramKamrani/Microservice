using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using platformService.Data;
using platformService.Models;

namespace platformService
{
    public class PrepDb
    {
public static void PrepPopulation(IApplicationBuilder app)
{
    using(var servicescope=app.ApplicationServices.CreateScope())
    {
            SeedData(servicescope.ServiceProvider.GetService<AppDataContext>());
    }
}

private static void SeedData(AppDataContext context)
{
    if(!context.platforms.Any())
    {
            Console.WriteLine("--->sedind data");
            context.platforms.AddRange(
                new Platform(){Name="DotNet",Publisher="Microsot",Cost="free"},
                 new Platform(){Name="SqlServer",Publisher="Microsot",Cost="free"},
                  new Platform(){Name="Kubernetes",Publisher="Cloud Native Computing Foundation",Cost="free"}
            );
            context.SaveChanges();
    }else{
        Console.WriteLine("--->we already have data");
    }
}
 }
}