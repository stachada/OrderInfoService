using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersAveragePresenter : IReportPresenter
    {
        private readonly IOrdersAverageView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private double _ordersAverage;

        public OrdersAveragePresenter(IOrdersAverageView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += OnSave;
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _ordersAverage = _ordersQueries.GetOrdersAverageAmount();
            _view.OrdersAverage = _ordersAverage;
            _view.CanSave = true;
        }

        private void OnSave(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveCsvFiles();
            if (path == "" || path == string.Empty)
            {
                return;
            }
            var records = new[]
                    {
                        new { Orders_Amount = _ordersAverage }
                    }.ToList();
            try
            {
                OrdersWriter.SaveToCsv(records, path);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }
    }
}
