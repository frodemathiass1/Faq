using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Faq.Models
{
    public class Sporsmal
    {
        [Key]
        public int SpmId { get; set; }
        public string Sporsmalet { get; set; }
        public string Svaret { get; set; }
        public string Kategori { get; set; }

    }



    public class KundeDb
    {
        [Key]
        public int KId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Epost { get; set; }
        public string Sporsmalet { get; set; }
        public string Svaret { get; set; }
        public string Kategori { get; set; }
    }

    public class Context : DbContext
    {
        public Context() : base("name=FAQDb")
        {
            Database.CreateIfNotExists();
            Database.SetInitializer(new DBInit());
        }
        public DbSet<Sporsmal> Sporsmaler { get; set; }
        public DbSet<KundeDb> Kunder { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }    
    }
}