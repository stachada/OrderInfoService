namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class MainView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseLoadDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseResetDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDatabaseDatabaseReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersQuantity = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersQuantityForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersAmount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersAmountForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAllOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersAverageForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersQuantityGroupedByName = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersQuantityGroupedByNameForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOrdersInPricerange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabase,
            this.menuReports});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuDatabase
            // 
            this.menuDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDatabaseLoadDatabase,
            this.menuDatabaseResetDatabase,
            this.menuDatabaseDatabaseReport});
            this.menuDatabase.Name = "menuDatabase";
            this.menuDatabase.Size = new System.Drawing.Size(86, 20);
            this.menuDatabase.Text = "Baza Danych";
            // 
            // menuDatabaseLoadDatabase
            // 
            this.menuDatabaseLoadDatabase.Name = "menuDatabaseLoadDatabase";
            this.menuDatabaseLoadDatabase.Size = new System.Drawing.Size(198, 22);
            this.menuDatabaseLoadDatabase.Text = "Załaduj z plików";
            // 
            // menuDatabaseResetDatabase
            // 
            this.menuDatabaseResetDatabase.Name = "menuDatabaseResetDatabase";
            this.menuDatabaseResetDatabase.Size = new System.Drawing.Size(198, 22);
            this.menuDatabaseResetDatabase.Text = "Resetuj bazę danych";
            // 
            // menuDatabaseDatabaseReport
            // 
            this.menuDatabaseDatabaseReport.Name = "menuDatabaseDatabaseReport";
            this.menuDatabaseDatabaseReport.Size = new System.Drawing.Size(198, 22);
            this.menuDatabaseDatabaseReport.Text = "Raport Importu Danych";
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOrdersQuantity,
            this.menuOrdersQuantityForClient,
            this.menuOrdersAmount,
            this.menuOrdersAmountForClient,
            this.menuAllOrders,
            this.menuOrdersForClient,
            this.menuOrdersAverage,
            this.menuOrdersAverageForClient,
            this.menuOrdersQuantityGroupedByName,
            this.menuOrdersQuantityGroupedByNameForClient,
            this.menuOrdersInPricerange});
            this.menuReports.Enabled = false;
            this.menuReports.Name = "menuReports";
            this.menuReports.Size = new System.Drawing.Size(60, 20);
            this.menuReports.Text = "Raporty";
            this.menuReports.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuReports_DropDownItemClicked);
            // 
            // menuOrdersQuantity
            // 
            this.menuOrdersQuantity.Name = "menuOrdersQuantity";
            this.menuOrdersQuantity.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersQuantity.Tag = "OrdersQuantity";
            this.menuOrdersQuantity.Text = "Ilość zamówień";
            // 
            // menuOrdersQuantityForClient
            // 
            this.menuOrdersQuantityForClient.Name = "menuOrdersQuantityForClient";
            this.menuOrdersQuantityForClient.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersQuantityForClient.Tag = "OrdersQuantityForClient";
            this.menuOrdersQuantityForClient.Text = "Ilość zamówień dla klienta o wskazanym identyfikatorze";
            // 
            // menuOrdersAmount
            // 
            this.menuOrdersAmount.Name = "menuOrdersAmount";
            this.menuOrdersAmount.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersAmount.Tag = "OrdersAmount";
            this.menuOrdersAmount.Text = "Łączna kwota zamówień";
            // 
            // menuOrdersAmountForClient
            // 
            this.menuOrdersAmountForClient.Name = "menuOrdersAmountForClient";
            this.menuOrdersAmountForClient.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersAmountForClient.Tag = "OrdersAmountForClient";
            this.menuOrdersAmountForClient.Text = "Łączna kwota zamówień dla klienta o wskazanym identyfikatorze";
            // 
            // menuAllOrders
            // 
            this.menuAllOrders.Name = "menuAllOrders";
            this.menuAllOrders.Size = new System.Drawing.Size(513, 22);
            this.menuAllOrders.Tag = "AllOrders";
            this.menuAllOrders.Text = "Lista wszystkich zamówień";
            // 
            // menuOrdersForClient
            // 
            this.menuOrdersForClient.Name = "menuOrdersForClient";
            this.menuOrdersForClient.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersForClient.Tag = "OrdersForClient";
            this.menuOrdersForClient.Text = "Lista zamówień dla klient o wskazanym identyfikatorze";
            // 
            // menuOrdersAverage
            // 
            this.menuOrdersAverage.Name = "menuOrdersAverage";
            this.menuOrdersAverage.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersAverage.Tag = "OrdersAverage";
            this.menuOrdersAverage.Text = "Średnia wartość zamówienia";
            // 
            // menuOrdersAverageForClient
            // 
            this.menuOrdersAverageForClient.Name = "menuOrdersAverageForClient";
            this.menuOrdersAverageForClient.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersAverageForClient.Tag = "OrdersAverageForClient";
            this.menuOrdersAverageForClient.Text = "Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze";
            // 
            // menuOrdersQuantityGroupedByName
            // 
            this.menuOrdersQuantityGroupedByName.Name = "menuOrdersQuantityGroupedByName";
            this.menuOrdersQuantityGroupedByName.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersQuantityGroupedByName.Tag = "OrdersQuantityGroupedByName";
            this.menuOrdersQuantityGroupedByName.Text = "Ilość zamówień pogrupowanych po nazwie";
            // 
            // menuOrdersQuantityGroupedByNameForClient
            // 
            this.menuOrdersQuantityGroupedByNameForClient.Name = "menuOrdersQuantityGroupedByNameForClient";
            this.menuOrdersQuantityGroupedByNameForClient.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersQuantityGroupedByNameForClient.Tag = "OrdersQuantityGroupedByNameForClient";
            this.menuOrdersQuantityGroupedByNameForClient.Text = "Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze";
            // 
            // menuOrdersInPricerange
            // 
            this.menuOrdersInPricerange.Name = "menuOrdersInPricerange";
            this.menuOrdersInPricerange.Size = new System.Drawing.Size(513, 22);
            this.menuOrdersInPricerange.Tag = "OrdersInPricerange";
            this.menuOrdersInPricerange.Text = "Zamówienia w podanym przedziale cenowym";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 587);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Order Info Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseLoadDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseResetDatabase;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersQuantity;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersQuantityForClient;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersAmount;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersAmountForClient;
        private System.Windows.Forms.ToolStripMenuItem menuAllOrders;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersForClient;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersAverage;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersAverageForClient;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersQuantityGroupedByName;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersQuantityGroupedByNameForClient;
        private System.Windows.Forms.ToolStripMenuItem menuOrdersInPricerange;
        private System.Windows.Forms.ToolStripMenuItem menuDatabaseDatabaseReport;
    }
}

