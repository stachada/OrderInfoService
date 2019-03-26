using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAverage : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private double _ordersAverage;

        public OrdersAverage(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
        }

        private void OrdersAverage_Load(object sender, EventArgs e)
        {
            _ordersAverage = _ordersQueries.GetOrdersAverageAmount();
            lblOrdersAverage.Text = _ordersAverage.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Srednia_wartosc_zamowienia";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Orders_Average_Amount = _ordersAverage }
                }.ToList();

                try
                {
                    OrdersWriter.SaveToCsv(records, path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
                }
            }
        }
    }
}
