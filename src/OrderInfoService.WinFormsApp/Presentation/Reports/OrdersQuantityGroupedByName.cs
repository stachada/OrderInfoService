using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class OrdersQuantityGroupedByName : Form
    {
        private readonly IOrdersQueries _ordersQueries;
        private List<OrderQuantityByNameDto> _groupings;

        public OrdersQuantityGroupedByName(IOrdersQueries ordersQueries)
        {
            InitializeComponent();
            _ordersQueries = ordersQueries;
            _groupings = new List<OrderQuantityByNameDto>();
        }

        private void OrdersQuantityGroupedByName_Load(object sender, EventArgs e)
        {
            _groupings = _ordersQueries.GetOrdersQuantityGroupedByName().ToList();
            dgvGroupings.DataSource = new SortableBindingList<OrderQuantityByNameDto>(_groupings);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "csv|*.csv";
            sfd.FileName = "Ilosc_zamowien_pogrupowanych_po_nazwie";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;

                try
                {
                    OrdersWriter.SaveToCsv(_groupings, path);
                }
                catch (Exception)
                {
                    MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
                }
            }
        }
    }
}
