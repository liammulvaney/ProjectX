using ProjectX.Context.Interface;
using ProjectX.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.UnitOfWork.Repository
{
    public class Repository<IEntity> : IRepository<IEntity> where IEntity : class
    {
        private IContext _DbContext { get; set; }

        public Repository(IContext DbContext)
        {
            _DbContext = DbContext; // initialize the context
        }
        public void Create(IEntity Create)
        {
            _DbContext.SetEntity<IEntity>().Add(Create);
        }

        public void Delete(IEntity Deleted)
        {
            _DbContext.SetEntity<IEntity>().Remove(Deleted);
        }

        public IEnumerable<IEntity> List(Guid Segment)
        {
            return _DbContext.SetEntity<IEntity>();
        }

        public IEnumerable<IEntity> List(Func<IEntity, bool> Expression)
        {
            return _DbContext.SetEntity<IEntity>().Where(Expression);
        }

        public IEntity Read(Guid Id)
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
