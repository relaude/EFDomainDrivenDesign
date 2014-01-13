using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Breeze.WebApi;
using Newtonsoft.Json.Linq;

namespace DAL
{
    public interface IContext : IDisposable
    {
        //Breeeze Web Api
        bool DatabaseExists();
        void DatabaseInitialize();
        string Metadata();
        SaveResult BreezeSaveChanges(JObject saveBundle);
        
        //default
        int SaveChanges();
        void SetModified(object entity);
        void SetAdd(object entity);
    }
}
