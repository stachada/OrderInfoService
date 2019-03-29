using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IReportPresenter
    {
        Form View { get; }
    }
}
