using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class AllOrders : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<OrderDto> _orders;

        public AllOrders(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
        }

        private void AllOrders_Load(object sender, EventArgs e)
        {
            _orders = (List<OrderDto>)_ordersQueries.GetAllOrders();
            dgvOrders.DataSource = new SortableBindingList<OrderDto>(_orders);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Lista_wszystkich_zamowien";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                try
                {
                    var flatOrders = OrderConverters.FlattenOrder(_orders).ToList();
                    OrdersWriter.SaveToCsv(flatOrders, path);
                }
                catch(Exception)
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
