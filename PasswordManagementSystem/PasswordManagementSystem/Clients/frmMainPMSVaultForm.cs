using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordManagementSystem.Entities;
using PasswordManagementSystem.Interfaces;
using PasswordManagementSystem.Utilities;
using System.Configuration;
using System.Data.SqlClient;
using PasswordManagementSystem.Repositories;
using System.Diagnostics;
using PasswordManagementSystem.Entities.DataContext;
using Microsoft.VisualBasic;

namespace PasswordManagementSystem
{
    public partial class frmMainPMSVaultForm : Form
    {
        private IApplicationAccounts iApplicationAccount;
        private BindingList<AccountVaultEntity> gridList;
        private string text = string.Empty;
        private Crypto encryptObj;
        private bool isDeleteAll = false;
        private int gridRow = 0;

        //This data would typically be required as user input in registration form. Encrypt and stored in UserData table in the db then compare against user input
        //Hardcoded for demo purposes
        private long IDNum = 8801445252854; 

        public frmMainPMSVaultForm(IApplicationAccounts _iApplicationAccount)
        {
            InitializeComponent();
            this.iApplicationAccount = _iApplicationAccount; //Injecting dependency to the ApplicationAccount object
            encryptObj = new Crypto();
            this.gridList = new BindingList<AccountVaultEntity>();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (txtApplication.Text == string.Empty ||
                txtUsername.Text == string.Empty ||
                txtPassword.Text == string.Empty)
            {
                text = "Please ensure that you have filled out all the fields";
                Utility.showLabel(lblError, text, Color.Red);
            }
            else
            {
                string[] inputData = new string[] { };

                //Performing user input validation
                if (txtApplicationUrl.Text != string.Empty && txtNotes.Text != string.Empty)
                {
                    inputData = new string[]{ txtApplication.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(),
                                   txtApplicationUrl.Text.Trim(), txtNotes.Text.Trim()};
                    Utility.allFieldsEntered = true;
                }
                else if (txtApplicationUrl.Text == string.Empty && txtNotes.Text == string.Empty)
                {
                    inputData = new string[] { txtApplication.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim() };
                    Utility.bothFieldsEmpty = true;
                }
                else if (txtApplicationUrl.Text == string.Empty && txtNotes.Text != string.Empty)
                {
                    inputData = new string[] { txtApplication.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNotes.Text.Trim() };
                    Utility.isNotesFieldEmpty = true;
                }
                else if (txtApplicationUrl.Text != string.Empty && txtNotes.Text == string.Empty)
                {
                    inputData = new string[] { txtApplication.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtApplicationUrl.Text.Trim() };
                    Utility.isApplicationUrlFieldEmpty = true;
                }

                this.iApplicationAccount.addAcccount(inputData);
                frmMainPMSVaultForm_Load(null, null); //Refresh the form again after fetching data from the db

                clearFields();
            }
        }

        //Method to clear user input after account has been successfully added
        private void clearFields()
        {
            txtApplication.Text = string.Empty;
            txtApplicationUrl.Text = string.Empty;
            txtNotes.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsername.Text = string.Empty;
        }

        private void frmMainPMSVaultForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.HelpButton = true;
            this.AutoSize = true;

            //Check if there are any records. 
            //If none there is is no need to refresh the form because there is no data to populate
            if (getApplicationAccounts() >= 1)
                populateGrid();
            else if (isDeleteAll == true)
                populateGrid();
        }


        //Retrieve and populate data grid view with list of stored accounts from the db
        private void populateGrid()
        {
            if (Utility.isRefresh == false)
            {
                gridList = new BindingList<AccountVaultEntity>(Utility.decryptedAccountsVaultList);
                if (gridList != null && gridList.Count > 0)
                    applicationAccountsGrid.DataSource = gridList;
            }
            else
            {
                if (Utility.decryptedAccountsVaultList.Count == 0 || Utility.decryptedAccountsVaultList == null)
                {
                    this.iApplicationAccount.refreshData();
                    gridList = new BindingList<AccountVaultEntity>(Utility.decryptedAccountsVaultList);
                    applicationAccountsGrid.DataSource = gridList;
                }
            }

        }

