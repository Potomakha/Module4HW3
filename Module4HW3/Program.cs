using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Module4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionDbBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionDbBuilder
                .UseSqlite(connectionString)
                .Options;

            using (var db = new ApplicationContext(options))
        }
    }
}
