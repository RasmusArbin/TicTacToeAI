using System;
using System.Collections.Generic;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using CSharpGeneralBackendDDotNetCore;
using TicTacToe.Backend.General;

namespace TicTacToe.Backend.Providers
{
    /// <summary>
    /// This class has the reponsibility to provide the different services in the system.
    /// </summary>
    public class TicTacToeServiceProvider: Service<TicTacToeRepositoryProvider>
    {
        private readonly Dictionary<Type, IService<TicTacToeRepositoryProvider>> _services;

        public TicTacToeServiceProvider(IDbContext dbContext)
        {
            _services = new Dictionary<Type, IService<TicTacToeRepositoryProvider>>();
            RepositoryProvider = new TicTacToeRepositoryProvider(dbContext);
        }

        public T GetService<T>()
            where T : IService<TicTacToeRepositoryProvider>, new()
        {
            IService<TicTacToeRepositoryProvider> obj;
            _services.TryGetValue(typeof(T), out obj);

            if (obj == null)
            {
                obj = new T();
                obj.Bind(RepositoryProvider, new TicTacToeLogger(), new TicTacToeCache());
                _services.Add(typeof(T), obj);
            }

            return (T) obj;
        }
    }
}