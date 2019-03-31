using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersAmountForClientPresenter : IPresenter
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
            _view.Save += new EventHandler(async (s, e) => await OnSaveAsync(s, e));
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

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Kwota_wszystkich_zamowien_dla_'" + _view.SelectedClientId + "'");
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
                Application.UseWaitCursor = true;
                await OrdersWriter.SaveToCsvAsync(records.ToList(), path);
                Application.UseWaitCursor = false;
            }
            catch (Exception)
            {
                Application.UseWaitCursor = false;
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }
    }
}
