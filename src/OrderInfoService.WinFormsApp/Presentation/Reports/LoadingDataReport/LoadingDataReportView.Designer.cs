namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class LoadingDataReportView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvInvalidOrders = new System.Windows.Forms.DataGridView();
            this.clientIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flatOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvValidOrders = new System.Windows.Forms.DataGridView();
            this.clientIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestIdDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isValidDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.flatOrderBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.lsbLoadingInfo = new System.Windows.Forms.ListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvalidOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatOrderBindingSource1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInvalidOrders
            // 
            this.dgvInvalidOrders.AllowUserToAddRows = false;
            this.dgvInvalidOrders.AllowUserToDeleteRows = false;
            this.dgvInvalidOrders.AutoGenerateColumns = false;
            this.dgvInvalidOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvalidOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientIdDataGridViewTextBoxColumn,
            this.requestIdDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dgvInvalidOrders.DataSource = this.flatOrderBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "###ERROR###";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvalidOrders.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvalidOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvalidOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvInvalidOrders.MultiSelect = false;
            this.dgvInvalidOrders.Name = "dgvInvalidOrders";
            this.dgvInvalidOrders.ReadOnly = true;
            this.dgvInvalidOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvalidOrders.Size = new System.Drawing.Size(770, 507);
            this.dgvInvalidOrders.TabIndex = 0;
            // 
            // clientIdDataGridViewTextBoxColumn
            // 
            this.clientIdDataGridViewTextBoxColumn.DataPropertyName = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.HeaderText = "ClientId";
            this.clientIdDataGridViewTextBoxColumn.Name = "clientIdDataGridViewTextBoxColumn";
            this.clientIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestIdDataGridViewTextBoxColumn
            // 
            this.requestIdDataGridViewTextBoxColumn.DataPropertyName = "RequestId";
            this.requestIdDataGridViewTextBoxColumn.HeaderText = "RequestId";
            this.requestIdDataGridViewTextBoxColumn.Name = "requestIdDataGridViewTextBoxColumn";
            this.requestIdDataGridViewTextBoxColumn.ReadOnly = true;
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
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // flatOrderBindingSource
            // 
            this.flatOrderBindingSource.DataSource = typeof(OrderInfoService.WinFormsApp.Core.FlatOrder);
            // 
            // dgvValidOrders
            // 
            this.dgvValidOrders.AllowUserToAddRows = false;
            this.dgvValidOrders.AllowUserToDeleteRows = false;
            this.dgvValidOrders.AutoGenerateColumns = false;
            this.dgvValidOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clientIdDataGridViewTextBoxColumn1,
            this.requestIdDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1,
            this.quantityDataGridViewTextBoxColumn1,
            this.priceDataGridViewTextBoxColumn1,
            this.isValidDataGridViewCheckBoxColumn1});
            this.dgvValidOrders.DataSource = this.flatOrderBindingSource1;
            this.dgvValidOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValidOrders.Location = new System.Drawing.Point(3, 3);
            this.dgvValidOrders.MultiSelect = false;
            this.dgvValidOrders.Name = "dgvValidOrders";
            this.dgvValidOrders.ReadOnly = true;
            this.dgvValidOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValidOrders.Size = new System.Drawing.Size(770, 507);
            this.dgvValidOrders.TabIndex = 0;
            // 
            // clientIdDataGridViewTextBoxColumn1
            // 
            this.clientIdDataGridViewTextBoxColumn1.DataPropertyName = "ClientId";
            this.clientIdDataGridViewTextBoxColumn1.HeaderText = "ClientId";
            this.clientIdDataGridViewTextBoxColumn1.Name = "clientIdDataGridViewTextBoxColumn1";
            this.clientIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // requestIdDataGridViewTextBoxColumn1
            // 
            this.requestIdDataGridViewTextBoxColumn1.DataPropertyName = "RequestId";
            this.requestIdDataGridViewTextBoxColumn1.HeaderText = "RequestId";
            this.requestIdDataGridViewTextBoxColumn1.Name = "requestIdDataGridViewTextBoxColumn1";
            this.requestIdDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn1
            // 
            this.priceDataGridViewTextBoxColumn1.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn1.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn1.Name = "priceDataGridViewTextBoxColumn1";
            this.priceDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // isValidDataGridViewCheckBoxColumn1
            // 
            this.isValidDataGridViewCheckBoxColumn1.DataPropertyName = "IsValid";
            this.isValidDataGridViewCheckBoxColumn1.FalseValue = "OK";
            this.isValidDataGridViewCheckBoxColumn1.HeaderText = "Is Valid";
            this.isValidDataGridViewCheckBoxColumn1.IndeterminateValue = "???";
            this.isValidDataGridViewCheckBoxColumn1.Name = "isValidDataGridViewCheckBoxColumn1";
            this.isValidDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.isValidDataGridViewCheckBoxColumn1.TrueValue = "NOK";
            // 
            // flatOrderBindingSource1
            // 
            this.flatOrderBindingSource1.DataSource = typeof(OrderInfoService.WinFormsApp.Core.FlatOrder);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dane z błędami, kóre nie zostały zaimportowane";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(784, 539);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.lsbLoadingInfo);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(776, 513);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Status Importu";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // lsbLoadingInfo
            // 
            this.lsbLoadingInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbLoadingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lsbLoadingInfo.FormattingEnabled = true;
            this.lsbLoadingInfo.ItemHeight = 20;
            this.lsbLoadingInfo.Location = new System.Drawing.Point(3, 3);
            this.lsbLoadingInfo.Name = "lsbLoadingInfo";
            this.lsbLoadingInfo.Size = new System.Drawing.Size(770, 507);
            this.lsbLoadingInfo.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvValidOrders);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Zaimportowane Dane";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvInvalidOrders);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dane z błędami";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // LoadingDataReportView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 539);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "LoadingDataReportView";
            this.Text = "Wynik Importu Danych";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvalidOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flatOrderBindingSource1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvalidOrders;
        private System.Windows.Forms.BindingSource flatOrderBindingSource;
        private System.Windows.Forms.DataGridView dgvValidOrders;
        private System.Windows.Forms.BindingSource flatOrderBindingSource1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIdDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isValidDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lsbLoadingInfo;
    }
}