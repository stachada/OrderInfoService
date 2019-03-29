namespace OrderInfoService.WinFormsApp.Presentation
{
    partial class MainForm
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
            this.bazaDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.załadujZPlikówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetujBazęDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raportImportuDanychToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raportyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilośćZamówieńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ącznaKwotaZamówieńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaWszystkichZamówieńToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.średniaWartośćZamówieniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bazaDanychToolStripMenuItem,
            this.raportyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(991, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bazaDanychToolStripMenuItem
            // 
            this.bazaDanychToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.załadujZPlikówToolStripMenuItem,
            this.resetujBazęDanychToolStripMenuItem,
            this.raportImportuDanychToolStripMenuItem});
            this.bazaDanychToolStripMenuItem.Name = "bazaDanychToolStripMenuItem";
            this.bazaDanychToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.bazaDanychToolStripMenuItem.Text = "Baza Danych";
            // 
            // załadujZPlikówToolStripMenuItem
            // 
            this.załadujZPlikówToolStripMenuItem.Name = "załadujZPlikówToolStripMenuItem";
            this.załadujZPlikówToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.załadujZPlikówToolStripMenuItem.Text = "Załaduj z plików";
            this.załadujZPlikówToolStripMenuItem.Click += new System.EventHandler(async (s, e) => await this.załadujZPlikówToolStripMenuItem_Click(s, e));
            // 
            // resetujBazęDanychToolStripMenuItem
            // 
            this.resetujBazęDanychToolStripMenuItem.Name = "resetujBazęDanychToolStripMenuItem";
            this.resetujBazęDanychToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.resetujBazęDanychToolStripMenuItem.Text = "Resetuj bazę danych";
            this.resetujBazęDanychToolStripMenuItem.Click += new System.EventHandler(this.resetujBazęDanychToolStripMenuItem_Click);
            // 
            // raportImportuDanychToolStripMenuItem
            // 
            this.raportImportuDanychToolStripMenuItem.Name = "raportImportuDanychToolStripMenuItem";
            this.raportImportuDanychToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.raportImportuDanychToolStripMenuItem.Text = "Raport Importu Danych";
            this.raportImportuDanychToolStripMenuItem.Click += new System.EventHandler(this.raportImportuDanychToolStripMenuItem_Click);
            // 
            // raportyToolStripMenuItem
            // 
            this.raportyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ilośćZamówieńToolStripMenuItem,
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem,
            this.ącznaKwotaZamówieńToolStripMenuItem,
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem,
            this.listaWszystkichZamówieńToolStripMenuItem,
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem,
            this.średniaWartośćZamówieniaToolStripMenuItem,
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem,
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem,
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem,
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem});
            this.raportyToolStripMenuItem.Enabled = false;
            this.raportyToolStripMenuItem.Name = "raportyToolStripMenuItem";
            this.raportyToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.raportyToolStripMenuItem.Text = "Raporty";
            // 
            // ilośćZamówieńToolStripMenuItem
            // 
            this.ilośćZamówieńToolStripMenuItem.Name = "ilośćZamówieńToolStripMenuItem";
            this.ilośćZamówieńToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ilośćZamówieńToolStripMenuItem.Text = "Ilość zamówień";
            this.ilośćZamówieńToolStripMenuItem.Click += new System.EventHandler(this.ilośćZamówieńToolStripMenuItem_Click);
            // 
            // ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem
            // 
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Name = "ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem";
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Text = "Ilość zamówień dla klienta o wskazanym identyfikatorze";
            this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Click += new System.EventHandler(this.ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click);
            // 
            // ącznaKwotaZamówieńToolStripMenuItem
            // 
            this.ącznaKwotaZamówieńToolStripMenuItem.Name = "ącznaKwotaZamówieńToolStripMenuItem";
            this.ącznaKwotaZamówieńToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ącznaKwotaZamówieńToolStripMenuItem.Text = "Łączna kwota zamówień";
            this.ącznaKwotaZamówieńToolStripMenuItem.Click += new System.EventHandler(this.ącznaKwotaZamówieńToolStripMenuItem_Click);
            // 
            // ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem
            // 
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Name = "ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem";
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Text = "Łączna kwota zamówień dla klienta o wskazanym identyfikatorze";
            this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Click += new System.EventHandler(this.ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click);
            // 
            // listaWszystkichZamówieńToolStripMenuItem
            // 
            this.listaWszystkichZamówieńToolStripMenuItem.Name = "listaWszystkichZamówieńToolStripMenuItem";
            this.listaWszystkichZamówieńToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.listaWszystkichZamówieńToolStripMenuItem.Text = "Lista wszystkich zamówień";
            this.listaWszystkichZamówieńToolStripMenuItem.Click += new System.EventHandler(this.listaWszystkichZamówieńToolStripMenuItem_Click);
            // 
            // listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem
            // 
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem.Name = "listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem";
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem.Text = "Lista zamówień dla klient o wskazanym identyfikatorze";
            this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem.Click += new System.EventHandler(this.listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem_Click);
            // 
            // średniaWartośćZamówieniaToolStripMenuItem
            // 
            this.średniaWartośćZamówieniaToolStripMenuItem.Name = "średniaWartośćZamówieniaToolStripMenuItem";
            this.średniaWartośćZamówieniaToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.średniaWartośćZamówieniaToolStripMenuItem.Text = "Średnia wartość zamówienia";
            this.średniaWartośćZamówieniaToolStripMenuItem.Click += new System.EventHandler(this.średniaWartośćZamówieniaToolStripMenuItem_Click);
            // 
            // średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem
            // 
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Name = "średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem";
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Text = "Średnia wartość zamówienia dla klienta o wskazanym identyfikatorze";
            this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Click += new System.EventHandler(this.średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click);
            // 
            // ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem
            // 
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem.Name = "ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem";
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem.Text = "Ilość zamówień pogrupowanych po nazwie";
            this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem.Click += new System.EventHandler(this.ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem_Click);
            // 
            // ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem
            // 
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Name = "ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMen" +
    "uItem";
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Text = "Ilość zamówień pogrupowanych po nazwie dla klienta o wskazanym identyfikatorze";
            this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem.Click += new System.EventHandler(this.ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click);
            // 
            // zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem
            // 
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem.Name = "zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem";
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem.Size = new System.Drawing.Size(513, 22);
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem.Text = "Zamówienia w podanym przedziale cenowym";
            this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem.Click += new System.EventHandler(this.zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem bazaDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem załadujZPlikówToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetujBazęDanychToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raportyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ilośćZamówieńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ącznaKwotaZamówieńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaWszystkichZamówieńToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem średniaWartośćZamówieniaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raportImportuDanychToolStripMenuItem;
    }
}

