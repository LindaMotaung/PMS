using PasswordManagementSystem.Entities;
using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Configuration;
using System.Data.SqlClient;
using PasswordManagementSystem.Repositories;

namespace PasswordManagementSystem
{
    public partial class frmForgotPassword : Form
    {
        private IUser iUser;
        private int confirmationCode = 0;
        private string text = string.Empty;

        public frmForgotPassword(IUser _iUser)
        {
            InitializeComponent();
            this.iUser = _iUser;
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.AutoSize = true;
            ToolTip();
        }

        private void ToolTip()
        {
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
          
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.txtSecurityQuestion, "This is the question associated with your password reminder");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;
            Utility.getPasswordReminder = txtSecurityQuestion.Text.Trim();

            if (this.iUser.forgotPassword(txtUsername.Text, txtConfirmationCode.Text) == true)
            {
                text = "Pass!";
                Utility.showLabel(lblError, text, Color.Green);

                frmResetPassword resetPasswordForm = new frmResetPassword(new User());
                resetPasswordForm.Show();
            }
            else
            {
                if (Utility.errorFlag == false)
                    text = Utility.getText;
                else
                {
                    if (Utility.areKeysEqual == true)
                        text = "User either does not exist or \n confirmation code incorrect";
                    else
                        text = "Public key used for encryption does not match private key.";
                }
                Utility.showLabel(lblError, text, Color.Red);
            }
            btnSubmit.Enabled = true;
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != string.Empty)
                Utility.getUsername = txtUsername.Text;

            Mail mail = new Mail();
            List<string> to = new List<string>()
            {
                "linda.motaung@imperialcrd.co.za"
            };

            Random rand = new Random();
            confirmationCode = rand.Next(000000000, 999999999);
            this.iUser.insertConfirmationCode(confirmationCode);

            string body = "<p> Good day, </p> </br> <p> Please find your confirmation code below herewith: <b>" + Convert.ToString(confirmationCode) + "</b></p>. </br> <p> Regards - The PMS Team </p>";

            if (txtEmail.Text != null && txtEmail.Text != string.Empty)
            {
                //mail.sendMail(txtEmail.Text.Trim(), to, body);

                mail.sendMail("motaung.linda@gmail.com", to, body);
                text = "Password reset email successfully sent to: \n" + txtEmail.Text.Trim() + ".";
                Utility.showLabel(lblError, text, Color.Green);

                txtConfirmationCode.Enabled = true;
                btnRequest.Enabled = false;
                txtSecurityQuestion.Enabled = true;
                btnSubmit.Enabled = true;
            }
            else
            {
                text = "Email field needs to be populated.";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }
    }
}
