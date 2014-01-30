using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetDatabases.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetDatabases.Databases
{
    public class CdDbContext : DbContext
    {
        public DbSet<CdDb> cddb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}