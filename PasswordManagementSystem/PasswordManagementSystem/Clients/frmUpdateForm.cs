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

namespace PasswordManagementSystem
{
    public partial class frmUpdateAppVaultAccount : Form
    {
        private IApplicationAccounts iApplicationAccount;
        private string text = string.Empty;

        public frmUpdateAppVaultAccount(IApplicationAccounts _iApplicationAccount)
        {
            InitializeComponent();
            this.iApplicationAccount = _iApplicationAccount;
        }

        private void frmUpdateForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.AutoSize = true;

            AccountVaultEntity updateRec = Utility.updateRec;
            if (updateRec != null)
            {
                txtApplicationUpdate.Text = updateRec.applicationName;
                txtUsernameUpdate.Text = updateRec.username;
                txtPasswordUpdate.Text = updateRec.password;
                txtNotesUpdate.Text = updateRec.notes;
                txtApplicationUrlUpdate.Text = updateRec.applicationUrl;
            }
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string[] inputData = { txtApplicationUpdate.Text.Trim(), txtUsernameUpdate.Text.Trim(), txtPasswordUpdate.Text.Trim(),
                                   txtApplicationUrlUpdate.Text.Trim(), txtNotesUpdate.Text.Trim() };

            this.iApplicationAccount.updateAccount(inputData);
            if (Utility.errorFlag == false)
            {
                text = "Updates to " + txtApplicationUpdate.Text + " made successfully.";
                Utility.showLabel(lblError, text, Color.Green);
            }
            else
            {
                text = "An error occurred while trying to update. \n Please try again.";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            if (txtPasswordUpdate.Text != string.Empty)
            {
                txtPasswordUpdate.Text = string.Empty;
                txtPasswordUpdate.Text = Utility.randomString(7);
            }
            else
                txtPasswordUpdate.Text = Utility.randomString(7);
        }
    }
}
