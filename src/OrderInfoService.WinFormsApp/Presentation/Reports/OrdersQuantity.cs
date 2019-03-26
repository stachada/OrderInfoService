using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantity : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private int _ordersQuantity;

        public OrdersQuantity(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
        }

        private void OrdersQuantity_Load(object sender, EventArgs e)
        {
            _ordersQuantity = _ordersQueries.GetOrdersQuantity();
            lblOrdersQuantity.Text = _ordersQuantity.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Ilosc_zamowien";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Orders_Quantity = _ordersQuantity }
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
