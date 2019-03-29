using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class AllOrdersView : Form, IAllOrdersView
    {
        public AllOrdersView()
        {
            InitializeComponent();
        }

        public bool CanSave
        {
            set
            {
                if (btnSave.Enabled != value)
                    btnSave.Enabled = value;
            }
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

        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }
    }
}
