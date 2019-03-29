using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class MainForm : Form
    {
        private readonly IOrdersInMemoryDb _orders;
        private readonly IReportsFactory _reportFactory;
        private readonly IReportPresentersFactory _reportPresentersFactory;

        public MainForm(IOrdersInMemoryDb orders, IReportsFactory reportFactory, IReportPresentersFactory reportPresentersFactory)
        {
            InitializeComponent();
            _orders = orders;
            _reportFactory = reportFactory;
            _reportPresentersFactory = reportPresentersFactory;
        }

        private void ShowForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
            form.Activate();
        }

        private void ShowForm(OrderReportType orderReportType)
        {
            var presenter = _reportPresentersFactory.Create(orderReportType);
            ShowForm(presenter.View);
        }

        private async Task załadujZPlikówToolStripMenuItem_Click(object sender, EventArgs e)
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
                    Application.UseWaitCursor = true;
                    await _orders.LoadOrdersAsync(paths);
                    Application.UseWaitCursor = false;
                }
                catch(Exception)
                {
                    _orders.ClearDatabase();
                    Application.UseWaitCursor = false;
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
            ShowForm(OrderReportType.OrdersQuantity);
        }

        private void ilośćZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersQuantityForClient);
        }

        private void ącznaKwotaZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersAmount);
        }

        private void ącznaKwoataZamówieńDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersAmountForClient);
        }

        private void listaWszystkichZamówieńToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.AllOrders);
        }

        private void listaZamówieńDlaKlientOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersForClient);
        }

        private void średniaWartośćZamówieniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersAverage);
        }

        private void średniaWartośćZamówieniaDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersAverageForClient);
        }

        private void ilośćZamówieńPogrupowanychPoNazwieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersQuantityGroupedByName);
        }

        private void ilośćZamówieńPogrupowanychPoNazwieDlaKlientaOWskazanymIdentyfikatorzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersQuantityGroupedByNameForClient);
        }

        private void zamówieniaWPodanymPrzedzialeCenowymToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm(OrderReportType.OrdersInPricerange);
        }
    }
}
