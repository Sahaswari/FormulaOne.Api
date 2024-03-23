using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) //define tables , it is called it as code first approch
    {   // define the db entities
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Achievement> Achievements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //ovveride function
        {
            base.OnModelCreating( modelBuilder);
            //specify the relationship between entitis
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasOne(d => d.Driver)
                      .WithMany(p => p.Achievements)
                      .HasForeignKey(d => d.DriverId)
                      .OnDelete(DeleteBehavior.NoAction)
                      .HasConstraintName("FK_Achievements_Driver");
                         
            }
            );
        }
    }
}
