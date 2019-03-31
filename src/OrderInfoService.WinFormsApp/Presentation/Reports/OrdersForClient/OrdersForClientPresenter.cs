using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersForClientPresenter : IPresenter
    {
        private readonly IOrdersForClientView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderDto> _orders;

        public OrdersForClientPresenter(IOrdersForClientView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += new EventHandler(async (s, e) => await OnSaveAsync(s, e));
            _view.Generate += OnGenerate;
            _view.SelectedOrderChanged += OnSelectedOrderChanged;
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _view.ClientIds = _ordersQueries.GetClientIds().ToList();
            _view.CanSave = false;
        }

        private void OnSelectedOrderChanged(object sender, SelectedOrderChangedEventArgs e)
        {
            _view.OrderItems = new SortableBindingList<OrderItemDto>(e.Order.OrderItems);
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            _orders = _ordersQueries.GetOrdersForClient(_view.SelectedClientId);
            _view.Orders = new SortableBindingList<OrderDto>(_orders);
            _view.CanSave = true;
        }

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Lista_zamowien_dla_'" + _view.SelectedClientId + "'");
            if (path == "" || path == string.Empty) // Canceled dialog
                return;
            try
            {
                var flatOrders = OrderConverters.FlattenOrder(_orders).ToList();
                Application.UseWaitCursor = true;
                await OrdersWriter.SaveToCsvAsync(flatOrders, path);
                Application.UseWaitCursor = false;
            }
            catch (Exception)
            {
                Application.UseWaitCursor = false;
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie."); // Serivce?????
            }
        }
    }
}
