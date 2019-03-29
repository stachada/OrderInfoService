using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersInPriceRangeView : Form, IOrdersInPriceRangeView
    {
        public OrdersInPriceRangeView()
        {
            InitializeComponent();
        }

        public SortableBindingList<OrderDto> Orders
        {
            set
            {
                if (dgvOrders.DataSource != value)
                    dgvOrders.DataSource = value;
            }
        }

        public SortableBindingList<OrderItemDto> OrderItems
        {
            set
            {
                if (dgvOrderItems.DataSource != value)
                    dgvOrderItems.DataSource = value;
            }
        }

        public string MinPrice => txtMinPrice.Text;

        public string MaxPrice => txtMaxPrice.Text;

        public bool CanSave
        {
            set
            {
                if (btnSave.Enabled != value)
                    btnSave.Enabled = value;
            }
        }

        public bool CanGenerate
        {
            set
            {
                if (btnGenerate.Enabled != value)
                    btnGenerate.Enabled = value;
            }
        }

        public event EventHandler<SelectedOrderChangedEventArgs> SelectedOrderChanged;

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            OnSelectedOrderChanged(sender);
        }

        private void OnSelectedOrderChanged(object sender)
        {
            if (dgvOrders.CurrentRow != null)
            {
                var selectedOrder = (OrderDto)dgvOrders.CurrentRow.DataBoundItem;
                SelectedOrderChanged?.Invoke(sender, new SelectedOrderChangedEventArgs(selectedOrder));
            }
        }

        public event EventHandler Generate
        {
            add { btnGenerate.Click += value; }
            remove { btnGenerate.Click -= value; }
        }

        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public event EventHandler InputDataChanged;

        private void txtMinPrice_TextChanged(object sender, EventArgs e)
        {
            OnInputDataChanged(sender);
        }

        private void txtMaxPrice_TextChanged(object sender, EventArgs e)
        {
            OnInputDataChanged(sender);
        }

        private void OnInputDataChanged(object sender)
        {
            InputDataChanged?.Invoke(sender, new EventArgs());
        }
    }
}
