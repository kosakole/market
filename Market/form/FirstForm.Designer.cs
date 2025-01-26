namespace Market.form
{
    partial class FirstForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstForm));
            this.buttonEmployee = new System.Windows.Forms.Button();
            this.buttonAdmin = new System.Windows.Forms.Button();
            this.buttonSttings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEmployee
            // 
            this.buttonEmployee.Location = new System.Drawing.Point(12, 156);
            this.buttonEmployee.Name = "buttonEmployee";
            this.buttonEmployee.Size = new System.Drawing.Size(392, 81);
            this.buttonEmployee.TabIndex = 1;
            this.buttonEmployee.Text = "Employee";
            this.buttonEmployee.UseVisualStyleBackColor = true;
            this.buttonEmployee.Click += new System.EventHandler(this.buttonEmployee_Click);
            // 
            // buttonAdmin
            // 
            this.buttonAdmin.Location = new System.Drawing.Point(12, 69);
            this.buttonAdmin.Name = "buttonAdmin";
            this.buttonAdmin.Size = new System.Drawing.Size(392, 81);
            this.buttonAdmin.TabIndex = 0;
            this.buttonAdmin.Text = "Admin";
            this.buttonAdmin.UseVisualStyleBackColor = true;
            this.buttonAdmin.Click += new System.EventHandler(this.buttonAdmin_Click);
            // 
            // buttonSttings
            // 
            this.buttonSttings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSttings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSttings.Image")));
            this.buttonSttings.Location = new System.Drawing.Point(345, 12);
            this.buttonSttings.Name = "buttonSttings";
            this.buttonSttings.Size = new System.Drawing.Size(59, 50);
            this.buttonSttings.TabIndex = 2;
            this.buttonSttings.UseVisualStyleBackColor = false;
            this.buttonSttings.Click += new System.EventHandler(this.buttonSttings_Click);
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 249);
            this.Controls.Add(this.buttonSttings);
            this.Controls.Add(this.buttonAdmin);
            this.Controls.Add(this.buttonEmployee);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(434, 296);
            this.MinimumSize = new System.Drawing.Size(434, 296);
            this.Name = "FirstForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEmployee;
        private System.Windows.Forms.Button buttonAdmin;
        private System.Windows.Forms.Button buttonSttings;
    }
}