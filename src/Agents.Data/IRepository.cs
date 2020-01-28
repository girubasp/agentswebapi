using System;
using System.Collections.Generic;
using System.Text;
using Agents.Data.Model;

namespace Agents.Data
{
    public interface IRepository<T> where T : EntityBase
    {
        List<T> GetAll();
        T GetById(int id);

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
