using CSharpGeneralBackendDDotNetCore.Interfaces;

namespace TicTacToe.Backend.General
{
    public class TicTacToeCache : ICache
    {
        public T Get<T>(string expression)
        {
            return default(T);
        }

        public void Remove(string expression)
        {
        }

        public void Set(string identifier, object item)
        {

        }
    }
}
