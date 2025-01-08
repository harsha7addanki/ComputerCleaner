using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Cleaner
{
    public partial class BasicTemporaryRemover : Form
    {
        public BasicTemporaryRemover()
        {
            InitializeComponent();
            var fileremover = new TemporaryFileRemover();
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            label1.Text = "Discovering Files";
            fileremover.DicoverFiles(label1);
            if (!fileremover.cont)
            {
                label1.Text = "No Files To delete";
                progressBar1.Visible = false;
                return;
            }
            label1.Text = "Deleting Files";
            progressBar1.Style = ProgressBarStyle.Continuous;
            fileremover.DeleteDiscoveredFiles(label1, progressBar1);
            label1.Text = "Deleting Folders";
            fileremover.DeleteDiscoveredFolders(label1, progressBar1);
            label1.Text = "Done";
        }
    }
}
