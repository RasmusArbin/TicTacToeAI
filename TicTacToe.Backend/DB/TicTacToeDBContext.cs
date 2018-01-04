using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.DB;
using TicTacToe.Backend.Deccorators;

namespace TicTacToe.Backend.Models
{
    public partial class TicTacToeContext : IDbContext
    {
        const string TBL_PREFIX = "";

        private string _connectionString;

        public TicTacToeContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Task<int> SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        public ITable<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return new TicTacToeDbSet<TEntity>(Set<TEntity>());
        }

        public string GetQueryableAsString<T>(IQueryable<T> queryable)
            where T: class
        {
            return queryable.ToSql();
        }

        public List<string> GetDependencies<T>(IQueryable<T> queryable) where T : class
        {
            string expression = GetQueryableAsString(queryable);

            //Get all classes that can be idetified by Id
            var types =
                from t in Assembly.GetExecutingAssembly().GetTypes()
                where t.GetInterfaces().Contains(typeof(IIdentifiable))
                select t;

            return
                types
                    .Where(type => expression.Contains(string.Format("[{0}{1}]", TBL_PREFIX, type.Name)))
                    .Select(type => type.Name)
                    .ToList();
        }

        public List<T> ReadQuery<T>(IQueryable<T> query) where T : class
        {
            return query.ToList();
        }

        public Task<List<T>> ReadQueryAsync<T>(IQueryable<T> query) where T : class
        {
            return query.ToListAsync();
        }

        public override void Dispose()
        {
            SaveChanges();
            base.Dispose();
        }
    }
}
