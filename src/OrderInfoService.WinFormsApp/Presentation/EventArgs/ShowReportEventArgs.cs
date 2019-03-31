using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class ShowReportEventArgs : EventArgs
    {
        public ShowReportEventArgs(OrderReportType orderReportType)
        {
            OrderReportType = orderReportType;
        }

        public OrderReportType OrderReportType { get; private set; }
    }
}