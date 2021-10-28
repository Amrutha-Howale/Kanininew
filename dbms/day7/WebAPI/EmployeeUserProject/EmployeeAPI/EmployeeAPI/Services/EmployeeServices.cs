using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeServices
    {
        private readonly EmployeeContext _context;

        public EmployeeServices(EmployeeContext context)
        {
            _context = context;
        }
        public Employee Add(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }
        public ICollection<Employee> Listemp()
        {
            IList<Employee> employees = _context.employees.ToList();
            if (employees.Count > 0)
                return employees;
            else
                return null;
        }
    }
}
