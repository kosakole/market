namespace Market.form
{
    partial class AdminApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminApp));
            this.buttonAuditBills = new System.Windows.Forms.Button();
            this.buttonWorkArticles = new System.Windows.Forms.Button();
            this.buttonAuditOrders = new System.Windows.Forms.Button();
            this.buttonWorkBills = new System.Windows.Forms.Button();
            this.buttonWorkEmployees = new System.Windows.Forms.Button();
            this.buttonAuditLogin = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonWorkOrders = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAuditBills
            // 
            this.buttonAuditBills.Location = new System.Drawing.Point(330, 69);
            this.buttonAuditBills.Name = "buttonAuditBills";
            this.buttonAuditBills.Size = new System.Drawing.Size(303, 78);
            this.buttonAuditBills.TabIndex = 1;
            this.buttonAuditBills.Text = "Audit bills";
            this.buttonAuditBills.UseVisualStyleBackColor = true;
            this.buttonAuditBills.Click += new System.EventHandler(this.buttonAuditBills_Click);
            // 
            // buttonWorkArticles
            // 
            this.buttonWorkArticles.Location = new System.Drawing.Point(21, 69);
            this.buttonWorkArticles.Name = "buttonWorkArticles";
            this.buttonWorkArticles.Size = new System.Drawing.Size(300, 78);
            this.buttonWorkArticles.TabIndex = 0;
            this.buttonWorkArticles.Text = "Work with articles";
            this.buttonWorkArticles.UseVisualStyleBackColor = true;
            this.buttonWorkArticles.Click += new System.EventHandler(this.buttonWorkArticles_Click);
            // 
            // buttonAuditOrders
            // 
            this.buttonAuditOrders.Location = new System.Drawing.Point(330, 153);
            this.buttonAuditOrders.Name = "buttonAuditOrders";
            this.buttonAuditOrders.Size = new System.Drawing.Size(303, 78);
            this.buttonAuditOrders.TabIndex = 3;
            this.buttonAuditOrders.Text = "Audit orders";
            this.buttonAuditOrders.UseVisualStyleBackColor = true;
            this.buttonAuditOrders.Click += new System.EventHandler(this.buttonAuditArticles_Click);
            // 
            // buttonWorkBills
            // 
            this.buttonWorkBills.Location = new System.Drawing.Point(21, 321);
            this.buttonWorkBills.Name = "buttonWorkBills";
            this.buttonWorkBills.Size = new System.Drawing.Size(300, 78);
            this.buttonWorkBills.TabIndex = 7;
            this.buttonWorkBills.Text = "Work with biils";
            this.buttonWorkBills.UseVisualStyleBackColor = true;
            this.buttonWorkBills.Visible = false;
            this.buttonWorkBills.Click += new System.EventHandler(this.buttonWorkBills_Click);
            // 
            // buttonWorkEmployees
            // 
            this.buttonWorkEmployees.Location = new System.Drawing.Point(21, 237);
            this.buttonWorkEmployees.Name = "buttonWorkEmployees";
            this.buttonWorkEmployees.Size = new System.Drawing.Size(300, 78);
            this.buttonWorkEmployees.TabIndex = 4;
            this.buttonWorkEmployees.Text = "Work with employees";
            this.buttonWorkEmployees.UseVisualStyleBackColor = true;
            this.buttonWorkEmployees.Click += new System.EventHandler(this.buttonWorkEmployees_Click);
            // 
            // buttonAuditLogin
            // 
            this.buttonAuditLogin.Location = new System.Drawing.Point(330, 237);
            this.buttonAuditLogin.Name = "buttonAuditLogin";
            this.buttonAuditLogin.Size = new System.Drawing.Size(303, 78);
            this.buttonAuditLogin.TabIndex = 5;
            this.buttonAuditLogin.Text = "Audit login";
            this.buttonAuditLogin.UseVisualStyleBackColor = true;
            this.buttonAuditLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(574, 12);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(59, 50);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonWorkOrders
            // 
            this.buttonWorkOrders.Location = new System.Drawing.Point(21, 153);
            this.buttonWorkOrders.Name = "buttonWorkOrders";
            this.buttonWorkOrders.Size = new System.Drawing.Size(300, 78);
            this.buttonWorkOrders.TabIndex = 2;
            this.buttonWorkOrders.Text = "Work with orders";
            this.buttonWorkOrders.UseVisualStyleBackColor = true;
            this.buttonWorkOrders.Click += new System.EventHandler(this.buttonWorkOrders_Click);
            // 
            // AdminApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 334);
            this.Controls.Add(this.buttonWorkOrders);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonAuditLogin);
            this.Controls.Add(this.buttonWorkEmployees);
            this.Controls.Add(this.buttonWorkBills);
            this.Controls.Add(this.buttonAuditOrders);
            this.Controls.Add(this.buttonWorkArticles);
            this.Controls.Add(this.buttonAuditBills);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(675, 381);
            this.MinimumSize = new System.Drawing.Size(675, 381);
            this.Name = "AdminApp";
            this.Text = "AdminApp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAuditBills;
        private System.Windows.Forms.Button buttonWorkArticles;
        private System.Windows.Forms.Button buttonAuditOrders;
        private System.Windows.Forms.Button buttonWorkBills;
        private System.Windows.Forms.Button buttonWorkEmployees;
        private System.Windows.Forms.Button buttonAuditLogin;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonWorkOrders;
    }
}