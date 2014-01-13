using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Model.Northwind;
using System.Data.Entity;
using Model.ReportService;
using System.Data.Entity.ModelConfiguration.Conventions;
using Breeze.WebApi;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public interface IReportServiceContext : IContext
    {
        IDbSet<Orders> Orders { get; }
        IDbSet<UserProfile> UserProfile { get; }
        IDbSet<webpages_Roles> Roles { get; }
        IDbSet<UserRoles> UserRoles { get; }
        IDbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; }
    }

    public class ReportServiceContext : BaseContext<ReportServiceContext>, IReportServiceContext
    {
        private readonly EFContextProvider<ReportServiceContext> _context = new EFContextProvider<ReportServiceContext>();

        public IDbSet<Orders> Orders { get; set; }
        public IDbSet<UserProfile> UserProfile { get; set; }
        public IDbSet<webpages_Roles> Roles { get; set; }
        public IDbSet<UserRoles> UserRoles { get; set; }
        public IDbSet<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }

        public SaveResult BreezeSaveChanges(JObject saveBundle)
        {
            return _context.SaveChanges(saveBundle);
        }
        
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
