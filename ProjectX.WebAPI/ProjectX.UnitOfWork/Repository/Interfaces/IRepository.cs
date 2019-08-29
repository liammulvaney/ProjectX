using System;
using System.Collections.Generic;

namespace ProjectX.UnitOfWork.Interfaces
{
    public interface IRepository: IDisposable
    {
        IEntity Read<IEntity>(Guid Id) where IEntity : class;
        IEnumerable<IEntity> List<IEntity>(Guid Segment) where IEntity : class;
        IEnumerable<IEntity> List<IEntity>(Func<IEntity, bool> Expression) where IEntity : class;
        void Delete<IEntity>(IEntity Deleted) where IEntity : class;
        void Create<IEntity>(IEntity Create) where IEntity : class;
        void SaveChanges();

    }
}
