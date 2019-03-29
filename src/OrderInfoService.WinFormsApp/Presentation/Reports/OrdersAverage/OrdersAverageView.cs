using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAverageView : Form, IOrdersAverageView
    {
        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click -= value; }
        }

        public double OrdersAverage
        {
            set => lblOrdersAverage.Text = value.ToString();
        }

        public bool CanSave
        {
            set
            {
                if (btnSave.Enabled != value)
                    btnSave.Enabled = value;
            }
        }

        public OrdersAverageView()
        {
            InitializeComponent();
        }
    }
}
