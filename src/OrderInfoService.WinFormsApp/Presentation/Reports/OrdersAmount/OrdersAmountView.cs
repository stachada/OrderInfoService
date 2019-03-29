using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAmountView : Form, IOrdersAmountView
    {
        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public bool CanSave
        {
            set
            {
                if (btnSave.Enabled != value)
                    btnSave.Enabled = value;
            }
        }

        public double OrdersAmount { set => lblOrdersAmount.Text = value.ToString(); }

        public OrdersAmountView()
        {
            InitializeComponent();
        }
    }
}
