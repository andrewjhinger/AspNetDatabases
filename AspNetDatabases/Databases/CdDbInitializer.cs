using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AspNetDatabases.Models;

namespace AspNetDatabases.Databases
{
    public class CdDbInitializer : DropCreateDatabaseIfModelChanges<CdDbContext>
    {
        protected override void Seed(CdDbContext context)
        {
            var CdDbItems = new List<CdDb>
            {
                new CdDb{ ID = 0, Title = "Desire", Artist = "Bob Dylan", RecordLabel = "Blue", RecordYear = 1965 },
                new CdDb{ ID = 1, Title = "Crossroads", Artist = "Eric Clapton", RecordLabel = "Blue", RecordYear = 1965 }
            };
            CdDbItems.ForEach(m => context.cddb.Add(m));
            context.SaveChanges();
        }
    }
}