namespace PasswordManagementSystem
{
    partial class frmMainPMSVaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainPMSVaultForm));
            this.gbxAccountInfo = new System.Windows.Forms.GroupBox();
            this.btnRefreshData = new System.Windows.Forms.Button();
            this.btnCopyData = new System.Windows.Forms.Button();
            this.btnGetRow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApplicationUrl = new System.Windows.Forms.Label();
            this.txtApplicationUrl = new System.Windows.Forms.TextBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnDeleteRecords = new System.Windows.Forms.Button();
            this.gbxStoredAccounts = new System.Windows.Forms.GroupBox();
            this.applicationAccountsGrid = new System.Windows.Forms.DataGridView();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.MaskedTextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.applicationAccountsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.utilityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbxAccountInfo.SuspendLayout();
            this.gbxStoredAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.applicationAccountsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationAccountsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxAccountInfo
            // 
            this.gbxAccountInfo.Controls.Add(this.btnRefreshData);
            this.gbxAccountInfo.Controls.Add(this.btnCopyData);
            this.gbxAccountInfo.Controls.Add(this.btnGetRow);
            this.gbxAccountInfo.Controls.Add(this.button1);
            this.gbxAccountInfo.Controls.Add(this.label3);
            this.gbxAccountInfo.Controls.Add(this.label2);
            this.gbxAccountInfo.Controls.Add(this.label1);
            this.gbxAccountInfo.Controls.Add(this.lblApplicationUrl);
            this.gbxAccountInfo.Controls.Add(this.txtApplicationUrl);
            this.gbxAccountInfo.Controls.Add(this.btnGeneratePassword);
            this.gbxAccountInfo.Controls.Add(this.lblError);
            this.gbxAccountInfo.Controls.Add(this.btnDeleteRecords);
            this.gbxAccountInfo.Controls.Add(this.gbxStoredAccounts);
            this.gbxAccountInfo.Controls.Add(this.lblApplicationName);
            this.gbxAccountInfo.Controls.Add(this.txtNotes);
            this.gbxAccountInfo.Controls.Add(this.txtApplication);
            this.gbxAccountInfo.Controls.Add(this.txtUsername);
            this.gbxAccountInfo.Controls.Add(this.lblPassword);
            this.gbxAccountInfo.Controls.Add(this.btnAddAccount);
            this.gbxAccountInfo.Controls.Add(this.txtPassword);
            this.gbxAccountInfo.Controls.Add(this.lblUsername);
            this.gbxAccountInfo.Controls.Add(this.lblNotes);
            this.gbxAccountInfo.Location = new System.Drawing.Point(13, 13);
            this.gbxAccountInfo.Name = "gbxAccountInfo";
            this.gbxAccountInfo.Size = new System.Drawing.Size(729, 768);
            this.gbxAccountInfo.TabIndex = 0;
            this.gbxAccountInfo.TabStop = false;
            this.gbxAccountInfo.Text = "Add New Account Information";
            // 
            // btnRefreshData
            // 
            this.btnRefreshData.Enabled = false;
            this.btnRefreshData.Location = new System.Drawing.Point(274, 718);
            this.btnRefreshData.Name = "btnRefreshData";
            this.btnRefreshData.Size = new System.Drawing.Size(157, 32);
            this.btnRefreshData.TabIndex = 40;
            this.btnRefreshData.Text = "Refresh Data";
            this.btnRefreshData.UseVisualStyleBackColor = true;
            this.btnRefreshData.Click += new System.EventHandler(this.btnRefreshData_Click);
            // 
            // btnCopyData
            // 
            this.btnCopyData.Location = new System.Drawing.Point(524, 669);
            this.btnCopyData.Name = "btnCopyData";
            this.btnCopyData.Size = new System.Drawing.Size(157, 32);
            this.btnCopyData.TabIndex = 39;
            this.btnCopyData.Text = "Copy Data";
            this.btnCopyData.UseVisualStyleBackColor = true;
            this.btnCopyData.Click += new System.EventHandler(this.btnCopyData_Click);
            // 
            // btnGetRow
            // 
            this.btnGetRow.Location = new System.Drawing.Point(35, 669);
            this.btnGetRow.Name = "btnGetRow";
            this.btnGetRow.Size = new System.Drawing.Size(157, 32);
            this.btnGetRow.TabIndex = 38;
            this.btnGetRow.Text = "Get Row";
            this.btnGetRow.UseVisualStyleBackColor = true;
            this.btnGetRow.Click += new System.EventHandler(this.btnUpdateSelected_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(361, 669);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 32);
            this.button1.TabIndex = 36;
            this.button1.Text = "Delete All";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(441, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 35;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(271, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(142, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "*";
            // 
            // lblApplicationUrl
            // 
            this.lblApplicationUrl.AutoSize = true;
            this.lblApplicationUrl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblApplicationUrl.Location = new System.Drawing.Point(19, 179);
            this.lblApplicationUrl.Name = "lblApplicationUrl";
            this.lblApplicationUrl.Size = new System.Drawing.Size(167, 19);
            this.lblApplicationUrl.TabIndex = 32;
            this.lblApplicationUrl.Text = "Application Url (Optional):";
            // 
            // txtApplicationUrl
            // 
            this.txtApplicationUrl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationUrl.Location = new System.Drawing.Point(22, 201);
            this.txtApplicationUrl.Name = "txtApplicationUrl";
            this.txtApplicationUrl.Size = new System.Drawing.Size(517, 30);
            this.txtApplicationUrl.TabIndex = 31;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(545, 67);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(178, 32);
            this.btnGeneratePassword.TabIndex = 30;
            this.btnGeneratePassword.Text = "Generate Password";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(20, 748);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(46, 17);
            this.lblError.TabIndex = 29;
            this.lblError.Text = "label1";
            this.lblError.Visible = false;
            // 
            // btnDeleteRecords
            // 
            this.btnDeleteRecords.Location = new System.Drawing.Point(198, 669);
            this.btnDeleteRecords.Name = "btnDeleteRecords";
            this.btnDeleteRecords.Size = new System.Drawing.Size(157, 32);
            this.btnDeleteRecords.TabIndex = 28;
            this.btnDeleteRecords.Text = "Delete Selected ";
            this.btnDeleteRecords.UseVisualStyleBackColor = true;
            this.btnDeleteRecords.Click += new System.EventHandler(this.btnDeleteRecords_Click);
            // 
            // gbxStoredAccounts
            // 
            this.gbxStoredAccounts.BackColor = System.Drawing.SystemColors.Control;
            this.gbxStoredAccounts.Controls.Add(this.applicationAccountsGrid);
            this.gbxStoredAccounts.Location = new System.Drawing.Point(23, 299);
            this.gbxStoredAccounts.Name = "gbxStoredAccounts";
            this.gbxStoredAccounts.Size = new System.Drawing.Size(678, 370);
            this.gbxStoredAccounts.TabIndex = 28;
            this.gbxStoredAccounts.TabStop = false;
            this.gbxStoredAccounts.Text = "Stored Accounts(s)";
            this.gbxStoredAccounts.UseCompatibleTextRendering = true;
            // 
            // applicationAccountsGrid
            // 
            this.applicationAccountsGrid.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.applicationAccountsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.applicationAccountsGrid.Location = new System.Drawing.Point(7, 22);
            this.applicationAccountsGrid.Name = "applicationAccountsGrid";
            this.applicationAccountsGrid.ReadOnly = true;
            this.applicationAccountsGrid.RowTemplate.Height = 24;
            this.applicationAccountsGrid.Size = new System.Drawing.Size(665, 342);
            this.applicationAccountsGrid.TabIndex = 0;
            this.applicationAccountsGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.applicationAccountsGrid_CellClick);
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblApplicationName.Location = new System.Drawing.Point(19, 45);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(117, 19);
            this.lblApplicationName.TabIndex = 8;
            this.lblApplicationName.Text = "Application Name";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(22, 119);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(521, 51);
            this.txtNotes.TabIndex = 11;
            this.txtNotes.Text = "";
            // 
            // txtApplication
            // 
            this.txtApplication.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplication.Location = new System.Drawing.Point(18, 67);
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(170, 30);
            this.txtApplication.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(194, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(170, 30);
            this.txtUsername.TabIndex = 14;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPassword.Location = new System.Drawing.Point(367, 45);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 19);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password";
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(23, 237);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(178, 32);
            this.btnAddAccount.TabIndex = 27;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(370, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(169, 30);
            this.txtPassword.TabIndex = 10;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblUsername.Location = new System.Drawing.Point(194, 45);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 19);
            this.lblUsername.TabIndex = 13;
            this.lblUsername.Text = "Username";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNotes.Location = new System.Drawing.Point(19, 100);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(107, 19);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes (optional)";
            // 
            // applicationAccountsBindingSource
            // 
            this.applicationAccountsBindingSource.DataSource = typeof(PasswordManagementSystem.Repositories.ApplicationAccounts);
            // 
            // utilityBindingSource
            // 
            this.utilityBindingSource.DataSource = typeof(PasswordManagementSystem.Utilities.Utility);
            // 
            // frmMainPMSVaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 795);
            this.Controls.Add(this.gbxAccountInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainPMSVaultForm";
            this.Text = "PMS Vault";
            this.Load += new System.EventHandler(this.frmMainPMSVaultForm_Load);
            this.gbxAccountInfo.ResumeLayout(false);
            this.gbxAccountInfo.PerformLayout();
            this.gbxStoredAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.applicationAccountsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationAccountsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxAccountInfo;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.MaskedTextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.RichTextBox txtNotes;
        private System.Windows.Forms.TextBox txtApplication;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.Button btnDeleteRecords;
        private System.Windows.Forms.GroupBox gbxStoredAccounts;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Label lblApplicationUrl;
        private System.Windows.Forms.TextBox txtApplicationUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource utilityBindingSource;
        private System.Windows.Forms.BindingSource applicationAccountsBindingSource;
        private System.Windows.Forms.DataGridView applicationAccountsGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGetRow;
        private System.Windows.Forms.Button btnCopyData;
        private System.Windows.Forms.Button btnRefreshData;
    }
}