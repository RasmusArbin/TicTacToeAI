using CSharpGeneralBackendDDotNetCore.Interfaces;
using System;
namespace TicTacToe.Backend.Interfaces
{
    /// <summary>
    /// Interface that every BO must implement
    /// </summary>
    public interface IBaseBO: IIdentifiable
    {
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
    }
}
