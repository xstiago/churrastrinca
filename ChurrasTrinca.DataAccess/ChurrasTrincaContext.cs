using ChurrasTrinca.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChurrasTrinca.DataAccess
{
    public class ChurrasTrincaContext : DbContext
    {
        public ChurrasTrincaContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChurrasTrincaContext, ChurrasTrinca.DataAccess.Migrations.Configuration>("ChurrasTrincaContext"));
        }
        
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Barbecue> Barbecues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<Participant>()
                .Property(p => p.ContributionValue)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Barbecue>()
                .Property(p => p.WithDrink)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Barbecue>()
                .Property(p => p.WithoutDrink)
                .HasPrecision(5, 2);
        }
    }
}
