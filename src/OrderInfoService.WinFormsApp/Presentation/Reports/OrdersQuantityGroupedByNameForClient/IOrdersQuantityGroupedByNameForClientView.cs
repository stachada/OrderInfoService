using OrderInfoService.WinFormsApp.Infrastructure;
using System;
using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersQuantityGroupedByNameForClientView : IReportView
    {
        List<string> ClientIds { set; }
        string SelectedClientId { get; }
        SortableBindingList<OrderQuantityByNameDto> Groupings { set; }
        event EventHandler Generate;
    }
}
