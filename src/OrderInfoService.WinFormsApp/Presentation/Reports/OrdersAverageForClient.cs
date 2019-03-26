using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAverageForClient : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<string> _clientIds;
        private double _ordersAverage;

        public OrdersAverageForClient(IOrdersQueries orderQueries)
        {
            InitializeComponent();
            _ordersQueries = orderQueries;
            _clientIds = new List<string>();
        }

        private void OrdersAverageForClient_Load(object sender, EventArgs e)
        {
            _clientIds = _ordersQueries.GetClientIds().OrderBy(id => id).ToList();
            cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _ordersAverage = _ordersQueries.GetOrdersAverageAmountForClient(cmbClientId.Text);
            lblOrdersAverage.Text = _ordersAverage.ToString();
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Srednia_wartosc_zamowienia_dla_klienta";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                var records = new[]
                {
                    new { Client_Id = cmbClientId.Text, Orders_Average_Amount = _ordersAverage }
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
