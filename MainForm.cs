using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;

namespace Computer_Cleaner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileremover = new TemporaryFileRemover();
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            label3.Text = "Discovering Files";
            fileremover.DicoverFiles(label3);
            if (!fileremover.cont)
            {
                label3.Text = "No Files To delete";
                progressBar1.Visible = false;
                return;
            }
            label3.Text = "Deleting Files";
            progressBar1.Style = ProgressBarStyle.Continuous;
            fileremover.DeleteDiscoveredFiles(label3, progressBar1);
            label3.Text = "Deleting Folders";
            fileremover.DeleteDiscoveredFolders(label3, progressBar1);
            label3.Text = "Done";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "";
            using(var ts = new TaskService())
            {
                foreach(var task in ts.RootFolder.Tasks)
                {
                    if (task.Name == "TempFileRemover")
                    {
                        ts.RootFolder.DeleteTask("TempFileRemover");
                    }
                }
                var td = ts.NewTask();

                td.RegistrationInfo.Description = "Scheduled Task For ComputerCleaner Temporary File Cleaner";
                if(comboBox1.SelectedText == "Weekly")
                {
                    td.Triggers.Add(new WeeklyTrigger(DaysOfTheWeek.Sunday));
                }
                else if(comboBox1.SelectedText == "Daily")
                {
                    td.Triggers.Add(new DailyTrigger());
                }
                else
                {
                    td.Triggers.Add(new MonthlyTrigger());
                }

                td.Actions.Add(new ComHandlerAction(typeof(TemporaryFilesAction).GUID, ""));

                ts.RootFolder.RegisterTaskDefinition("TempFileRemover", td);
            }
        }
    }
}
