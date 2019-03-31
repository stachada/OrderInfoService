using System;
using System.Windows.Forms;

namespace OrderInfoService.WinFormsApp.Presentation
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public event EventHandler<ShowReportEventArgs> ShowReport;

        private void menuReports_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string reportType = item.Tag as string;

            if (reportType != null)
            {
                ShowReport?.Invoke(sender,
                    new ShowReportEventArgs((OrderReportType)Enum.Parse(typeof(OrderReportType), reportType)));
            }
        }

        public event EventHandler LoadDatabase
        {
            add { menuDatabaseLoadDatabase.Click += value; }
            remove { menuDatabaseLoadDatabase.Click -= value; }
        }

        public event EventHandler ResetDatabase
        {
            add { menuDatabaseResetDatabase.Click += value; }
            remove { menuDatabaseResetDatabase.Click -= value; }
        }

        public event EventHandler ShowDatabaseReport
        {
            add { menuDatabaseDatabaseReport.Click += value; }
            remove { menuDatabaseDatabaseReport.Click -= value; }
        }

        public bool DatabaseLoaded {
            set
            {
                if (menuReports.Enabled != value)
                    menuReports.Enabled = value;
            }
        }

        public void ShowForm(Form form)
        {
            form.MdiParent = this;
            form.Show();
            form.Activate();
        }

        public void CloseChildForms()
        {
            foreach (var form in MdiChildren)
                form.Close();
        }
    }
}
