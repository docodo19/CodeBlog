using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.Interface
{
    public interface IGenericRepository : IDisposable
    {
        System.Linq.IQueryable<T> Query<T>() where T : class;
        System.Linq.IQueryable Query(string entityTypeName);
        void Add<T>(T entityToCreate) where T : class;
        T Find<T>(params object[] keyValues) where T : class;
        void Delete<T>(params object[] keyValues) where T : class;
        void SaveChanges();
        System.Collections.Generic.IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters);
    }
}
