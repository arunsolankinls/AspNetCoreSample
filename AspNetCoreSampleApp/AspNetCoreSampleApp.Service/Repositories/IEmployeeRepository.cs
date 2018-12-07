using AspNetCoreSampleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreSampleApp.Service.Repositories
{
    public interface IEmployeeRepository
    {
        bool AddEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployes();
        IEnumerable<Employee> GetAllEmployesByPage(int page);

        IEnumerable<Employee> GetAllEmployesByPageAndPageSize(int? page,int pagesize);

        Employee GetEmployeeById(int employeeid);
        void DeleteEmployee(int id);
    }
}
