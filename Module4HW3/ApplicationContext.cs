using Microsoft.EntityFrameworkCore;
using Module4HW3.Entity;
using Module4HW3.EntityConfig;

namespace Module4HW3
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> Companies { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new TitleConfig());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());

            modelBuilder.Entity<Client>().HasData(
                new Client { FirstName = "Dima", LastName = "Dimich", OrganizationName = "Kulinichi" },
                new Client { FirstName = "Vanya", LastName = "Vano", OrganizationName = "Bufet" },
                new Client { FirstName = "Oleh", LastName = "Olegich", OrganizationName = "ATB market" },
                new Client { FirstName = "Alyona", LastName = "Alyeona", OrganizationName = "Microsoft" },
                new Client { FirstName = "Petro", LastName = "Petrovich", OrganizationName = "Apple" });

            modelBuilder.Entity<Project>().HasData(
                new Project { Name = "calculator", Budget = 1000, ClientId = 1 },
                new Project { Name = "Windows 10", Budget = 2123, ClientId = 2 },
                new Project { Name = "onlineShop", Budget = 1124512, ClientId = 3 },
                new Project { Name = "music player", Budget = 100123, ClientId = 4 },
                new Project { Name = "vr home", Budget = 1246100, ClientId = 5 });
        }
    }
}
