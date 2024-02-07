using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ConsoleAppDop3HW0502;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();
            context.Seed();
        }
        using (var context = new AppDbContext())
        {
            var query = context.Departments.Select(d => new{DepartmentName = d.Name,AverageSalary = d.Employees.Average(e => e.Salary),
            TopEmployees = d.Employees.OrderByDescending(e => e.Salary).Take(3).Select(e => new { e.Name, e.Salary })}).ToList();
            foreach (var department in query)
            {
                Console.WriteLine($"Отдел: {department.DepartmentName}, Средняя зарплата: {department.AverageSalary:F2}");
                Console.WriteLine("Топ 3 высокооплачиваемых сотрудников:");
                foreach (var employee in department.TopEmployees)
                {
                    Console.WriteLine($"Имя: {employee.Name}, Зарплата: {employee.Salary:F2}");
                }
                Console.WriteLine(); 
            }
        }
      
        }
    }

