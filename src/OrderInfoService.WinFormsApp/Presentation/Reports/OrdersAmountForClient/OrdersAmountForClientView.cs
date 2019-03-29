using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersAmountForClientView : Form, IOrdersAmountForClientView
    {
        public OrdersAmountForClientView()
        {
            InitializeComponent();
        }

        public double OrdersAmount
        {
            set
            {
                lblOrdersAmount.Text = value.ToString();
            }
        }

        public event EventHandler Generate
        {
            add { btnGenerate.Click += value; }
            remove { btnGenerate.Click += value; }
        }

        public event EventHandler Save
        {
            add { btnSave.Click += value; }
            remove { btnSave.Click += value; }
        }

        public List<string> ClientIds
        {
            set
            {
                if (cmbClientId.DataSource != value)
                    cmbClientId.DataSource = value;
            }
        }

        public string SelectedClientId => cmbClientId.Text;

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
