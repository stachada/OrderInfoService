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
    public class OrdersInPriceRangePresenter : IPresenter
    {
        private readonly IOrdersInPriceRangeView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderDto> _orders;
        private List<string> _errorMessage;

        public OrdersInPriceRangePresenter(IOrdersInPriceRangeView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;
            _errorMessage = new List<string>();

            _view.Load += OnLoad;
            _view.Save += new EventHandler(async (s, e) => await OnSaveAsync(s, e));
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
            _errorMessage.Clear();
            _view.ValidationError = "";
            if (InputDataValid())
            {
                _view.CanGenerate = true;
                _view.ValidationError = "";
            }
            else
            {
                _view.CanGenerate = false;
                _view.CanSave = false;
                _view.ValidationError = string.Join(Environment.NewLine, _errorMessage.ToArray());
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

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Lista_zamowien_w_przedziale_cenowym");
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
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }

        private bool InputDataValid()
        {
            double minPrice;
            if (!double.TryParse(_view.MinPrice, out minPrice))
            {
                _errorMessage.Add("Cena musi być liczbą");
                return false;
            }

            double maxPrice;
            if (!double.TryParse(_view.MaxPrice, out maxPrice))
            {
                _errorMessage.Add("Cena musi być liczbą");
                return false;
            }

            if (minPrice < 0 || maxPrice < 0)
            {
                _errorMessage.Add("Ceny muszą być większe od zera");
                return false;
            }

            if (minPrice > maxPrice)
            {
                _errorMessage.Add("Cena minimalna nie może być większa od ceny maksymalnej");
                return false;
            }
            return true;
        }
    }
}
