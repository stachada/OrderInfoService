using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class LoadingDataReportPresenter : IPresenter
    {
        private readonly ILoadingDataReportView _view;
        private readonly IOrdersInMemoryDb _ordersDb;

        public LoadingDataReportPresenter(ILoadingDataReportView view, IOrdersInMemoryDb ordersDb)
        {
            _view = view;
            _ordersDb = ordersDb;

            _view.Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            _view.ValidOrders = new SortableBindingList<FlatOrder>(_ordersDb.FlatOrders);
            _view.InvalidOrders = new SortableBindingList<FlatOrder>(_ordersDb.InvalidOrders);
            _view.AddInfo(_ordersDb.LoadedFilesInfo());
            _view.AddInfo(_ordersDb.SkippedFilesInfo());
        }

        public Form View => (Form)_view;
    }
}
