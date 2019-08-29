using ProjectX.UnitOfWork.Interfaces;
using ProjectX.UnitOfWork.UOW.Interface;

namespace ProjectX.UnitOfWork.UOW.Implementation
{
    public class UOW : IUOW
    {
        public IRepository Repository { get; set; }

        public UOW(IRepository repository)
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
