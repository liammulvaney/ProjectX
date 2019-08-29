using ProjectX.Models.Models;
using ProjectX.UnitOfWork.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.BusinessLogic.Interfaces
{
    public interface IEmployeeBL
    {
        IUOW UnitOfWork { get; set; }
        IEnumerable<Employee> GetAllEmployeesAsync(Guid PartitionId);
        IEnumerable<Employee> GetAllEmployeesAsync(Func<Employee, bool> condition);
        void CreateEmployee(Employee EmployeeToCreate);
        int UpdateEmployeeAsync(Employee EmployeeModifications);
        int DeleteEmployeeAsync(Guid EmployeeId);
        Employee GetEmployeeDetails(Guid EmployeeId);

    }
}
