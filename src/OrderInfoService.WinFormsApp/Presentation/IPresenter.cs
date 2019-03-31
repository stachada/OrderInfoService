using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IPresenter
    {
        Form View { get; }
    }
}
