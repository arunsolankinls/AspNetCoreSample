using AspNetCoreSampleApp.Core;
using AspNetCoreSampleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreSampleApp.Service.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        DataContext _context;
        public EmployeeRepository(DataContext context)
        {
            this._context = context;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                //var employeedata = _context.Employee.Add(employee);
                //_context.SaveChanges();

                _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAllEmployes()
        {
            //var employeelist = _context.Employee.ToList();
            //return employeelist;
            return _context.Employee.AsEnumerable();
        }

        public IEnumerable<Employee> GetAllEmployesByPage(int page)
        {
            //var employeelist = _context.Employee.ToList();
            //return employeelist;
            return _context.Employee.AsEnumerable();
        }

        public IEnumerable<Employee> GetAllEmployesByPageAndPageSize(int? page, int pagesize)
        {
            int pagedata;
            if (page == null)
                pagedata = 0;
            else
            {
                pagedata = Convert.ToInt32(page);
            }

            //var employeelist = _context.Employee.ToList();
            //return employeelist;
            return _context.Employee.Skip(pagedata * pagesize).Take(pagesize).AsEnumerable();
        }

        public Employee GetEmployeeById(int employeeid)
        {
            return _context.Employee.SingleOrDefault(x => x.Id == employeeid);
        }

        public void DeleteEmployee(int id)
        {
            var employee = _context.Employee.SingleOrDefault(x => x.Id == id);
            _context.Employee.Remove(employee);
            _context.SaveChanges();
        }

    }
}
