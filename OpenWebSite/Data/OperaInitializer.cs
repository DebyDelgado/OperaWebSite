using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OpenWebSite.Models;

namespace OpenWebSite.Data
{
    public class OperaInitializer : DropCreateDatabaseAlways<OperaDbContext>
{
    protected override void Seed(OperaDbContext context)
    {
        var operas = new List<Opera>
            {
               new Opera {
                  Title = "Cosi Fan Tutte",
                  Year = 1790,
                  Composer = "Mozart"
               }
            };
        operas.ForEach(s =>context.Operas.Add(s));
        context.SaveChanges();


    }
}
}
