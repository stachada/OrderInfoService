using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityGroupedByNameForClient : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<string> _clientIds;
        private List<OrderQuantityByNameDto> _groupings;

        public OrdersQuantityGroupedByNameForClient(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _clientIds = new List<string>();
            _groupings = new List<OrderQuantityByNameDto>();
        }

        private void OrdersQuantityGroupedByNameForClient_Load(object sender, EventArgs e)
        {
            _clientIds = _ordersQueries.GetClientIds()
                .OrderBy(id => id)
                .ToList();
            cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _groupings = _ordersQueries.GetOrdersQuantityGroupedByNameForClient(cmbClientId.Text)
                .ToList();
            dgvGroupings.DataSource = new SortableBindingList<OrderQuantityByNameDto>(_groupings);
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Ilosc_zamowien_pogrupowanych_dla_klienta_" + cmbClientId.Text;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;

                try
                {
                    OrdersWriter.SaveToCsv(_groupings, path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
                }
            }
        }
    }
}
