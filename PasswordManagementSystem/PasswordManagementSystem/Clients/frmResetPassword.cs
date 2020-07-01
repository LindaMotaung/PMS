using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManagementSystem.Utilities;
using PasswordManagementSystem.Entities;
using PasswordManagementSystem.Interfaces;

namespace PasswordManagementSystem
{
    public partial class frmResetPassword : Form
    {
        private IUser iUser;
        private string text = string.Empty;

        public frmResetPassword(IUser _iUser)
        {
            InitializeComponent();
            this.iUser = _iUser;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string newPassword = string.Empty;
            string[] inputData = new string[4];

            if (txtPassword.Text != string.Empty && txtConfirmPassword.Text != string.Empty)
            {
                if (txtPassword.Text.Trim() == txtConfirmPassword.Text.Trim())
                {
                    string username = Utility.getUsername;
                    List<UserAccountEntity> listData = Utility.decryptedList;

                    if (listData != null || listData.Count > 0)
                    {
                        foreach (var index in listData)
                        {
                            index.password = txtPassword.Text.Trim();
                            newPassword = index.password;

                            inputData[0] = index.username;
                            inputData[1] = index.email;
                            inputData[2] = newPassword;
                            inputData[3] = index.passwordReminder;
                        }
                        this.iUser.updatePassword(inputData);

                        text = "User password updated successfully!";
                        Utility.showLabel(lblError, text, Color.Green);
                    }
                }
                else
                {
                    text = "Please ensure that passwords match!";
                    Utility.showLabel(lblError, text, Color.Red);
                }
            }
            else
            {
                text = "Please enter input into both fields!";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }
    }
}
