using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using TicTacToe.Backend.Interfaces;

namespace TicTacToe.Backend.General
{
    /// <summary>
    /// Class to handle a database table.
    /// 
    /// NOTE: The structure of this backend is flexible. To use a database just change this implementation and LoanCalculatorDbSet (or the provider)
    /// </summary>
    public class TicTacToeDbSet<T>
        where T : IBaseBO
    {
        private readonly List<T> _entities;
        public TicTacToeDbSet(List<T> entites)
        {
            _entities = entites;
        }
        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void Insert(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            //Do not need to be implemented
        }

        public T GetById(int id)
        {
            return _entities.Find(e => e.Id == id);
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
