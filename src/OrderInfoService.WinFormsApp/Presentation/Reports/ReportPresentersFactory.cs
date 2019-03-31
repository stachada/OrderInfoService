using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class ReportPresentersFactory : IReportPresentersFactory
    {
        private readonly Func<OrderReportType, IPresenter> _factory;

        public ReportPresentersFactory(Func<OrderReportType, IPresenter> factory)
        {
            _factory = factory;
        }

        public IPresenter Create(OrderReportType orderReportType)
        {
            return _factory(orderReportType);
        }
    }
}
