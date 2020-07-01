using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Interfaces
{
    public interface IApplicationAccounts
    {
        void addAcccount(string[] array);
        void updateAccount(string[] array);
        void deleteSelectedAccount(int Id);
        void deleteAllAccounts();
        void refreshData();
    }
}
