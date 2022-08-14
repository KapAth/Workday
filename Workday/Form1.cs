using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

///  COLOR
/// https://www.c-sharpcorner.com/article/gradient-background-tab-custom-control/
///

namespace Workday
{
  
    public partial class Form1 : Form
    {
        public static Stopwatch stopWatch = new Stopwatch();
        private Stopwatch stopwatchBreak;

        private string nl = Environment.NewLine;

       

        private static int breakMin = 0;
        private bool breakMode = false;
        private int nextBreak = 0;
        private static int workTime = 0;
        private bool stop = false;
      //  TimeSpan ts = new TimeSpan();
        TimeSpan tsRemainingTime;
        private bool gridInitialized = false;
        public static Form _frmSave;
        public static string xxx = "";


        public Form1()
        {
            InitializeComponent();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            if (!File.Exists("History.xml"))
            {
                new XDocument(  
                    new XElement("HISTORY","")).Save("History.xml");


                //new XDocument(
                //   new XElement("HISTORY",
                //   new XElement("Session", ""),
                //   new XElement("Time", ""),
                //   new XElement("Remarks", ""),
                //   new XElement("Date", ""))).Save("History.xml");
            }
            button_Stop.Enabled = false;
            button_Reset.Enabled = false;
            label_break.Visible = false;
            progressBar1.Visible = false;
            TransparetBackground(button_Start);
            TransparetBackground(comboBox_Technique);
            TransparetBackground(button_Reset);
            TransparetBackground(button_Stop);
            TransparetBackground(button_Save);
            
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            if (comboBox_Technique.Text == "Custom" && (string.IsNullOrEmpty(textBox_WorkMin.Text) || string.IsNullOrEmpty(textBox_BreakMin.Text)))
            {
                MessageBox.Show("Please work time and break time to start", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!breakMode && comboBox_Technique.Text == "Custom" && (!string.IsNullOrEmpty(textBox_WorkMin.Text) || !string.IsNullOrEmpty(textBox_BreakMin.Text)))
            {
                TextBoxCustomMinutesEnable(false);
                workTime = Convert.ToInt32(textBox_WorkMin.Text);
                breakMin = Convert.ToInt32(textBox_BreakMin.Text);
                nextBreak = workTime;
                tsRemainingTime = new TimeSpan(0, breakMin, 1);

                stopwatchBreak = new Stopwatch();
            }

            stopWatch.Start();
            
            timer1.Start();
            button_Start.Enabled = false;
            button_Stop.Enabled = true;
            button_Reset.Enabled = true;
           // tabControl1.SelectedTab.BackColor = Color.Green;
            comboBox_Technique.Enabled = false;

            if (breakMode)//if started after stop while in break
            {
                stop = false;
                stopwatchBreak.Start();
                timer2.Start();
            }



        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();



            if (breakMode)
            {
                stopwatchBreak.Stop();
                timer2.Stop();
                stop = true;

            }
           

            button_Start.Enabled = true;
            button_Stop.Enabled = false;
            button_Reset.Enabled = true;
            comboBox_Technique.Enabled = false;
           



        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            stopWatch.Reset();
            
            button_Start.Enabled = true;
            button_Stop.Enabled = false;
            button_Reset.Enabled = true;
            comboBox_Technique.Enabled = true;
            TextBoxCustomMinutesEnable(true);
            label_break.Visible = false;
            progressBar1.Visible = false;
            breakMode = false;


            if (breakMode)
            {
                stopwatchBreak.Reset();
                timer2.Stop();
                


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Time.Text = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);

           
            int totalMinutes = (int)stopWatch.Elapsed.TotalMinutes;
            if ( breakMin != 0 && totalMinutes != 0 && (totalMinutes % nextBreak==0)  && !breakMode)
            {

                //tsRemainingTime = new TimeSpan(0, breakMin, 0);

                //     stopwatchBreak = new Stopwatch();
                   
                    stopwatchBreak.Start();
                    timer2.Start();

                StartBreak();
                //backgroundWorker1.RunWorkerAsync();
                File.AppendAllText("BREAKS.txt", "break: " + nextBreak + " TotalMinutes: " + totalMinutes + Environment.NewLine);

                nextBreak = totalMinutes + workTime + breakMin;
                breakMode = true;
                

            }

           



        }
       

        private void label_Time_Click(object sender, EventArgs e)
        {

        }
        private void BringUpWindow()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void StartBreak()
        {
            BringUpWindow();
            tabControl1.SelectTab("Session");
            label_break.Visible = true;
            progressBar1.Visible = true;

            //progressBar1.Maximum = (breakMin *60* 1000)-300;
            //progressBar1.Value = (breakMin *60*1000)-300;
            progressBar1.Maximum = breakMin * 60;
            progressBar1.Value = breakMin * 60;
            breakMode = true;
        }
        private void EndBreak()
        {
            BringUpWindow();
            timer2.Stop();
            stopwatchBreak.Reset();
            progressBar1.Value = 0;

            tabControl1.SelectTab("Session");
            label_break.Visible = false;
            progressBar1.Visible = false;
            breakMode = false;
        }

      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

                this.Invoke(new MethodInvoker(delegate {

                    //if(this.WindowState == FormWindowState.Minimized)
                    //{
                    //    this.WindowState = FormWindowState.Normal;
                    //}
                    //tabControl1.SelectTab("Session");
                    //label_break.Visible = true;
                    //progressBar1.Visible = true;
                    //progressBar1.Maximum = breakMin * 60*1000;
                    //progressBar1.Value = breakMin *60* 1000;
                   
                   
                }));

                System.Threading.Thread.Sleep(TimeSpan.FromMinutes(breakMin));

            while (breakMode)//if stopped while break needs extra time
            {
                System.Threading.Thread.Sleep(TimeSpan.FromMinutes(1000));
            }

                this.Invoke(new MethodInvoker(delegate
                {
                    //if (this.WindowState == FormWindowState.Minimized)
                    //{
                    //    this.WindowState = FormWindowState.Normal;
                    //}
                    //timer2.Stop();
                    //stopwatchBreak.Reset();
                    //progressBar1.Value = 0;

                    //tabControl1.SelectTab("Session");
                    //label_break.Visible = false ;
                    //progressBar1.Visible = false;
                    
                    

                    // tabControl1.SelectedTab.BackColor = Color.Green;
                }));
            //breakMode = false;

        }

