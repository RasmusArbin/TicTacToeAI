using CSharpGeneralBackendDDotNetCore.Providers;

namespace CSharpGeneralBackendDDotNetCore.Interfaces
{
    public interface IService<T>
        where T: RepositoryProvider
    {
        void Bind(T repositoryProvider, ILogger logger, ICache cache);
    }
}
