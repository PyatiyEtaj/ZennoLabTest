using Microsoft.EntityFrameworkCore;

namespace ZennoLabWebAPI.EntityContext
{
    public class DataBaseContext : DbContext
    {
        public DbSet<DataSet> DataSets { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataSet>().ToTable(nameof(DataSet));
            modelBuilder.Entity<DataSet>().HasIndex(x => x.Name);
        }
    }
}
