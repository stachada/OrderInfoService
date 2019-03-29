using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class OrdersQuantityGroupedByNameForClientPresenter : IReportPresenter
    {
        private readonly IOrdersQuantityGroupedByNameForClientView _view;
        private readonly IOrdersQueries _ordersQueries;
        private readonly IFileDialogs _fileDialogs;
        private IList<OrderQuantityByNameDto> _groupings;

        public OrdersQuantityGroupedByNameForClientPresenter(IOrdersQuantityGroupedByNameForClientView view, IOrdersQueries ordersQueries, IFileDialogs fileDialogs)
        {
            _view = view;
            _ordersQueries = ordersQueries;
            _fileDialogs = fileDialogs;

            _view.Load += OnLoad;
            _view.Generate += OnGenerate;
            _view.Save += OnSave;
        }

        public Form View => (Form)_view;

        private void OnLoad(object sender, EventArgs e)
        {
            _view.ClientIds = _ordersQueries.GetClientIds().ToList();
            _view.CanSave = false;
        }

        private void OnGenerate(object sender, EventArgs e)
        {
            _groupings = _ordersQueries.GetOrdersQuantityGroupedByNameForClient(_view.SelectedClientId);
            _view.Groupings = new Infrastructure.SortableBindingList<OrderQuantityByNameDto>(_groupings);
            _view.CanSave = true;
        }

        private void OnSave(object sender, EventArgs e)
        {
            var path = _fileDialogs.SaveCsvFiles();
            if (path == "" || path == string.Empty)
            {
                return;
            }
            try
            {
                OrdersWriter.SaveToCsv(_groupings.ToList(), path);
            }
            catch (Exception)
            {
                MessageBox.Show("Błąd w trakcie zapisu. Spróbuj ponownie.");
            }
        }
    }
}
