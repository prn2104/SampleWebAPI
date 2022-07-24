using System;
using Microsoft.EntityFrameworkCore;

namespace SampleWebAPI.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }

        //Note : Injecting Interceptor into db Contex................

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SampleDbCommandInterceptor());
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Suresh",
                LastName = "Dhonikena",
                Email = "Suresh.Dhonikena@gmail.com",
                DateOfBirth = new DateTime(1990, 05, 08),
                PhoneNumber = "999-888-7777"

            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Naresh",
                LastName = "Dhonikena",
                Email = "Naresh.Dhonikena@gmail.com",
                DateOfBirth = new DateTime(1981, 07, 13),
                PhoneNumber = "111-222-3333"
            });
        }

    }
}
