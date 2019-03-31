using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderInfoService.WinFormsApp.Infrastructure;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class MainPresenter : IPresenter
    {
        private readonly IMainView _view;
        private readonly IOrdersInMemoryDb _orders;
        private readonly IReportPresentersFactory _reportPresenterFactory;
        private readonly IFileDialogs _fileDialogs;

        public MainPresenter(
            IMainView view,
            IOrdersInMemoryDb orders,
            IReportPresentersFactory reportPresenterFactory,
            IFileDialogs fileDialogs)
        {
            _view = view;
            _orders = orders;
            _reportPresenterFactory = reportPresenterFactory;
            _fileDialogs = fileDialogs;

            _view.LoadDatabase += new EventHandler(async (s, e) => await OnLoadDatabaseAsync(s, e));
            _view.ResetDatabase += OnResetDatabase;
            _view.ShowReport += OnShowReport;
            _view.ShowDatabaseReport += OnShowDatabaseReport;
            _view.DatabaseLoaded = false;
        }

        public Form View => (Form)_view;

        private void OnShowDatabaseReport(object sender, EventArgs e)
        {
            var presenter = _reportPresenterFactory.Create(OrderReportType.LoadingData);
            _view.ShowForm(presenter.View);
        }

        private void OnShowReport(object sender, ShowReportEventArgs e)
        {
            var presenter = _reportPresenterFactory.Create(e.OrderReportType);
            _view.ShowForm(presenter.View);
        }

        private void OnResetDatabase(object sender, EventArgs e)
        {
            _view.CloseChildForms();
            _view.DatabaseLoaded = false;
            _orders.ClearDatabase();
        }

        private async Task OnLoadDatabaseAsync(object sender, EventArgs e)
        {
            _view.CloseChildForms();

            var paths = _fileDialogs.LoadDatabaseFiles();
            if (paths.Count == 0)
                return;

            try
            {
                Application.UseWaitCursor = true;
                await _orders.LoadOrdersAsync(paths);
                Application.UseWaitCursor = false;
                if (_orders.Orders.Count > 0)
                    _view.DatabaseLoaded = true;
            }
            catch
            {
                _orders.ClearDatabase();
                Application.UseWaitCursor = false;
                _view.DatabaseLoaded = false;
                MessageBox.Show("Błąd importu. Spróbuj ponownie.");
            }
            var presenter = _reportPresenterFactory.Create(OrderReportType.LoadingData);
            _view.ShowForm(presenter.View);
        }
    }
}
