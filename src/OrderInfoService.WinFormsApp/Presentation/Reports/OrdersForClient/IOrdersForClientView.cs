using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersForClientView : IReportView
    {
        SortableBindingList<OrderDto> Orders { set; }
        SortableBindingList<OrderItemDto> OrderItems { set; }
        List<string> ClientIds { set; }
        string SelectedClientId { get; }
        event EventHandler<SelectedOrderChangedEventArgs> SelectedOrderChanged;
        event EventHandler Generate;
    }
}
