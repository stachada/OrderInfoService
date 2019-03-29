using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class AllOrdersPresenter : IReportPresenter
    {
        private readonly IAllOrdersView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderDto> _orders;

        public AllOrdersPresenter(IAllOrdersView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += OnSave;
            _view.SelectedOrderChanged += OnSelectedOrderChanged;
            
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _orders = _ordersQueries.GetAllOrders();
            _view.Orders = new SortableBindingList<OrderDto>(_orders);
            if (_orders.Count == 0)
                _view.CanSave = false;
        }

        private void OnSelectedOrderChanged(object sender, SelectedOrderChangedEventArgs e)
        {
            _view.OrderItems = new SortableBindingList<OrderItemDto>(e.Order.OrderItems);
        }

        private void OnSave(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveCsvFiles();
            if (path == "" || path == string.Empty) // Canceled dialog
                return;
            try
            {
                var flatOrders = OrderConverters.FlattenOrder(_orders).ToList();
                OrdersWriter.SaveToCsv(flatOrders, path);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie."); // Serivce?????
            }
        }
    }
}
