using System;
using System.Collections.Generic;
using System.Text;
using CSharpGeneralBackendDDotNetCore.Interfaces;

namespace TicTacToe.Backend.General
{
    public class TicTacToeLogger : ILogger
    {
        public void Log(string loggingMessage, string stackTrace)
        {
        }

        public void LogDelete(IIdentifiable entity)
        {
        }

        public void LogInsert(IIdentifiable entity)
        {
        }

        public void LogUpdate(IIdentifiable entity)
        {
        }
    }
}
