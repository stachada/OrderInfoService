namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class OrdersAmountForClient
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClientId = new System.Windows.Forms.ComboBox();
            this.lblOrdersAmount = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Łączna kwota zamówień\r\ndla klienta o wskazanym identyfikatorze";
            // 
            // cmbClientId
            // 
            this.cmbClientId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientId.FormattingEnabled = true;
            this.cmbClientId.Location = new System.Drawing.Point(12, 116);
            this.cmbClientId.Name = "cmbClientId";
            this.cmbClientId.Size = new System.Drawing.Size(99, 21);
            this.cmbClientId.TabIndex = 1;
            // 
            // lblOrdersAmount
            // 
            this.lblOrdersAmount.AutoSize = true;
            this.lblOrdersAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOrdersAmount.Location = new System.Drawing.Point(377, 229);
            this.lblOrdersAmount.Name = "lblOrdersAmount";
            this.lblOrdersAmount.Size = new System.Drawing.Size(0, 31);
            this.lblOrdersAmount.TabIndex = 2;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(117, 116);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generuj Raport";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(677, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Zapisz do Csv";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ClientId:";
            // 
            // OrdersAmountForClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblOrdersAmount);
            this.Controls.Add(this.cmbClientId);
            this.Controls.Add(this.label1);
            this.Name = "OrdersAmountForClient";
            this.Text = "Raport";
            this.Load += new System.EventHandler(this.OrdersAmountForClient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClientId;
        private System.Windows.Forms.Label lblOrdersAmount;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
    }
}