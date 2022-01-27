using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Module4HW3.Entity;

namespace Module4HW3
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new SampleContextFatory().CreateDbContext(args))
            {
                if (context.Titles.FirstOrDefault() == null)
                {
                    try
                    {
                        await DataFill(context);
                        context.SaveChanges();
                        EmployeeDataFill(context);
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }

                await FirstQuery(context);
                await SecondQuery(context);
                await ThirdQuery(context);
                await SixthQuery(context);
            }
        }

        public static void EmployeeDataFill(ApplicationContext context)
        {
            context.AddRangeAsync(
                        new Employee
                        {
                            FirstName = "first",
                            LastName = "first",
                            HiredDate = new DateTime(2020, 1, 15),
                            DateOfBirth = new DateTime(1980, 1, 10),
                            OfficeId = context.Offices.Skip(0).Select(o => o.OfficeId).FirstOrDefault(),
                            TitleId = context.Titles.Skip(0).Select(t => t.TitleId).FirstOrDefault()
                        },
                        new Employee
                        {
                            FirstName = "second",
                            LastName = "second",
                            HiredDate = new DateTime(2020, 1, 15),
                            DateOfBirth = new DateTime(1980, 1, 10),
                            OfficeId = context.Offices.Skip(1).Select(o => o.OfficeId).FirstOrDefault(),
                            TitleId = context.Titles.Skip(1).Select(t => t.TitleId).FirstOrDefault()
                        },
                        new Employee
                        {
                            FirstName = "third",
                            LastName = "third",
                            HiredDate = new DateTime(2020, 1, 15),
                            DateOfBirth = new DateTime(1980, 1, 10),
                            OfficeId = context.Offices.Skip(2).Select(o => o.OfficeId).FirstOrDefault(),
                            TitleId = context.Titles.Skip(2).Select(t => t.TitleId).FirstOrDefault()
                        },
                        new Employee
                        {
                            FirstName = "fourth",
                            LastName = "fourth",
                            HiredDate = new DateTime(2020, 1, 15),
                            DateOfBirth = new DateTime(1980, 1, 10),
                            OfficeId = context.Offices.Skip(3).Select(o => o.OfficeId).FirstOrDefault(),
                            TitleId = context.Titles.Skip(3).Select(t => t.TitleId).FirstOrDefault()
                        },
                        new Employee
                        {
                            FirstName = "first",
                            LastName = "first",
                            HiredDate = new DateTime(2020, 1, 15),
                            DateOfBirth = new DateTime(1980, 1, 10),
                            OfficeId = context.Offices.Skip(4).Select(o => o.OfficeId).FirstOrDefault(),
                            TitleId = context.Titles.Skip(4).Select(t => t.TitleId).FirstOrDefault()
                        });
        }

        public static async Task DataFill(ApplicationContext context)
        {
            await context.AddRangeAsync(
                        new Title
                        {
                            Name = "Trainee dev"
                        },
                        new Title
                        {
                            Name = "Junior dev"
                        },
                        new Title
                        {
                            Name = "Strong Junior dev"
                        },
                        new Title
                        {
                            Name = "Midlle dev"
                        },
                        new Title
                        {
                            Name = "Senior dev"
                        });
            await context.AddRangeAsync(
                        new Office
                        {
                            Title = "Office-1",
                            Location = "Kharkiv"
                        },
                        new Office
                        {
                            Title = "Office-2",
                            Location = "Kiev"
                        },
                        new Office
                        {
                            Title = "Office-3",
                            Location = "Lviv"
                        },
                        new Office
                        {
                            Title = "Office-4",
                            Location = "Odessa"
                        },
                        new Office
                        {
                            Title = "Office-5",
                            Location = "Monreal"
                        });
        }

        public static async Task FirstQuery(ApplicationContext context)
        {
            var multyJoin = await context.Titles.Include(t => t.Employees).ThenInclude(e => e.Office).ToListAsync();
            Console.WriteLine("First query");
            foreach (var item in multyJoin)
            {
                var strBuilder = new StringBuilder();
                strBuilder.Append(item.TitleId + " ");
                strBuilder.Append(item.Name);
                Console.WriteLine(strBuilder);
            }

            Console.WriteLine();
         }

        public static async Task SecondQuery(ApplicationContext context)
        {
            var result = await context.Employees.Select(e => DateTime.UtcNow - e.HiredDate).ToListAsync();
            Console.WriteLine("Second query");
            foreach (var item in result)
            {
                Console.WriteLine(item.Days);
            }

            Console.WriteLine();
        }

        public static async Task ThirdQuery(ApplicationContext context)
        {
            var updateEmployee = await context.Employees.Where(e => (e.EmployeId % 2) > 0).ToListAsync();
            var updateOffice = await context.Offices.Where(o => (o.OfficeId % 2) > 0).ToListAsync();
            updateEmployee.ForEach(e => e.LastName = "Updated");
            updateOffice.ForEach(e => e.Location = "new location");
            await context.SaveChangesAsync();
            Console.WriteLine("Third query");
            Console.WriteLine();
        }

        public static async Task FifthQuery(ApplicationContext context)
        {
            var toDelete = await context.Employees.FirstOrDefaultAsync();
            context.Remove(toDelete);
            await context.SaveChangesAsync();
            Console.WriteLine("Fifth query");
        }

        public static async Task SixthQuery(ApplicationContext context)
        {
            var groupByResult = context.Titles.Include(t => t.Employees).AsEnumerable().GroupBy(t => t.Name).Where(t => !t.Key.Contains('a')).ToList();
            Console.WriteLine("Sixth query");
            foreach (var item in groupByResult)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine();
            await Task.Delay(0);
        }
    }
}