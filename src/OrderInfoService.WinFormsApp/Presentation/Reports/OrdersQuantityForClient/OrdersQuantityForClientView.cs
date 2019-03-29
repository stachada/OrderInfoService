using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityForClientView : Form, IOrdersQuantityForClientView
    {
        public OrdersQuantityForClientView()
        {
            InitializeComponent();
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

        public List<string> ClientIds
        {
            set
            {
                if (cmbClientId.DataSource != value)
                    cmbClientId.DataSource = value;
            }
        }

        public string SelectedClientId => cmbClientId.Text;

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

        private void OrdersQuantityForClient_Load(object sender, EventArgs e)
        {
            //_clientIds = _ordersQueries.GetClientIds()
            //    .OrderBy(id => id)
            //    .ToList();
            //cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //_ordersQuantity = _ordersQueries.GetOrdersQuantityForClient(cmbClientId.Text);
            //lblOrdersAmount.Text = _ordersQuantity.ToString();
            //btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "csv|*.csv";
            //sfd.FileName = "Ilosc_zamowien_dla_klienta";

            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    var path = sfd.FileName;
            //    var records = new[]
            //    {
            //        new { Client_Id = cmbClientId.Text, Orders_Quantity = _ordersQuantity }
            //    }.ToList();

            //    try
            //    {
            //        OrdersWriter.SaveToCsv(records, path);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            //    }
            //}
        }
    }
}
