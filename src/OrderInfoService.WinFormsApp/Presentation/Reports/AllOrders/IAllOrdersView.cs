using OrderInfoService.WinFormsApp.Infrastructure;
using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IAllOrdersView : IReportView
    {
        SortableBindingList<OrderDto> Orders { set; }
        SortableBindingList<OrderItemDto> OrderItems { set; }
        event EventHandler<SelectedOrderChangedEventArgs> SelectedOrderChanged;
    }
}
