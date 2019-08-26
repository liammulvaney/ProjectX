using ProjectX.UnitOfWork.Interfaces;
using ProjectX.UnitOfWork.UOW.Interface;

namespace ProjectX.UnitOfWork.UOW.Implementation
{
    public class UOW<IEntity> : IUOW<IEntity> where IEntity : class
    {
        public IRepository<IEntity> Repository { get; set; }

        public UOW(IRepository<IEntity> repository)
        {
            Repository = repository; 
        }

        public void SaveChanges()
        {
            Repository.SaveChanges();
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
