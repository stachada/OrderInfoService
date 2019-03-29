using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityView : Form, IOrdersQuantityView
    {
        public OrdersQuantityView()
        {
            InitializeComponent();
        }

        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public int OrdersQuantity
        {
            set => lblOrdersQuantity.Text = value.ToString();
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
