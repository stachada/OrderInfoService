using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class ReportPresentersFactory : IReportPresentersFactory
    {
        private readonly Func<OrderReportType, IReportPresenter> _factory;

        public ReportPresentersFactory(Func<OrderReportType, IReportPresenter> factory)
        {
            _factory = factory;
        }

        public IReportPresenter Create(OrderReportType orderReportType)
        {
            return _factory(orderReportType);
        }
    }
}
