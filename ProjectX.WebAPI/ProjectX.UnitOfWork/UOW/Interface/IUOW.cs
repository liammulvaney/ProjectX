using ProjectX.UnitOfWork.Interfaces;
using System;

namespace ProjectX.UnitOfWork.UOW.Interface
{
    public interface IUOW : IDisposable
    {
       IRepository Repository { get; set; }
       void SaveChanges(); 
    }
}
