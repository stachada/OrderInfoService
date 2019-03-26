using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAmount : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private double _ordersAmount;

        public OrdersAmount(IOrdersQueries orderQueries)
        {
            InitializeComponent();
            _ordersQueries = orderQueries;
        }

        private void OrdersAmount_Load(object sender, EventArgs e)
        {
            _ordersAmount = _ordersQueries.GetOrdersAmount();
            lblOrdersAmount.Text = _ordersAmount.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Laczna_kwota_zamowien";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Orders_Amount = _ordersAmount }
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
