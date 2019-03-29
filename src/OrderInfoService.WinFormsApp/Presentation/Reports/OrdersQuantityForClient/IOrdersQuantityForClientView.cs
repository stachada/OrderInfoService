using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersQuantityForClientView : IReportView
    {
        List<string> ClientIds { set; }
        string SelectedClientId { get; }
        int OrdersQuantity { set; }
        event EventHandler Generate;
    }
}
