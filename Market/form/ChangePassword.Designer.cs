namespace Market.form
{
    partial class ChangePassword
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
            this.labelNewPass1 = new System.Windows.Forms.Label();
            this.labelNewPass2 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelIDValue = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelUsernameValue = new System.Windows.Forms.Label();
            this.textBoxNewPass1 = new System.Windows.Forms.TextBox();
            this.textBoxNewPass2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelNewPass1
            // 
            this.labelNewPass1.AutoSize = true;
            this.labelNewPass1.Location = new System.Drawing.Point(12, 104);
            this.labelNewPass1.Name = "labelNewPass1";
            this.labelNewPass1.Size = new System.Drawing.Size(96, 16);
            this.labelNewPass1.TabIndex = 2;
            this.labelNewPass1.Text = "New password";
            // 
            // labelNewPass2
            // 
            this.labelNewPass2.AutoSize = true;
            this.labelNewPass2.Location = new System.Drawing.Point(12, 154);
            this.labelNewPass2.Name = "labelNewPass2";
            this.labelNewPass2.Size = new System.Drawing.Size(52, 16);
            this.labelNewPass2.TabIndex = 3;
            this.labelNewPass2.Text = "Confirm";
            // 
            // buttonChange
            // 
            this.buttonChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChange.Location = new System.Drawing.Point(279, 206);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(115, 53);
            this.buttonChange.TabIndex = 8;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 21);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(50, 16);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "User id";
            // 
            // labelIDValue
            // 
            this.labelIDValue.AutoSize = true;
            this.labelIDValue.Location = new System.Drawing.Point(133, 21);
            this.labelIDValue.Name = "labelIDValue";
            this.labelIDValue.Size = new System.Drawing.Size(98, 16);
            this.labelIDValue.TabIndex = 4;
            this.labelIDValue.Text = "0000000000000";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(12, 63);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(70, 16);
            this.labelUsername.TabIndex = 1;
            this.labelUsername.Text = "Username";
            // 
            // labelUsernameValue
            // 
            this.labelUsernameValue.AutoSize = true;
            this.labelUsernameValue.Location = new System.Drawing.Point(133, 63);
            this.labelUsernameValue.Name = "labelUsernameValue";
            this.labelUsernameValue.Size = new System.Drawing.Size(31, 16);
            this.labelUsernameValue.TabIndex = 5;
            this.labelUsernameValue.Text = "zoki";
            // 
            // textBoxNewPass1
            // 
            this.textBoxNewPass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPass1.Location = new System.Drawing.Point(136, 104);
            this.textBoxNewPass1.Name = "textBoxNewPass1";
            this.textBoxNewPass1.PasswordChar = '*';
            this.textBoxNewPass1.Size = new System.Drawing.Size(258, 22);
            this.textBoxNewPass1.TabIndex = 6;
            // 
            // textBoxNewPass2
            // 
            this.textBoxNewPass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewPass2.Location = new System.Drawing.Point(136, 154);
            this.textBoxNewPass2.Name = "textBoxNewPass2";
            this.textBoxNewPass2.PasswordChar = '*';
            this.textBoxNewPass2.Size = new System.Drawing.Size(258, 22);
            this.textBoxNewPass2.TabIndex = 7;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 298);
            this.Controls.Add(this.textBoxNewPass2);
            this.Controls.Add(this.textBoxNewPass1);
            this.Controls.Add(this.labelUsernameValue);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelIDValue);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.labelNewPass2);
            this.Controls.Add(this.labelNewPass1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 345);
            this.MinimumSize = new System.Drawing.Size(453, 345);
            this.Name = "ChangePassword";
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelNewPass1;
        private System.Windows.Forms.Label labelNewPass2;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelIDValue;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelUsernameValue;
        private System.Windows.Forms.TextBox textBoxNewPass1;
        private System.Windows.Forms.TextBox textBoxNewPass2;
    }
}