using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityGroupedByNameView : Form, IOrdersQuantityGroupedByNameView
    {
        public OrdersQuantityGroupedByNameView()
        {
            InitializeComponent();
        }

        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public SortableBindingList<OrderQuantityByNameDto> Groupings
        {
            set
            {
                if (dgvGroupings.DataSource != value)
                    dgvGroupings.DataSource = value;
            }
        }

        public bool CanSave
        {
            set
            {
                if (btnSave.Enabled != value)
                    btnSave.Enabled = value;
            }
        }
    }
}
