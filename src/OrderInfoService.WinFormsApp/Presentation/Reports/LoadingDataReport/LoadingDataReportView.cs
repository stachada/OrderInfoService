using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class LoadingDataReportView : Form, ILoadingDataReportView
    {
        public LoadingDataReportView()
        {
            InitializeComponent();
        }

        public SortableBindingList<FlatOrder> ValidOrders
        {
            set
            {
                if (dgvValidOrders.DataSource != value)
                    dgvValidOrders.DataSource = value;
            }
        }

        public SortableBindingList<FlatOrder> InvalidOrders
        {
            set
            {
                if (dgvInvalidOrders.DataSource != value)
                    dgvInvalidOrders.DataSource = value;
            }
        }

        public void AddInfo(List<string> info)
        {
            foreach (var item in info)
            {
                lsbLoadingInfo.Items.Add(item);
            }
        }
    }
}
