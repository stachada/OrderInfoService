using OrderInfoService.WinFormsApp.Core;
using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface ILoadingDataReportView
    {
        SortableBindingList<FlatOrder> ValidOrders { set; }
        SortableBindingList<FlatOrder> InvalidOrders { set; }
        void AddInfo(List<string> info);
        event EventHandler Load;
    }
}
