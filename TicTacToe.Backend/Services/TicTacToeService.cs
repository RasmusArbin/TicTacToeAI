using System.Collections.Generic;
using System.Linq;
using TicTacToe.Backend.General;
using TicTacToe.Backend.Interfaces;
using TicTacToe.Backend.Providers;
using CSharpGeneralBackendDDotNetCore;

namespace TicTacToe.Backend.Services
{
    public class TicTacToeService<T>: Service<TicTacToeRepositoryProvider>
        where T: class, IBaseBO
    {
        protected TicTacToeRepository<T> MainRepository => RepositoryProvider.GetRepository<T>();
        public List<T> GetAll()
        {
            return MainRepository.GetAll().ToList();
        }

        public void Delete(int id)
        {
            MainRepository.Delete(id);
        }

        public void Insert(T entity)
        {
            MainRepository.Insert(entity);
        }

        public void Update(T entity)
        {
            MainRepository.Update(entity);
        }

        public T GetById(int id)
        {
            return MainRepository.GetById(id);
        }
    }

    public class TicTacToeService: Service<TicTacToeRepositoryProvider>
    {
    }
}