using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAmountForClient : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<string> _clientIds;
        private double _ordersAmount;

        public OrdersAmountForClient(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _clientIds = new List<string>();
        }

        private void OrdersAmountForClient_Load(object sender, EventArgs e)
        {
            _clientIds = (List<string>)_ordersQueries.GetClientIds()
                .OrderBy(id => id)
                .ToList();
            cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _ordersAmount = _ordersQueries.GetOrdersAmountForClient(cmbClientId.Text);
            lblOrdersAmount.Text = _ordersAmount.ToString();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Laczna_kwota_zamowien_dla_klienta";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Client_Id = cmbClientId.Text, Orders_Amount = _ordersAmount }
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
