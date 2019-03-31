using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersAveragePresenter : IPresenter
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
            _view.Save += new EventHandler(async (s, e) => await OnSaveAsync(s, e));
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _ordersAverage = _ordersQueries.GetOrdersAverageAmount();
            _view.OrdersAverage = _ordersAverage;
            _view.CanSave = true;
        }

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Srednia_kwota_zamowienia");
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
                Application.UseWaitCursor = true;
                await OrdersWriter.SaveToCsvAsync(records, path);
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
