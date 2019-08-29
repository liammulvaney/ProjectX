using ProjectX.Context.Interface;
using ProjectX.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.UnitOfWork.Repository
{
    public class Repository : IRepository
    {
        private IContext _DbContext { get; set; }

        public Repository(IContext DbContext)
        {
            _DbContext = DbContext; // initialize the context
        }
        public void Create<IEntity>(IEntity Create) where IEntity : class
        {
            _DbContext.SetEntity<IEntity>().Add(Create);
        }

        public void Delete<IEntity>(IEntity Deleted) where IEntity : class
        {
            _DbContext.SetEntity<IEntity>().Remove(Deleted);
        }

        public IEnumerable<IEntity> List<IEntity>(Guid Segment) where IEntity: class
        {
            return _DbContext.SetEntity<IEntity>();
        }

        public IEnumerable<IEntity> List<IEntity>(Func<IEntity, bool> Expression) where IEntity : class
        {
            return _DbContext.SetEntity<IEntity>().Where(Expression);
        }

        public IEntity Read<IEntity>(Guid Id) where IEntity : class
        {
            return _DbContext.SetEntity<IEntity>().Find(Id);
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }

        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }
    }
}
