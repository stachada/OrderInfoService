using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersAverageForClientView : IReportView
    {
        List<string> ClientIds { set; }
        string SelectedClientId { get; }
        double OrdersAverage { set; }
        event EventHandler Generate;
    }
}
