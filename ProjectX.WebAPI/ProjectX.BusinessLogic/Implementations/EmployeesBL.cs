using ProjectX.BusinessLogic.Interfaces;
using ProjectX.Models.Models;
using ProjectX.UnitOfWork.UOW.Interface;
using System;
using System.Collections.Generic;

namespace ProjectX.BusinessLogic.Implementations
{
    public class EmployeesBL : IEmployeeBL
    {
        public IUOW UnitOfWork { get; set; }

        public EmployeesBL(IUOW uow)
        {
            UnitOfWork = uow;
        }

        public void CreateEmployee(Employee EmployeeToCreate)
        {
            try
            {
                using (UnitOfWork)
                {
                    UnitOfWork.Repository.Create(EmployeeToCreate);
                    UnitOfWork.Repository.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Failed to create the employee record. Please contact support. { ex.Message }"); 
            }
        }

        public int DeleteEmployeeAsync(Guid EmployeeId)
        {
            try
            {
                using (UnitOfWork)
                {
                    Employee EmployeeToDelete = UnitOfWork.Repository.Read<Employee>(EmployeeId);
                    UnitOfWork.Repository.Delete(EmployeeToDelete);
                    UnitOfWork.Repository.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete the employee record. Please contact support. { ex.Message }");
            }
            
        }

        public IEnumerable<Employee> GetAllEmployeesAsync(Guid PartitionId)
        {
            IEnumerable<Employee> employees = null;
            try
            {
                using (UnitOfWork)
                    employees = UnitOfWork.Repository.List<Employee>(PartitionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve the employee records. Please contact support. { ex.Message }");
            }
            return employees;         
        }

        public IEnumerable<Employee> GetAllEmployeesAsync(Func<Employee, bool> condition)
        {
            IEnumerable<Employee> employees = null;
            try
            {
                using (UnitOfWork)
                    employees = UnitOfWork.Repository.List(condition);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to retrieve the employee records. Please contact support. { ex.Message }");
            }
            return employees;
        }

        public int UpdateEmployeeAsync(Employee EmployeeToUpdate)
        {
            try
            {
                using (UnitOfWork)
                {
                    Employee Employee = UnitOfWork.Repository.Read<Employee>(EmployeeToUpdate.EmployeeId);
                    Employee = EmployeeToUpdate;
                    UnitOfWork.Repository.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update the employee record. Please contact support. { ex.Message }");
            }          
        }

        public Employee GetEmployeeDetails(Guid EmployeeId)
        {
            return UnitOfWork.Repository.Read<Employee>(EmployeeId);
        }
    }
}
