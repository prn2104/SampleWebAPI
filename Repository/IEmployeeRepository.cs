using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleWebAPI.Models;
namespace SampleWebAPI.Repository
{
    public interface IEmployeeRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(bool OrderByDesc);
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(Employee employee, TEntity entity);
        void Delete(Employee employee);
    }
}
