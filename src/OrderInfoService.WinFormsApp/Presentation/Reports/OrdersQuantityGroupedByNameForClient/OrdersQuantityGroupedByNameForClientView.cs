using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityGroupedByNameForClientView : Form, IOrdersQuantityGroupedByNameForClientView
    {
        public OrdersQuantityGroupedByNameForClientView()
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

        private void OrdersQuantityGroupedByNameForClient_Load(object sender, EventArgs e)
        {
            //_clientIds = _ordersQueries.GetClientIds()
            //    .OrderBy(id => id)
            //    .ToList();
            //cmbClientId.DataSource = _clientIds;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //_groupings = _ordersQueries.GetOrdersQuantityGroupedByNameForClient(cmbClientId.Text)
            //    .ToList();
            //dgvGroupings.DataSource = new SortableBindingList<OrderQuantityByNameDto>(_groupings);
            //btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "csv|*.csv";
            //sfd.FileName = "Ilosc_zamowien_pogrupowanych_dla_klienta_" + cmbClientId.Text;

            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    var path = sfd.FileName;

            //    try
            //    {
            //        OrdersWriter.SaveToCsv(_groupings, path);
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            //    }
            //}
        }
    }
}
