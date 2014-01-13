using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Model.ReportService;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data;
using Breeze.WebApi;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public interface IUsersAccountContext : IContext
    {
        IDbSet<UserProfile> UserProfile { get; }
        IDbSet<webpages_Roles> webpages_Roles { get; }
        IDbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; }
    }

    public class UsersAccountContext : DbContext, IUsersAccountContext
    {
        private readonly EFContextProvider<UsersAccountContext> _context = new EFContextProvider<UsersAccountContext>();

        public UsersAccountContext()
            : base("reportservice"){ }

        public bool DatabaseExists()
        {
            return this.DatabaseExists();
        }

        public void DatabaseInitialize()
        {
            this.Database.Initialize(true);
        }

        public string Metadata()
        {
            return _context.Metadata();
        }

        public SaveResult BreezeSaveChanges(JObject saveBundle)
        {
            return _context.SaveChanges(saveBundle);
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<UsersAccountContext>(null);
        }
        
        //Entity
        public IDbSet<UserProfile> UserProfile { get; set; }
        public IDbSet<webpages_Roles> webpages_Roles { get; set; }
        public IDbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        public void SetModified(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = System.Data.EntityState.Added;
        }
    }
}
