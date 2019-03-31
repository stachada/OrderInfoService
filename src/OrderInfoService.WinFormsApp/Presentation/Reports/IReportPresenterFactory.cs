namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IReportPresentersFactory
    {
        IPresenter Create(OrderReportType orderReportType);
    }
}