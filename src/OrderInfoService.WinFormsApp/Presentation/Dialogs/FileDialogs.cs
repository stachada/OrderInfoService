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
            List<string> paths = new List<string>();
            using (OpenFileDialog ofd = new OpenFileDialog())
            { 
                ofd.Multiselect = true;
                ofd.Filter = "Wszystkie|*.json;*.csv;*.xml|csv|*.csv|json|*.json|xml|*.xml";
                ofd.Title = "Wybierz pliki z zamówieniami do zaimportowania";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    paths = ofd.FileNames.ToList();
                }
            }
            return paths;
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
