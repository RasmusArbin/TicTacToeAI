using CSharpGeneralBackendDDotNetCore;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using TicTacToe.Backend.Interfaces;

namespace TicTacToe.Backend.General
{
    public class TicTacToeRepository<T>: Repository<T>, IRepository
        where T: class, IBaseBO
    {
        public static TicTacToeRepository<T> GetInstance(IDbContext dbContext)
        {
            TicTacToeRepository<T> repository = new TicTacToeRepository<T>();
            repository.Bind(dbContext);
            return repository;
        }
    }
}
