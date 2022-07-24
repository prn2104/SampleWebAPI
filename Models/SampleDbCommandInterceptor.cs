using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWebAPI.Models
{
    public class SampleDbCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
       DbCommand command,
       CommandEventData eventData,
       InterceptionResult<DbDataReader> result)
        {
            ModifyCommand(command);

            return result;
        }

        
        private static void ModifyCommand(DbCommand command)
        {
            if (command.CommandText.StartsWith("-- Apply OrderBy DESC", StringComparison.Ordinal))
            {
                command.CommandText += " Order By 1 DESC";
            }
        }
    }
}
