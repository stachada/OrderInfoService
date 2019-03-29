namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class OrdersAverageForClientView
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblOrdersAverage = new System.Windows.Forms.Label();
            this.cmbClientId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "Średnia wartość zamówienia\r\ndla klienta o wskazanym identyfikatorze";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ClientId:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(677, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Zapisz do Csv";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(117, 112);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 8;
            this.btnGenerate.Text = "Generuj Raport";
            this.btnGenerate.UseVisualStyleBackColor = true;
            // 
            // lblOrdersAverage
            // 
            this.lblOrdersAverage.AutoSize = true;
            this.lblOrdersAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOrdersAverage.Location = new System.Drawing.Point(393, 208);
            this.lblOrdersAverage.Name = "lblOrdersAverage";
            this.lblOrdersAverage.Size = new System.Drawing.Size(0, 31);
            this.lblOrdersAverage.TabIndex = 7;
            // 
            // cmbClientId
            // 
            this.cmbClientId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClientId.FormattingEnabled = true;
            this.cmbClientId.Location = new System.Drawing.Point(12, 112);
            this.cmbClientId.Name = "cmbClientId";
            this.cmbClientId.Size = new System.Drawing.Size(99, 21);
            this.cmbClientId.TabIndex = 6;
            // 
            // OrdersAverageForClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblOrdersAverage);
            this.Controls.Add(this.cmbClientId);
            this.Controls.Add(this.label1);
            this.Name = "OrdersAverageForClientView";
            this.Text = "Raport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblOrdersAverage;
        private System.Windows.Forms.ComboBox cmbClientId;
    }
}