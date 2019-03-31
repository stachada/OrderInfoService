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
    public class OrdersQuantityGroupedByNamePresenter : IPresenter
    {
        private readonly IOrdersQuantityGroupedByNameView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderQuantityByNameDto> _groupings;

        public OrdersQuantityGroupedByNamePresenter(IOrdersQuantityGroupedByNameView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
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
            _groupings = _ordersQueries.GetOrdersQuantityGroupedByName();
            _view.Groupings = new SortableBindingList<OrderQuantityByNameDto>(_groupings);
            _view.CanSave = true;
        }

        private async Task OnSaveAsync(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveFileDialog("Ilosc_zamowien_wedlug_nazwy");
            if (path == "" || path == string.Empty)
            {
                return;
            }
            try
            {
                Application.UseWaitCursor = true;
                await OrdersWriter.SaveToCsvAsync(_groupings.ToList(), path);
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
