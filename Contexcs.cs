using ConsoleAppDop3HW0502.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDop3HW0502
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BestEmployees;Trusted_Connection=True;");
        }
        public void Seed()
        {
            if (!Departments.Any())
            {
                var departments = new List<Department>
            {
                new Department { Name = "IT" },
                new Department { Name = "HR" },
                new Department { Name = "Finance" }
            };
                Departments.AddRange(departments);
                SaveChanges();

                var employees = new List<Employee>
            {
                new Employee { Name = "Avramenko Nata", Salary = 60000, DepartmentId = departments[0].Id },
                new Employee { Name = "Babenko Alex", Salary = 55000, DepartmentId = departments[0].Id },
                new Employee { Name = "Chenko Anna", Salary = 70000, DepartmentId = departments[0].Id },
                new Employee { Name = "Didenko Oleg", Salary = 50000, DepartmentId = departments[1].Id },
                new Employee { Name = "Elenko Nina", Salary = 65000, DepartmentId = departments[1].Id },
                new Employee { Name = "Fedorenko Petr", Salary = 48000, DepartmentId = departments[2].Id },
                new Employee { Name = "Kirilenko Olga", Salary = 51000, DepartmentId = departments[2].Id }
            };
                Employees.AddRange(employees);
                SaveChanges();
            }
        }
    }
}

