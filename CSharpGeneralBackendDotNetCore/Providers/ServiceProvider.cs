using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpGeneralBackendDDotNetCore.Interfaces;

namespace CSharpGeneralBackendDDotNetCore.Providers
{
    public abstract class ServiceProvider
    {
        protected IDbContext DbContext;
        protected ServiceProvider(IDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
