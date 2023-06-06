using Microsoft.EntityFrameworkCore;
using Porcupine3API.Models;

namespace Porcupine3API.DBContexts
{
    public class ProjectContext : DbContext 
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<UserM> Users { get; set; }
        public DbSet<GroupM> Groups { get; set; }
        public DbSet<PermissionsM> Permissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserM>().HasData(
               new UserM { ID = 1, Name = "Marly", Surname = "McDonnell", Email = "mmcd@email.com" },
               new UserM { ID = 2, Name = "Isaac", Surname = "Newton", Email = "anewton@email.com" },
               new UserM { ID = 3, Name = "Isabella", Surname = "Garcia", Email = "agarcia@email.com" },
               new UserM { ID = 4, Name = "Penelope", Surname = "Cruz", Email = "pcruz@email.com" },
               new UserM { ID = 5, Name = "Tess", Surname = "Tickle", Email = "ttickle@email.com" },
               new UserM { ID = 6, Name = "Spencer", Surname = "Reed", Email = "sreed@email.com" },
               new UserM { ID = 7, Name = "David", Surname = "Rossi", Email = "drossi@email.com" },
               new UserM { ID = 8, Name = "Aaron", Surname = "Hotchner", Email = "ahotchner@email.com" },
               new UserM { ID = 9, Name = "Morgan", Surname = "Freeman", Email = "mfreeman@email.com" },
               new UserM { ID = 10, Name = "Ted", Surname = "Lasso", Email = "tlasso@email.com" }
               );

            modelBuilder.Entity<GroupM>().HasData(
               new GroupM { ID = 1, Name = "Group1" },
               new GroupM { ID = 2, Name = "Group2" },
               new GroupM { ID = 3, Name = "Group3" },
               new GroupM { ID = 4, Name = "Group4" },
               new GroupM { ID = 5, Name = "Group5" },
               new GroupM { ID = 6, Name = "Group6" }
               );

            modelBuilder.Entity<PermissionsM>().HasData(
                new PermissionsM { ID = 1, GroupID = 1, UserID = 1 },
                new PermissionsM { ID = 2, GroupID = 1, UserID = 2 },
                new PermissionsM { ID = 3, GroupID = 2, UserID = 1 },
                new PermissionsM { ID = 4, GroupID = 2, UserID = 5 },
                new PermissionsM { ID = 5, GroupID = 3, UserID = 3 },
                new PermissionsM { ID = 6, GroupID = 3, UserID = 4 },
                new PermissionsM { ID = 7, GroupID = 4, UserID = 4 });
        }
    }
}
