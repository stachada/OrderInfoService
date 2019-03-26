using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityForClient : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<string> _clientIds;
        private int _ordersQuantity;

        public OrdersQuantityForClient(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _clientIds = new List<string>();
        }

        private void OrdersQuantityForClient_Load(object sender, EventArgs e)
        {
            _clientIds = _ordersQueries.GetClientIds()
                .OrderBy(id => id)
                .ToList();
            cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _ordersQuantity = _ordersQueries.GetOrdersQuantityForClient(cmbClientId.Text);
            lblOrdersAmount.Text = _ordersQuantity.ToString();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Ilosc_zamowien_dla_klienta";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Client_Id = cmbClientId.Text, Orders_Quantity = _ordersQuantity }
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
