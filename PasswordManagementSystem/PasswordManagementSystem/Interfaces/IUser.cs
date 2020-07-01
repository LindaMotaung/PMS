using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagementSystem.Interfaces
{
    public interface IUser
    {
        void registerAccount(string[] array);
        void login(string[] array);
        bool forgotPassword(string usernameParams, string confirmationCode);
        void updatePassword(string[] array);
        void insertConfirmationCode(int confirmationCode);
    }
}
