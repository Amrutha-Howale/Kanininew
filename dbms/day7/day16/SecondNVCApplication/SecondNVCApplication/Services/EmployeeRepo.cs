using Microsoft.EntityFrameworkCore;
using SecondNVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondNVCApplication.Services
{
    public class EmployeeRepo : IRepo<Employee>
    {
        private readonly CompanyContext _context;

        public EmployeeRepo(CompanyContext context)
        {
                _context=context;
        }
        public Employee Add(Employee k)
        {
            try
            {
                _context.employees.Add(k);
                _context.SaveChanges();
                return k;
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Employee Delete(int id)
        {
            Employee employee = null;
            try
            {
                employee = _context.employees.FirstOrDefault(e => e.Id == id);
                _context.employees.Remove(employee);
                _context.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }

        public Employee Get(int id)
        {
            Employee employee = null;
            try
            {
                employee = _context.employees.FirstOrDefault(e => e.Id == id);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }

        public ICollection<Employee> GetAll()
        {
            IList<Employee> employees = _context.employees.ToList();
            if (employees.Count > 0)
                return employees;
            else
                return null;
        }

        public Employee Update(Employee k)
        {
            Employee employee = null;
            try
            {
                employee = _context.employees.FirstOrDefault(e => e.Id == k.Id);
                employee.Name = k.Name;
                employee.Age = k.Age;
                employee.DepartmentId = k.DepartmentId;
                _context.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return employee;
        }
    }
}
