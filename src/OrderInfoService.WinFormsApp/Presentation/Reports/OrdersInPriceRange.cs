using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersInPriceRange : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<OrderDto> _orders;

        public OrdersInPriceRange(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _orders = new List<OrderDto>();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            double minPrice;
            if (!double.TryParse(txtMinPrice.Text, out minPrice))
            {
                MessageBox.Show("Cena musi być liczbą");
                return;
            }

            double maxPrice;
            if (!double.TryParse(txtMaxPrice.Text, out maxPrice) && minPrice < 0)
            {
                MessageBox.Show("Cena musi być liczbą");
                btnSave.Enabled = false;
                return;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                MessageBox.Show("Ceny muszą być większe od zera");
                btnSave.Enabled = false;
                return;
            }

            if (minPrice > maxPrice)
            {
                MessageBox.Show("Cena minimalna nie może być większa od ceny maksymalnej");
                btnSave.Enabled = false;
                return;
            }

            _orders = _ordersQueries.GetOrdersInPriceRange(minPrice, maxPrice).ToList();
            dgvOrders.DataSource = new SortableBindingList<OrderDto>(_orders);
            if (_orders.Count == 0)
            {
                dgvOrderItems.DataSource = null;
                btnSave.Enabled = false;
                return;
            }
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Zamowienia_w_przedziale_cenowym";

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
