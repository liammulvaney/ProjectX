using ProjectX.Context.Context;
using ProjectX.Models.Models;
using ProjectX.UnitOfWork.Repository;
using ProjectX.UnitOfWork.UOW.Implementation;
using ProjectX.UnitOfWork.UOW.Interface;
using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IUOW<Employee> uow = new UOW<Employee>(new Repository<Employee>(new ProjectXContext())))
            {
                uow.Repository.List(x => x.EmployeeId == Guid.NewGuid());
                //var Employee = uow.Repository.Read(Guid.Parse("ccaa08f5-1e79-4e74-a526-c987875d386d"));
                //Employee.Account.Username = "124@gmail.com";
                //uow.SaveChanges();
            };
        }
    }
}
