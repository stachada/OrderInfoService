using System;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IReportView
    {
        bool CanSave { set; }
        event EventHandler Load;
        event EventHandler Save;
    }
}
