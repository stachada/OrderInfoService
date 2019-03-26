using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IReportsFactory
    {
        Form Create(OrderReportType orderReportType);
    }
}
