using System.Linq;
using System.Threading.Tasks;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TicTacToe.Backend.DB
{
    public class TicTacToeDbSet<T> : ITable<T>
        where T: class
    {
        private readonly DbSet<T> _dbSet;
        public TicTacToeDbSet(DbSet<T> dbSet)
        {
            _dbSet = dbSet;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
