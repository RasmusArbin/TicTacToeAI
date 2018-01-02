using CSharpGeneralBackendDDotNetCore.Interfaces;
using System;
using System.Collections.Generic;
using CSharpGeneralBackendDDotNetCore.Providers;
using TicTacToe.Backend.General;
using TicTacToe.Backend.Interfaces;

namespace TicTacToe.Backend.Providers
{
    /// <summary>
    /// This class has the reponsibility to provide the different repositories in the system.
    /// </summary>
    public class TicTacToeRepositoryProvider: RepositoryProvider
    {
        private readonly Dictionary<Type, IRepository> _repositories;

        public TicTacToeRepositoryProvider(IDbContext dbContext) : base(dbContext)
        {
            _repositories = new Dictionary<Type, IRepository>();
        }

        public TicTacToeRepository<T> GetRepository<T>() 
            where T : class, IBaseBO
        {
            IRepository obj;
            _repositories.TryGetValue(typeof(T), out obj);

            if (obj == null)
            {
                obj = TicTacToeRepository<T>.GetInstance(DbContext);
                _repositories.Add(typeof(T), obj);
            }

            return (TicTacToeRepository<T>) obj;
        }
    }
}
