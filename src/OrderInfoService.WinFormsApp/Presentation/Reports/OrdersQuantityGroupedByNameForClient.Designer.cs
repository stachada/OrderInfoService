namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class OrdersQuantityGroupedByNameForClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvGroupings = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderQuantityByNameDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cmbClientId = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityByNameDtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ilość zamówień pogrupowanych po nazwie klienta\r\no wskazanym identyfikatorze";
            // 
            // dgvGroupings
            // 
            this.dgvGroupings.AllowUserToAddRows = false;
            this.dgvGroupings.AllowUserToDeleteRows = false;
            this.dgvGroupings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroupings.AutoGenerateColumns = false;
            this.dgvGroupings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvGroupings.DataSource = this.orderQuantityByNameDtoBindingSource;
            this.dgvGroupings.Location = new System.Drawing.Point(12, 125);
            this.dgvGroupings.MultiSelect = false;
            this.dgvGroupings.Name = "dgvGroupings";
            this.dgvGroupings.ReadOnly = true;
            this.dgvGroupings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroupings.Size = new System.Drawing.Size(759, 295);
            this.dgvGroupings.TabIndex = 20;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderQuantityByNameDtoBindingSource
            // 
            this.orderQuantityByNameDtoBindingSource.DataSource = typeof(OrderInfoService.WinFormsApp.OrderQuantityByNameDto);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(677, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Zapisz do Csv";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "ClientId:";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(117, 96);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 17;
            this.btnGenerate.Text = "Generuj Raport";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cmbClientId
            // 
            this.cmbClientId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientId.FormattingEnabled = true;
            this.cmbClientId.Location = new System.Drawing.Point(12, 98);
            this.cmbClientId.Name = "cmbClientId";
            this.cmbClientId.Size = new System.Drawing.Size(99, 21);
            this.cmbClientId.TabIndex = 16;
            // 
            // OrdersQuantityGroupedByNameForClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvGroupings);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbClientId);
            this.Controls.Add(this.label1);
            this.Name = "OrdersQuantityGroupedByNameForClient";
            this.Text = "Raport";
            this.Load += new System.EventHandler(this.OrdersQuantityGroupedByNameForClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderQuantityByNameDtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGroupings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cmbClientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource orderQuantityByNameDtoBindingSource;
    }
}