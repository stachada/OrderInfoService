namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IReportPresentersFactory
    {
        IReportPresenter Create(OrderReportType orderReportType);
    }
}