        private void TextBoxCustomMinutesEnable(bool enable)
        {
            if (comboBox_Technique.Text == "Custom")
            {
                if (enable)
                {
                    textBox_WorkMin.Enabled = true;
                    textBox_BreakMin.Enabled = true;
                }
                else
                {
                    textBox_WorkMin.Enabled = false;
                    textBox_BreakMin.Enabled = false;
                }
            }
            
        }


        private void CustomTextBoxVisible(bool visible)
        {
            if (visible)
            {
                textBox_WorkMin.Visible = true;
                textBox_BreakMin.Visible = true;
                label_WorkMin.Visible = true;
                label_BreakMin.Visible = true;

            }
            else
            {
                textBox_WorkMin.Visible = false;
                textBox_BreakMin.Visible = false;
                label_WorkMin.Visible = false;
                label_BreakMin.Visible = false;
            }
            
        }
        private void comboBox_Technique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Technique.Text == "50 min work - 10 min break")
            {
                workTime = 50;
                breakMin = 10;
                nextBreak = 50;
                CustomTextBoxVisible(false);
            }
            else if (comboBox_Technique.Text == "45 min work - 15 min break")
            {
                workTime = 45;
                breakMin = 15;
                nextBreak = 45;
                CustomTextBoxVisible(false);
            }
            else if (comboBox_Technique.Text == "30 min work - 10 min break")
            {
                workTime = 30;
                breakMin = 10;
                nextBreak = 30;
                CustomTextBoxVisible(false);
            }
            else if (comboBox_Technique.Text == "20 min work - 5 min break")
            {
                workTime = 20;
                breakMin = 5;
                nextBreak = 20;
                CustomTextBoxVisible(false);
            }
            else if(comboBox_Technique.Text == "None")
            {
                breakMin = 0;
                CustomTextBoxVisible(false);
            }
            else if(comboBox_Technique.Text == "Custom")
            {
                CustomTextBoxVisible(true);
            }
            tsRemainingTime = new TimeSpan(0, breakMin, 1);

