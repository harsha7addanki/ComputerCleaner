namespace Computer_Cleaner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label3 = new Label();
            progressBar1 = new ProgressBar();
            label2 = new Label();
            button1 = new Button();
            tabPage2 = new TabPage();
            button2 = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(2, 113);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(798, 325);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(progressBar1);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(button1);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(790, 295);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Temporary Files Cleaner";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(343, 63);
            label3.Name = "label3";
            label3.Size = new Size(97, 17);
            label3.TabIndex = 3;
            label3.Text = "Waiting to start";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(260, 115);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(253, 23);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 2;
            progressBar1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 22);
            label2.Name = "label2";
            label2.Size = new Size(146, 17);
            label2.TabIndex = 1;
            label2.Text = "Temporary Files cleaner";
            // 
            // button1
            // 
            button1.Location = new Point(352, 86);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(button2);
            tabPage2.Controls.Add(label5);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(label4);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(790, 295);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Scheduler";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(359, 101);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(318, 50);
            label5.Name = "label5";
            label5.Size = new Size(148, 17);
            label5.TabIndex = 2;
            label5.Text = "Temporary Files Cleaner";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Daily", "Weekly", "Monthly" });
            comboBox1.Location = new Point(328, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 25);
            comboBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(340, 20);
            label4.Name = "label4";
            label4.Size = new Size(94, 17);
            label4.TabIndex = 0;
            label4.Text = "Task Scheduler";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 40F);
            label1.Location = new Point(156, 9);
            label1.Name = "label1";
            label1.Size = new Size(464, 72);
            label1.TabIndex = 2;
            label1.Text = "Computer Cleaner";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private Label label1;
        private TabPage tabPage1;
        private ProgressBar progressBar1;
        private Label label2;
        private Button button1;
        private TabPage tabPage2;
        private Label label3;
        private Label label5;
        private ComboBox comboBox1;
        private Label label4;
        private Button button2;
    }
}
