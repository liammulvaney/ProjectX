using ProjectX.Models.Models;
using ProjectX.UnitOfWork.UOW.Interface;
using System;
using System.Collections.Generic;

namespace ProjectX.BusinessLogic.Interfaces
{
    public interface IEmployeeBL
    {
        IUOW<Employee> UnitOfWork { get; set; }
        IEnumerable<Employee> GetAllEmployeesAsync(Guid PartitionId);
        IEnumerable<Employee> GetAllEmployeesAsync(Func<Employee, bool> condition);
        void CreateEmployeeAsync(Employee EmployeeToCreate);
        void UpdateEmployeeAsync(Employee EmployeeToUpdate);
        void DeleteEmployeeAsync(Employee EmployeeToDelete);

    }
}
