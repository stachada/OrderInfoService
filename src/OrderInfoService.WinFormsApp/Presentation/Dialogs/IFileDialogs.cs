using System.Collections.Generic;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public interface IFileDialogs
    {
        List<string> LoadFilesDialog();
        string SaveFileDialog(string defaultFileName);
    }
}
