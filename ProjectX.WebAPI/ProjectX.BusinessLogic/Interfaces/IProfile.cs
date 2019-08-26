using ProjectX.Models.Models;
using ProjectX.UnitOfWork.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectX.BusinessLogic.Interfaces
{
    public interface IProfile
    {
        IUOW<Employee> UnitOfWork { get; set; }
        Employee GetProfileByEmployeeIdAsync(Guid EmployeeId);
        void CreateProfile(Guid EmployeeId);
        void DeleteProfileAsync(Guid EmployeeId);
    }
}
