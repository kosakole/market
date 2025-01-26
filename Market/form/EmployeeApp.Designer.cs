namespace Market.form
{
    partial class EmployeeApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeApp));
            this.buttonCreateBill = new System.Windows.Forms.Button();
            this.buttonAuditBills = new System.Windows.Forms.Button();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateBill
            // 
            this.buttonCreateBill.Location = new System.Drawing.Point(12, 12);
            this.buttonCreateBill.Name = "buttonCreateBill";
            this.buttonCreateBill.Size = new System.Drawing.Size(340, 88);
            this.buttonCreateBill.TabIndex = 0;
            this.buttonCreateBill.Text = "Create bill";
            this.buttonCreateBill.UseVisualStyleBackColor = true;
            this.buttonCreateBill.Click += new System.EventHandler(this.buttonCreateBill_Click);
            // 
            // buttonAuditBills
            // 
            this.buttonAuditBills.Location = new System.Drawing.Point(12, 106);
            this.buttonAuditBills.Name = "buttonAuditBills";
            this.buttonAuditBills.Size = new System.Drawing.Size(340, 88);
            this.buttonAuditBills.TabIndex = 2;
            this.buttonAuditBills.Text = "Audit bills";
            this.buttonAuditBills.UseVisualStyleBackColor = true;
            this.buttonAuditBills.Click += new System.EventHandler(this.buttonAuditBills_Click);
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.Location = new System.Drawing.Point(358, 12);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(340, 88);
            this.buttonChangePassword.TabIndex = 1;
            this.buttonChangePassword.Text = "Change password";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.buttonChangePassword_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(358, 106);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(340, 88);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // EmployeeApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 229);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.buttonAuditBills);
            this.Controls.Add(this.buttonCreateBill);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(737, 276);
            this.MinimumSize = new System.Drawing.Size(737, 276);
            this.Name = "EmployeeApp";
            this.Text = "EmployeeApp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateBill;
        private System.Windows.Forms.Button buttonAuditBills;
        private System.Windows.Forms.Button buttonChangePassword;
        private System.Windows.Forms.Button buttonSettings;
    }
}