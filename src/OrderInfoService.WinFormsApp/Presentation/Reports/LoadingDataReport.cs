using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class LoadingDataReport : Form
    {
        private readonly IOrdersInMemoryDb _ordersDb;

        public LoadingDataReport(IOrdersInMemoryDb ordersDb)
        {
            InitializeComponent();
            _ordersDb = ordersDb;
        }

        private void LoadingDataReport_Load(object sender, System.EventArgs e)
        {
            dgvValidOrders.DataSource = new SortableBindingList<FlatOrder>(_ordersDb.FlatOrders);
            dgvInvalidOrders.DataSource = new SortableBindingList<FlatOrder>(_ordersDb.InvalidOrders);

            lsbLoadingInfo.Items.Add("Zaimportowane pliki: ");
            lsbLoadingInfo.Items.Add("");
            var loadedFiles = _ordersDb.LoadedFilesInfo();

            if (loadedFiles.Count == 0)
                lsbLoadingInfo.Items.Add("=============Brak=============");

            foreach (var message in loadedFiles)
            {
                lsbLoadingInfo.Items.Add(message);
            }

            lsbLoadingInfo.Items.Add("");
            lsbLoadingInfo.Items.Add("================================================");
            lsbLoadingInfo.Items.Add("Plik pominięte: ");
            lsbLoadingInfo.Items.Add("");

            var skippedFiles = _ordersDb.SkippedFilesInfo();

            if (skippedFiles.Count == 0)
            {
                lsbLoadingInfo.Items.Add("=============Brak=============");
            }
            foreach (var message in _ordersDb.SkippedFilesInfo())
            {
                lsbLoadingInfo.Items.Add(message);
            }
        }
    }
}
