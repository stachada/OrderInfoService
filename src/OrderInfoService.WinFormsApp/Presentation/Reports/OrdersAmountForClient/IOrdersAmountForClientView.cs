using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersAmountForClientView : IReportView
    {
        List<string> ClientIds { set; }
        string SelectedClientId { get; }
        double OrdersAmount { set; }
        event EventHandler Generate;
    }
}
