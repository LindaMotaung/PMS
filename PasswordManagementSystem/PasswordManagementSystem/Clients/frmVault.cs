using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Repositories;
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

namespace PasswordManagementSystem
{
    public partial class frmVault : Form
    {
        private IUser iUser;
        private string text = string.Empty;

        public frmVault(IUser _iUser)
        {
            InitializeComponent();
            this.iUser = _iUser;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                text = "Please enter both your username and password";
                Utility.showLabel(lblError, text, Color.Red);
            }
            else
            {
                string[] inputData = { txtUsername.Text.Trim(), txtPassword.Text.Trim() };
                this.iUser.login(inputData);

                if (Utility.getText != string.Empty)
                {
                    if (Utility.errorFlag == false)
                    {
                        text = Utility.getText;
                        Utility.showLabel(lblError, text, Color.Red);
                    }
                }     
            }
        }

        private void btnForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPassword forgotPasswordForm = new frmForgotPassword(new User());
            forgotPasswordForm.Show();
        }

        private void btnRegisterAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegisterAccount registerAccountForm = new frmRegisterAccount(new User());
            registerAccountForm.Show();
        }

        private void frmVault_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.AutoSize = true;
        }
    }
}
