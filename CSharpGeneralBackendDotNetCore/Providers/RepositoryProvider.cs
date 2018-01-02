using CSharpGeneralBackendDDotNetCore.Interfaces;
using System.Collections.Generic;
using System;

namespace CSharpGeneralBackendDDotNetCore.Providers
{
    public class RepositoryProvider
    {
        public IDbContext DbContext;
        protected RepositoryProvider(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
