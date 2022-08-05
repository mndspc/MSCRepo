using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class MSCDbEntities : DbContext
    {
        public MSCDbEntities() : base("name=MSCDbEntities")
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
      
    }

    public class MSCDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MSCDbEntities>
    {
        protected override void Seed(MSCDbEntities context)
        {
            var directors = new List<Director>
            {
            new Director{DirectorId=2,Name="Mahesh Bhutt"},
            new Director{DirectorId=3,Name="Sanjay Leela Bhansali"}
            };

            directors.ForEach(s => context.Directors.Add(s));
            context.SaveChanges();
            
        }
    }
}