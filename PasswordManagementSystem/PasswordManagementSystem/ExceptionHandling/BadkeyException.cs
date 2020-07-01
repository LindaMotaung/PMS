using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.ExceptionHandling
{
    [Serializable]
    public class BadkeyException : Exception
    {
        public BadkeyException(string message)
        : base(message)
        {
        }
    }
}
