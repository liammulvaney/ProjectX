using ProjectX.UnitOfWork.Interfaces;
using System;

namespace ProjectX.UnitOfWork.UOW.Interface
{
    public interface IUOW<IEntity> : IDisposable
    {
       IRepository<IEntity> Repository { get; set; }
       void SaveChanges(); 
    }
}
