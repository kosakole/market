namespace Market.form
{
    partial class ShowBill
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
            this.labelID = new System.Windows.Forms.Label();
            this.labelEmployee = new System.Windows.Forms.Label();
            this.labelCashDesk = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.labelIDValue = new System.Windows.Forms.Label();
            this.labelDateValue = new System.Windows.Forms.Label();
            this.labelEmployeeValue = new System.Windows.Forms.Label();
            this.labelCashDeskValue = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTotalValue = new System.Windows.Forms.Label();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(12, 21);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(23, 16);
            this.labelID.TabIndex = 0;
            this.labelID.Text = "ID:";
            // 
            // labelEmployee
            // 
            this.labelEmployee.AutoSize = true;
            this.labelEmployee.Location = new System.Drawing.Point(12, 93);
            this.labelEmployee.Name = "labelEmployee";
            this.labelEmployee.Size = new System.Drawing.Size(72, 16);
            this.labelEmployee.TabIndex = 1;
            this.labelEmployee.Text = "Employee:";
            // 
            // labelCashDesk
            // 
            this.labelCashDesk.AutoSize = true;
            this.labelCashDesk.Location = new System.Drawing.Point(12, 129);
            this.labelCashDesk.Name = "labelCashDesk";
            this.labelCashDesk.Size = new System.Drawing.Size(74, 16);
            this.labelCashDesk.TabIndex = 2;
            this.labelCashDesk.Text = "Cash desk:";
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Location = new System.Drawing.Point(12, 55);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(39, 16);
            this.labelDateTime.TabIndex = 3;
            this.labelDateTime.Text = "Date:";
            // 
            // labelIDValue
            // 
            this.labelIDValue.AutoSize = true;
            this.labelIDValue.Location = new System.Drawing.Point(111, 21);
            this.labelIDValue.Name = "labelIDValue";
            this.labelIDValue.Size = new System.Drawing.Size(35, 16);
            this.labelIDValue.TabIndex = 4;
            this.labelIDValue.Text = "1111";
            // 
            // labelDateValue
            // 
            this.labelDateValue.AutoSize = true;
            this.labelDateValue.Location = new System.Drawing.Point(111, 55);
            this.labelDateValue.Name = "labelDateValue";
            this.labelDateValue.Size = new System.Drawing.Size(57, 16);
            this.labelDateValue.TabIndex = 5;
            this.labelDateValue.Text = "1/2/2022";
            // 
            // labelEmployeeValue
            // 
            this.labelEmployeeValue.AutoSize = true;
            this.labelEmployeeValue.Location = new System.Drawing.Point(111, 93);
            this.labelEmployeeValue.Name = "labelEmployeeValue";
            this.labelEmployeeValue.Size = new System.Drawing.Size(33, 16);
            this.labelEmployeeValue.TabIndex = 6;
            this.labelEmployeeValue.Text = "kole";
            // 
            // labelCashDeskValue
            // 
            this.labelCashDeskValue.AutoSize = true;
            this.labelCashDeskValue.Location = new System.Drawing.Point(111, 129);
            this.labelCashDeskValue.Name = "labelCashDeskValue";
            this.labelCashDeskValue.Size = new System.Drawing.Size(14, 16);
            this.labelCashDeskValue.TabIndex = 7;
            this.labelCashDeskValue.Text = "2";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.NameC,
            this.Price,
            this.Amount,
            this.Total});
            this.dataGridView.Location = new System.Drawing.Point(12, 173);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(776, 243);
            this.dataGridView.TabIndex = 8;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(648, 430);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(41, 16);
            this.labelTotal.TabIndex = 9;
            this.labelTotal.Text = "Total:";
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalValue.AutoSize = true;
            this.labelTotalValue.Location = new System.Drawing.Point(695, 430);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(24, 16);
            this.labelTotalValue.TabIndex = 10;
            this.labelTotalValue.Text = "0,0";
            // 
            // Barcode
            // 
            this.Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 6;
            this.Barcode.Name = "Barcode";
            // 
            // NameC
            // 
            this.NameC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameC.HeaderText = "Name";
            this.NameC.MinimumWidth = 6;
            this.NameC.Name = "NameC";
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Amount.HeaderText = "Amout";
            this.Amount.MinimumWidth = 6;
            this.Amount.Name = "Amount";
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            // 
            // ShowBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTotalValue);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.labelCashDeskValue);
            this.Controls.Add(this.labelEmployeeValue);
            this.Controls.Add(this.labelDateValue);
            this.Controls.Add(this.labelIDValue);
            this.Controls.Add(this.labelDateTime);
            this.Controls.Add(this.labelCashDesk);
            this.Controls.Add(this.labelEmployee);
            this.Controls.Add(this.labelID);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ShowBill";
            this.Text = "Show bill";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelEmployee;
        private System.Windows.Forms.Label labelCashDesk;
        private System.Windows.Forms.Label labelDateTime;
        private System.Windows.Forms.Label labelIDValue;
        private System.Windows.Forms.Label labelDateValue;
        private System.Windows.Forms.Label labelEmployeeValue;
        private System.Windows.Forms.Label labelCashDeskValue;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}