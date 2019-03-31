using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersQuantityPresenter : IPresenter
    {
        private readonly IOrdersQuantityView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private int _ordersQuantity;

        public OrdersQuantityPresenter(IOrdersQuantityView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
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
            _ordersQuantity = _ordersQueries.GetOrdersQuantity();
            _view.OrdersQuantity = _ordersQuantity;
            _view.CanSave = true;
        }

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Ilosc_zamowien");
            if (path == "" || path == string.Empty)
            {
                return;
            }
            var records = new[]
                    {
                        new { Orders_Amount = _ordersQuantity }
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
