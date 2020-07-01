namespace PasswordManagementSystem
{
    partial class frmUpdateAppVaultAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateAppVaultAccount));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblApplicationUrl = new System.Windows.Forms.Label();
            this.txtApplicationUrlUpdate = new System.Windows.Forms.TextBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.txtNotesUpdate = new System.Windows.Forms.RichTextBox();
            this.txtApplicationUpdate = new System.Windows.Forms.TextBox();
            this.txtUsernameUpdate = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnUpdateAccount = new System.Windows.Forms.Button();
            this.txtPasswordUpdate = new System.Windows.Forms.MaskedTextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(431, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(261, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 49;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(132, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "*";
            // 
            // lblApplicationUrl
            // 
            this.lblApplicationUrl.AutoSize = true;
            this.lblApplicationUrl.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblApplicationUrl.Location = new System.Drawing.Point(9, 162);
            this.lblApplicationUrl.Name = "lblApplicationUrl";
            this.lblApplicationUrl.Size = new System.Drawing.Size(167, 19);
            this.lblApplicationUrl.TabIndex = 47;
            this.lblApplicationUrl.Text = "Application Url (Optional):";
            // 
            // txtApplicationUrlUpdate
            // 
            this.txtApplicationUrlUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationUrlUpdate.Location = new System.Drawing.Point(12, 184);
            this.txtApplicationUrlUpdate.Name = "txtApplicationUrlUpdate";
            this.txtApplicationUrlUpdate.Size = new System.Drawing.Size(517, 30);
            this.txtApplicationUrlUpdate.TabIndex = 46;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(535, 50);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(178, 32);
            this.btnGeneratePassword.TabIndex = 45;
            this.btnGeneratePassword.Text = "Generate Password";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblApplicationName.Location = new System.Drawing.Point(9, 28);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(117, 19);
            this.lblApplicationName.TabIndex = 38;
            this.lblApplicationName.Text = "Application Name";
            // 
            // txtNotesUpdate
            // 
            this.txtNotesUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotesUpdate.Location = new System.Drawing.Point(12, 102);
            this.txtNotesUpdate.Name = "txtNotesUpdate";
            this.txtNotesUpdate.Size = new System.Drawing.Size(521, 51);
            this.txtNotesUpdate.TabIndex = 41;
            this.txtNotesUpdate.Text = "";
            // 
            // txtApplicationUpdate
            // 
            this.txtApplicationUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationUpdate.Location = new System.Drawing.Point(8, 50);
            this.txtApplicationUpdate.Name = "txtApplicationUpdate";
            this.txtApplicationUpdate.Size = new System.Drawing.Size(170, 30);
            this.txtApplicationUpdate.TabIndex = 39;
            // 
            // txtUsernameUpdate
            // 
            this.txtUsernameUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameUpdate.Location = new System.Drawing.Point(184, 50);
            this.txtUsernameUpdate.Name = "txtUsernameUpdate";
            this.txtUsernameUpdate.Size = new System.Drawing.Size(170, 30);
            this.txtUsernameUpdate.TabIndex = 43;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPassword.Location = new System.Drawing.Point(357, 28);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 19);
            this.lblPassword.TabIndex = 37;
            this.lblPassword.Text = "Password";
            // 
            // btnUpdateAccount
            // 
            this.btnUpdateAccount.Location = new System.Drawing.Point(13, 220);
            this.btnUpdateAccount.Name = "btnUpdateAccount";
            this.btnUpdateAccount.Size = new System.Drawing.Size(292, 32);
            this.btnUpdateAccount.TabIndex = 44;
            this.btnUpdateAccount.Text = "Update Account";
            this.btnUpdateAccount.UseVisualStyleBackColor = true;
            this.btnUpdateAccount.Click += new System.EventHandler(this.btnUpdateAccount_Click);
            // 
            // txtPasswordUpdate
            // 
            this.txtPasswordUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordUpdate.Location = new System.Drawing.Point(360, 50);
            this.txtPasswordUpdate.Name = "txtPasswordUpdate";
            this.txtPasswordUpdate.PasswordChar = '*';
            this.txtPasswordUpdate.Size = new System.Drawing.Size(169, 30);
            this.txtPasswordUpdate.TabIndex = 40;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblUsername.Location = new System.Drawing.Point(184, 28);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 19);
            this.lblUsername.TabIndex = 42;
            this.lblUsername.Text = "Username";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNotes.Location = new System.Drawing.Point(9, 83);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(107, 19);
            this.lblNotes.TabIndex = 36;
            this.lblNotes.Text = "Notes (optional)";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(13, 259);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(46, 17);
            this.lblError.TabIndex = 51;
            this.lblError.Text = "label4";
            this.lblError.Visible = false;
            // 
            // frmUpdateAppVaultAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 283);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblApplicationUrl);
            this.Controls.Add(this.txtApplicationUrlUpdate);
            this.Controls.Add(this.btnGeneratePassword);
            this.Controls.Add(this.lblApplicationName);
            this.Controls.Add(this.txtNotesUpdate);
            this.Controls.Add(this.txtApplicationUpdate);
            this.Controls.Add(this.txtUsernameUpdate);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.btnUpdateAccount);
            this.Controls.Add(this.txtPasswordUpdate);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpdateAppVaultAccount";
            this.Text = "Update App Account";
            this.Load += new System.EventHandler(this.frmUpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblApplicationUrl;
        private System.Windows.Forms.TextBox txtApplicationUrlUpdate;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.RichTextBox txtNotesUpdate;
        private System.Windows.Forms.TextBox txtApplicationUpdate;
        private System.Windows.Forms.TextBox txtUsernameUpdate;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnUpdateAccount;
        private System.Windows.Forms.MaskedTextBox txtPasswordUpdate;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblError;
    }
}