using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Models;

namespace SampleWebAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;
        public EmployeeRepository(EmployeeContext context)
        {
            _employeeContext = context;
        }
        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetAll(bool orderbyDesc)
        {
            if (orderbyDesc)
                return _employeeContext.Employees.TagWith("Apply OrderBy DESC").ToList();
            else
                return _employeeContext.Employees.ToList();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;

            _employeeContext.SaveChanges();
        }
    }
}
