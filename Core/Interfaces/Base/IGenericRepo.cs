﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