        //This method determines whether the form needs to perform a refresh
        public int getApplicationAccounts()
        {
            int returnVal = 0;
            using (SqlConnection con = new SqlConnection(Utility.connectionString))
            {
                SqlCommand cmd = new SqlCommand("select Count(*) from AccountsVault", con);
                con.Open();
                returnVal = (int)cmd.ExecuteScalar();
                return returnVal;
            }
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty)
            {
                txtPassword.Text = string.Empty;
                txtPassword.Text = Utility.randomString(7);
            }
            else
                txtPassword.Text = Utility.randomString(7);
        }

        private string getIDNumberInput()
        {
            string userInput = Interaction.InputBox("Please enter your South African ID Number in order to authorize delete access", "Delete Permissions");
            return userInput;
        }

        private void btnDeleteRecords_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt64(getIDNumberInput()) == IDNum)
            {
                //int ID = applicationAccountsGrid.SelectedRows[0].Index;

                int ID = applicationAccountsGrid.CurrentCell.RowIndex + 1; //Rowndex is zero index based
                var listItem = gridList.FirstOrDefault(x => x.Id == ID);

                if (listItem != null)
                    gridList.Remove(listItem);

                this.iApplicationAccount.deleteSelectedAccount(ID);
                gridList = null;
                frmMainPMSVaultForm_Load(null, null);

                text = listItem.applicationName + " deleted!";
                Utility.showLabel(lblError, text, Color.OrangeRed);
            }
            else
            {
                text = "The ID Number you have entered does not \n match with the one stored on record.";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblError.Text != string.Empty)
                lblError.Text = string.Empty;

            if (Convert.ToInt64(getIDNumberInput()) == IDNum)
            {
                isDeleteAll = true;
                int counter = dataGridViewRows().Count;

                foreach (var index in dataGridViewRows().ToList())
                {
                    AccountVaultEntity listItem = gridList.FirstOrDefault(x => x.Id == index);
                    if (listItem != null)
                        gridList.Remove(listItem);
                }

                this.iApplicationAccount.deleteAllAccounts();
                frmMainPMSVaultForm_Load(null, null);
            }
            else
            {
                text = "The ID Number you have entered does not \n match with the one stored on record.";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }

        private void btnUpdateSelected_Click(object sender, EventArgs e)
        {

            AccountVaultEntity itemToEdit = new AccountVaultEntity();
            if (gridRow != 0)
            {
                itemToEdit = gridList.FirstOrDefault(x => x.Id == gridRow);
                if (itemToEdit != null)
                    Utility.updateRec = itemToEdit;

                frmUpdateAppVaultAccount updateForm = new frmUpdateAppVaultAccount(new ApplicationAccounts());
                updateForm.Show();
            }
        }

        private void btnCopyData_Click(object sender, EventArgs e)
        {
            if (applicationAccountsGrid.SelectedCells.Count >= 1)
            {
                Clipboard.SetDataObject(this.applicationAccountsGrid.GetClipboardContent());
                text = "Data copied!";
                Utility.showLabel(lblError, text, Color.Green);
                MessageBox.Show(text);
            }
            else
            {
                text = "You must select at least 1 box or at least 1 row.";
                Utility.showLabel(lblError, text, Color.Red);
            }
        }

        private List<int> dataGridViewRows()
        {
            List<int> returnVal = new List<int>();
            if (applicationAccountsGrid != null)
            {
                foreach (DataGridViewRow item in applicationAccountsGrid.Rows)
                    returnVal.Add(item.Index);
            }
            return returnVal;
        }

        private void applicationAccountsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int val = applicationAccountsGrid.CurrentCell.RowIndex + 1;
                gridRow = Convert.ToInt32(val);
                Utility.appVaultID = gridRow;
            }
        }

        private void btnRefreshData_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            Utility.isRefresh = true;
            foreach (var index in dataGridViewRows().ToList())
            {
                AccountVaultEntity listItem = gridList.FirstOrDefault(x => x.Id == index);
                if (listItem != null)
                    gridList.Remove(listItem);
            }

            populateGrid();
        }
    }
}
