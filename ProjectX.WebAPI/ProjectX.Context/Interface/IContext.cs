using Microsoft.EntityFrameworkCore;
using System;

namespace ProjectX.Context.Interface
{
    public interface IContext : IDisposable
    {
        DbSet<IEntity> SetEntity<IEntity>() where IEntity : class;
        int SaveChanges();
        
    }
}
