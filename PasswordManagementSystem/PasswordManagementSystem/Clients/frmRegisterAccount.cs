using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Repositories;
using PasswordManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManagementSystem
{
    public partial class frmRegisterAccount : Form
    {
        private IUser iUser;
        private string text = string.Empty;

        public frmRegisterAccount(IUser _iUser)
        {
            InitializeComponent();
            this.iUser = _iUser; //peforming constructor dependency injection
        }

        private void frmRegisterAccount_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.AutoSize = true;
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                text = "Please ensure that the passwords match!";
                Utility.showLabel(lblError, text, Color.Red);
            }
            else if (txtUsername.Text == string.Empty && txtEmail.Text == string.Empty)
            {
                text = "Please ensure that you have entered" + "/n" + " a Username and password";
                Utility.showLabel(lblError, text, Color.Red);
            }
            else
            {
                if (txtEmail.Text.Contains("@"))
                {
                    string[] inputData = { txtUsername.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim(), txtPasswordReminder.Text.Trim() };
                    this.iUser.registerAccount(inputData);

                    if (Utility.getText != string.Empty)
                        text = Utility.getText;

                    Utility.showLabel(lblError, text, Color.Green);                
                }
                else
                {
                    text = "Please enter email in correct format";
                    Utility.showLabel(lblError, text, Color.Red);
                }             
            }
        }
    }
}
