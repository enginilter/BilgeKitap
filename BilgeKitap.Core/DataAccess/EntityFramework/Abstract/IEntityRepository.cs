using BilgeKitap.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BilgeKitap.Core.DataAccess.EntityFramework.Abstract
{
    //class:Referans Tip
    //IEntity: I Entity olabilir veya IEntityden implemente edilen nesne olabilir
    //new(): new'lenebilir olmalı
    public interface IEntityRepository<T>where T:class,IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(Expression<Func<T, bool>>filter);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);



    }
}
