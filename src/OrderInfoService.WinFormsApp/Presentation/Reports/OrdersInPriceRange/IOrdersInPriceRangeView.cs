using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersInPriceRangeView : IReportView
    {
        SortableBindingList<OrderDto> Orders { set; }
        SortableBindingList<OrderItemDto> OrderItems { set; }
        string MinPrice { get; }
        string MaxPrice { get; }
        event EventHandler<SelectedOrderChangedEventArgs> SelectedOrderChanged;
        event EventHandler Generate;
        event EventHandler InputDataChanged;
        bool CanGenerate { set; }
    }
}
