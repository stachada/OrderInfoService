using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IMainView
    {
        event EventHandler<ShowReportEventArgs> ShowReport;
        event EventHandler LoadDatabase;
        event EventHandler ResetDatabase;
        event EventHandler ShowDatabaseReport;
        bool DatabaseLoaded { set; }
        void CloseChildForms();
        void ShowForm(Form form);
    }
}