            stopwatchBreak = new Stopwatch();
        }
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (stopWatch.IsRunning)
                {
                    if (MessageBox.Show("Session is still running"+nl+"Do you want to stop the timer ?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        stopWatch.Stop();
                        if (breakMode)
                        {
                            stopwatchBreak.Stop();
                            timer2.Stop();
                            stop = true;

                        }
                    }
                }


                Cursor.Current = Cursors.WaitCursor;
                if (_frmSave == null)
                {
                    _frmSave = new frmSave(this);

                    _frmSave.ShowDialog();
                    Cursor.Current = Cursors.Default;

                }
                else
                {

                    _frmSave.BringToFront();
                    _frmSave.WindowState = FormWindowState.Normal;
                    MessageBox.Show("Please edit one session at a time", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Button Save: "+ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor.Current = Cursors.Default;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
         //   this.Invalidate();
        }

        private void Session_Paint(object sender, PaintEventArgs e)
        {
           using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                               Color.White,
                                                               Color.BurlyWood,
                                                               90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Session_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void TransparetBackground(Control C)
        {
            try
            {
                C.Visible = false;

                C.Refresh();
                Application.DoEvents();

                Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
                int titleHeight = screenRectangle.Top - this.Top;
                int Right = screenRectangle.Left - this.Left;

                Bitmap bmp = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                Bitmap bmpImage = new Bitmap(bmp);
                bmp = bmpImage.Clone(new Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
                C.BackgroundImage = bmp;

                C.Visible = true;
            }
            catch { }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            

            if ((int)stopwatchBreak.Elapsed.TotalSeconds < breakMin*60)
            {

                var time = tsRemainingTime.Subtract(stopwatchBreak.Elapsed);
                label_break.Text = "Break: " + string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);
                // progressBar1.Value -=300;
                progressBar1.Value = (int)time.TotalSeconds;
            }
            else
            {
                EndBreak();
                //breakMode = false;
            }
           


        }

        private void textBox_WorkMin_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxInputIsNumberAndNotZero(textBox_WorkMin);
        }

        private void textBox_BreakMin_TextChanged(object sender, EventArgs e)
        {
            checkTextBoxInputIsNumberAndNotZero(textBox_BreakMin);
        }

        private void checkTextBoxInputIsNumberAndNotZero(TextBox txtBox)
        {
            try
            {
                if (!Regex.IsMatch(txtBox.Text, "^[1-9][0-9]*$") && !string.IsNullOrEmpty(txtBox.Text))
                {
                    MessageBox.Show("Please enter integer number with minimum value 1", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
                }
            }
            catch { }
        }
        private void ReloadGrid()
        {
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            dataGridView1.Rows.Clear();
            if (!gridInitialized)
            {
                DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
                column1.DataPropertyName = "Title";
                column1.Name = "Title";
                dataGridView1.Columns.Add(column1);

                DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
                column2.DataPropertyName = "Total Time";
                column2.Name = "Total Time";
                dataGridView1.Columns.Add(column2);

                DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
                column3.DataPropertyName = "Remarks";
                column3.Name = "Remarks";
                dataGridView1.Columns.Add(column3);

            }
           
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == History)
            {
               

            }
        }
    }
}
