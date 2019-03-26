using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class MainForm : Form
    {
        private readonly IOrdersInMemoryDb _orders;
        private readonly IReportsFactory _reportFactory;

        public MainForm(IOrdersInMemoryDb orders, IReportsFactory reportFactory)
        {
            InitializeComponent();
            _orders = orders;
            _reportFactory = reportFactory;
        }

        private void ShowForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
            form.Activate();
        }

        private void załadujZPlikówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var childForm in MdiChildren)
                childForm.Close();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Wszystkie|*.json;*.csv;*.xml|csv|*.csv|json|*.json|xml|*.xml";
            ofd.Title = "Wybierz pliki z zamówieniami do zaimportowania";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var paths = ofd.FileNames.ToList();
                try
                {
                    _orders.LoadOrders(paths);
                }
                catch(Exception)
                {
                    _orders.ClearDatabase();
                    MessageBox.Show("Błąd importu. Spróbuj ponownie.");
                }

                if (_orders.Orders.Count > 0)
                {
                    raportyToolStripMenuItem.Enabled = true;
                }
                var form = _reportFactory.Create(OrderReportType.LoadingData);
                ShowForm(form);
            }
        }

        private void raportImportuDanychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.LoadingData);
            ShowForm(form);
        }

        private void resetujBazęDanychToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
                form.Close();
            raportyToolStripMenuItem.Enabled = false;
            _orders.ClearDatabase();
        }

        private void ilośćZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersQuantity);
            ShowForm(form);
        }

        private void ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersQuantityForClient);
            ShowForm(form);
        }

        private void ącznaKwotaZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersAmount);
            ShowForm(form);
        }

        private void ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersAmountForClient);
            ShowForm(form);
        }

        private void listaWszystkichZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.AllOrders);
            ShowForm(form);
        }

        private void listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersForClient);
            ShowForm(form);
        }

        private void średniaWartośćZamówieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersAverage);
            ShowForm(form);
        }

        private void średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersAverageForClient);
            ShowForm(form);
        }

        private void ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersQuantityGroupedByName);
            ShowForm(form);
        }

        private void ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersQuantityGroupedByNameForClient);
            ShowForm(form);
        }

        private void zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _reportFactory.Create(OrderReportType.OrdersInPricerange);
            ShowForm(form);
        }
    }
}
