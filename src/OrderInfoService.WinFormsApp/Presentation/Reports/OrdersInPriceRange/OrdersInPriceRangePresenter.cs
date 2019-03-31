using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersInPriceRangePresenter : IPresenter
    {
        private readonly IOrdersInPriceRangeView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderDto> _orders;

        public OrdersInPriceRangePresenter(IOrdersInPriceRangeView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Save += OnSave;
            _view.Generate += OnGenerate;
            _view.SelectedOrderChanged += OnSelectedOrderChanged;
            _view.InputDataChanged += OnInputDataChanged;
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _view.CanGenerate = false;
            _view.CanSave = false;
        }

        private void OnInputDataChanged(object sender, EventArgs e)
        {
            if (InputDataValid())
                _view.CanGenerate = true;
            else
            {
                _view.CanGenerate = false;
                _view.CanSave = false;
            }
        }

        private void OnSelectedOrderChanged(object sender, SelectedOrderChangedEventArgs e)
        {
            _view.OrderItems = new SortableBindingList<OrderItemDto>(e.Order.OrderItems);
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            var minPrice = double.Parse(_view.MinPrice);
            var maxPrice = double.Parse(_view.MaxPrice);
            _orders = _ordersQueries.GetOrdersInPriceRange(minPrice, maxPrice);
            _view.Orders = new SortableBindingList<OrderDto>(_orders);
            _view.CanSave = true;
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

        private bool InputDataValid()
        {
            double minPrice;
            if (!double.TryParse(_view.MinPrice, out minPrice))
            {
                //MessageBox.Show("Cena musi być liczbą");
                return false;
            }

            double maxPrice;
            if (!double.TryParse(_view.MaxPrice, out maxPrice) && minPrice < 0)
            {
                //MessageBox.Show("Cena musi być liczbą");
                return false;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                //MessageBox.Show("Ceny muszą być większe od zera");
                return false;
            }

            if (minPrice > maxPrice)
            {
                //MessageBox.Show("Cena minimalna nie może być większa od ceny maksymalnej");
                return false;
            }
            return true;
        }
    }
}
