﻿using Abis.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Abis.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        //List<T> GetMany(Expression<Func<T, bool>> where, params string[] include);

        //List<T> GetMany(params string[] include);

        //List<T> GetMany(Expression<Func<T, bool>> where);


        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
