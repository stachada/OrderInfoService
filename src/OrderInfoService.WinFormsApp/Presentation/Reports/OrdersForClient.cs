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
    public partial class OrdersForClient : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<OrderDto> _orders;
        private List<string> _clientIds;

        public OrdersForClient(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _orders = new List<OrderDto>();
            _clientIds = new List<string>();
        }

        private void OrdersForClient_Load(object sender, EventArgs e)
        {
            _clientIds = _ordersQueries.GetClientIds()
                .OrderBy(id => id)
                .ToList();
            cmbClientId.DataSource = _clientIds;
            btnSave.Enabled = false;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            _orders = _ordersQueries.GetOrdersForClient(cmbClientId.Text).ToList();
            dgvOrders.DataSource = new SortableBindingList<OrderDto>(_orders);
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Lista_zamowien_dla_klienta";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;

                try
                {
                    var flatOrders = OrderConverters.FlattenOrder(_orders).ToList();
                    OrdersWriter.SaveToCsv(flatOrders, path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (_orders.Count == 0)
                dgvOrderItems.DataSource = null;
            if (dgvOrders.CurrentRow != null)
            {
                var selectedOrder = (OrderDto)dgvOrders.CurrentRow.DataBoundItem;
                dgvOrderItems.DataSource = new SortableBindingList<OrderItemDto>(selectedOrder.OrderItems);
            }
        }
    }
}
