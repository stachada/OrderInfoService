using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class ReportsFactory : IReportsFactory
    {
        private readonly Func<OrderReportType, Form> _factory;

        public ReportsFactory(Func<OrderReportType, Form> factory)
        {
            _factory = factory;
        }

        public Form Create(OrderReportType orderReportType)
        {
            return _factory(orderReportType);
        }
    }
}
