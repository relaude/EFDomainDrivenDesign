using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Breeze.WebApi;

namespace DAL
{
    //One Database Only!!
    public class BaseContext<TContext>
    : DbContext where TContext : DbContext
    {
        protected BaseContext()
            : base(nameOrConnectionString: "name=northwind")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
