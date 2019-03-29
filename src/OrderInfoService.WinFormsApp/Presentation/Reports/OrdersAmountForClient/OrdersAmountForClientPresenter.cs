using System;
using System.Linq;
using System.Windows.Forms;
using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersAmountForClientPresenter : IReportPresenter
    {
        private readonly IOrdersAmountForClientView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private double _ordersAmount;

        public OrdersAmountForClientPresenter(IOrdersAmountForClientView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += OnSave;
            _view.Generate += OnGenerate;
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _view.ClientIds = _ordersQueries.GetClientIds().ToList();
            _view.CanSave = false;
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            _ordersAmount = _ordersQueries.GetOrdersAmountForClient(_view.SelectedClientId);
            _view.OrdersAmount = _ordersAmount;
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
                        new { Client_Id = _view.SelectedClientId, Orders_Amount = _ordersAmount }
                    }.ToList();
            try
            {
                OrdersWriter.SaveToCsv(records.ToList(), path);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }
    }
}
