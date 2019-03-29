using OrderInfoService.WinFormsApp.Infrastructure;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IOrdersQuantityGroupedByNameView : IReportView
    {
        SortableBindingList<OrderQuantityByNameDto> Groupings { set; }
    }
}
