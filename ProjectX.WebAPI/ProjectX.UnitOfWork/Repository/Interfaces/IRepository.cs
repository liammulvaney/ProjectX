﻿using System;
using System.Collections.Generic;

namespace ProjectX.UnitOfWork.Interfaces
{
    public interface IRepository<IEntity> : IDisposable
    {
        IEntity Read(Guid Id);
        IEnumerable<IEntity> List(Guid Segment);
        IEnumerable<IEntity> List(Func<IEntity, bool> Expression);
        void Delete(IEntity Deleted);
        void Create(IEntity Create);
        void SaveChanges();

    }
}
