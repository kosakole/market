namespace Market.form
{
    partial class CreateOrder
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
            this.labelBarcode = new System.Windows.Forms.Label();
            this.labelAmount = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.dataGridViewArticles = new System.Windows.Forms.DataGridView();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewArticlesOrder = new System.Windows.Forms.DataGridView();
            this.barcodeOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelTotalValue = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelDeliverer = new System.Windows.Forms.Label();
            this.comboBoxDeliverer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticlesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // labelBarcode
            // 
            this.labelBarcode.AutoSize = true;
            this.labelBarcode.Location = new System.Drawing.Point(9, 18);
            this.labelBarcode.Name = "labelBarcode";
            this.labelBarcode.Size = new System.Drawing.Size(59, 16);
            this.labelBarcode.TabIndex = 0;
            this.labelBarcode.Text = "Barcode";
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Location = new System.Drawing.Point(9, 46);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(52, 16);
            this.labelAmount.TabIndex = 1;
            this.labelAmount.Text = "Amount";
            // 
            // textBoxBarcode
            // 
            this.textBoxBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBarcode.Location = new System.Drawing.Point(94, 12);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.Size = new System.Drawing.Size(320, 22);
            this.textBoxBarcode.TabIndex = 2;
            this.textBoxBarcode.TextChanged += new System.EventHandler(this.textBoxBarcode_TextChanged);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount.Location = new System.Drawing.Point(94, 40);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(320, 22);
            this.textBoxAmount.TabIndex = 3;
            // 
            // dataGridViewArticles
            // 
            this.dataGridViewArticles.AllowUserToAddRows = false;
            this.dataGridViewArticles.AllowUserToDeleteRows = false;
            this.dataGridViewArticles.AllowUserToResizeColumns = false;
            this.dataGridViewArticles.AllowUserToResizeRows = false;
            this.dataGridViewArticles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewArticles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewArticles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcode,
            this.name,
            this.Price,
            this.amount});
            this.dataGridViewArticles.Location = new System.Drawing.Point(12, 78);
            this.dataGridViewArticles.Name = "dataGridViewArticles";
            this.dataGridViewArticles.ReadOnly = true;
            this.dataGridViewArticles.RowHeadersVisible = false;
            this.dataGridViewArticles.RowHeadersWidth = 51;
            this.dataGridViewArticles.RowTemplate.Height = 24;
            this.dataGridViewArticles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArticles.Size = new System.Drawing.Size(402, 388);
            this.dataGridViewArticles.TabIndex = 4;
            // 
            // barcode
            // 
            this.barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.barcode.HeaderText = "Barcode";
            this.barcode.MinimumWidth = 6;
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amount.HeaderText = "Amount";
            this.amount.MinimumWidth = 6;
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // dataGridViewArticlesOrder
            // 
            this.dataGridViewArticlesOrder.AllowUserToAddRows = false;
            this.dataGridViewArticlesOrder.AllowUserToDeleteRows = false;
            this.dataGridViewArticlesOrder.AllowUserToResizeColumns = false;
            this.dataGridViewArticlesOrder.AllowUserToResizeRows = false;
            this.dataGridViewArticlesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewArticlesOrder.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewArticlesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArticlesOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barcodeOrder,
            this.nameOrder,
            this.priceOrder,
            this.amountOrder,
            this.total});
            this.dataGridViewArticlesOrder.Location = new System.Drawing.Point(593, 78);
            this.dataGridViewArticlesOrder.Name = "dataGridViewArticlesOrder";
            this.dataGridViewArticlesOrder.ReadOnly = true;
            this.dataGridViewArticlesOrder.RowHeadersVisible = false;
            this.dataGridViewArticlesOrder.RowHeadersWidth = 51;
            this.dataGridViewArticlesOrder.RowTemplate.Height = 24;
            this.dataGridViewArticlesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArticlesOrder.Size = new System.Drawing.Size(432, 388);
            this.dataGridViewArticlesOrder.TabIndex = 5;
            // 
            // barcodeOrder
            // 
            this.barcodeOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.barcodeOrder.HeaderText = "Barcode";
            this.barcodeOrder.MinimumWidth = 6;
            this.barcodeOrder.Name = "barcodeOrder";
            this.barcodeOrder.ReadOnly = true;
            // 
            // nameOrder
            // 
            this.nameOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameOrder.HeaderText = "Name";
            this.nameOrder.MinimumWidth = 6;
            this.nameOrder.Name = "nameOrder";
            this.nameOrder.ReadOnly = true;
            // 
            // priceOrder
            // 
            this.priceOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceOrder.HeaderText = "Price";
            this.priceOrder.MinimumWidth = 6;
            this.priceOrder.Name = "priceOrder";
            this.priceOrder.ReadOnly = true;
            // 
            // amountOrder
            // 
            this.amountOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amountOrder.HeaderText = "Amount";
            this.amountOrder.MinimumWidth = 6;
            this.amountOrder.Name = "amountOrder";
            this.amountOrder.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total.HeaderText = "Price total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(893, 488);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(41, 16);
            this.labelTotal.TabIndex = 6;
            this.labelTotal.Text = "Total:";
            // 
            // labelTotalValue
            // 
            this.labelTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalValue.AutoSize = true;
            this.labelTotalValue.Location = new System.Drawing.Point(964, 488);
            this.labelTotalValue.Name = "labelTotalValue";
            this.labelTotalValue.Size = new System.Drawing.Size(24, 16);
            this.labelTotalValue.TabIndex = 7;
            this.labelTotalValue.Text = "0.0";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAdd.ForeColor = System.Drawing.Color.Lime;
            this.buttonAdd.Location = new System.Drawing.Point(451, 246);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(113, 62);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = ">>";
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttinAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDelete.ForeColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(593, 479);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(113, 34);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Location = new System.Drawing.Point(896, 18);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(129, 46);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // labelDeliverer
            // 
            this.labelDeliverer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeliverer.AutoSize = true;
            this.labelDeliverer.Location = new System.Drawing.Point(590, 18);
            this.labelDeliverer.Name = "labelDeliverer";
            this.labelDeliverer.Size = new System.Drawing.Size(62, 16);
            this.labelDeliverer.TabIndex = 6;
            this.labelDeliverer.Text = "Deliverer";
            // 
            // comboBoxDeliverer
            // 
            this.comboBoxDeliverer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxDeliverer.FormattingEnabled = true;
            this.comboBoxDeliverer.Location = new System.Drawing.Point(593, 40);
            this.comboBoxDeliverer.Name = "comboBoxDeliverer";
            this.comboBoxDeliverer.Size = new System.Drawing.Size(278, 24);
            this.comboBoxDeliverer.TabIndex = 7;
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 525);
            this.Controls.Add(this.comboBoxDeliverer);
            this.Controls.Add(this.labelDeliverer);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelTotalValue);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.dataGridViewArticlesOrder);
            this.Controls.Add(this.dataGridViewArticles);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelBarcode);
            this.MinimumSize = new System.Drawing.Size(1030, 500);
            this.Name = "CreateOrder";
            this.Text = "Create order";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArticlesOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBarcode;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.DataGridView dataGridViewArticles;
        private System.Windows.Forms.DataGridView dataGridViewArticlesOrder;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelTotalValue;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.Label labelDeliverer;
        private System.Windows.Forms.ComboBox comboBoxDeliverer;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}