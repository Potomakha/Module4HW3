using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new TitleConfig());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfig());
            modelBuilder.ApplyConfiguration(new ProjectConfig());
            modelBuilder.ApplyConfiguration(new ClientConfig());

            modelBuilder.Entity<Project>().HasData(
                new Project { ProjectId = 1, Name = "calculator", Budget = 1000, ClientId = 1 },
                new Project { ProjectId = 2, Name = "Windows 10", Budget = 2123, ClientId = 2 },
                new Project { ProjectId = 3, Name = "onlineShop", Budget = 1124512, ClientId = 3 },
                new Project { ProjectId = 4, Name = "music player", Budget = 100123, ClientId = 4 },
                new Project { ProjectId = 5, Name = "vr home", Budget = 1246100, ClientId = 5 });

            modelBuilder.Entity<Client>().HasData(
                new Client { ClientId = 1, FirstName = "Dima", LastName = "Dimich", OrganizationName = "Kulinichi" },
                new Client { ClientId = 2, FirstName = "Vanya", LastName = "Vano", OrganizationName = "Bufet" },
                new Client { ClientId = 3, FirstName = "Oleh", LastName = "Olegich", OrganizationName = "ATB market" },
                new Client { ClientId = 4, FirstName = "Alyona", LastName = "Alyeona", OrganizationName = "Microsoft" },
                new Client { ClientId = 5, FirstName = "Petro", LastName = "Petrovich", OrganizationName = "Apple" });
        }
    }
}
