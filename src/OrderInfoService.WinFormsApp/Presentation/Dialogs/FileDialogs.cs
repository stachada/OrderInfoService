using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public class FileDialogs : IFileDialogs
    {
        public List<string> LoadDatabaseFiles()
        {
            throw new NotImplementedException();
        }

        public string SaveCsvFiles()
        {
            string path = string.Empty;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "csv|*.csv";
                sfd.FileName = "Lista_wszystkich_zamowien";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    path = sfd.FileName;
                }
            }
            return path;
        }
    }
}
