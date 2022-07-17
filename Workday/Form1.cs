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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

/// <summary> COLOR BACKGROUND
/// https://www.c-sharpcorner.com/article/gradient-background-tab-custom-control/
/// </summary>

namespace Workday
{
  
    public partial class Form1 : Form
    {
        private Stopwatch stopWatch;
        TimeSpan ts = new TimeSpan();
        private int breakMin = 0;
        private bool breakMode = false;


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
                    new XElement("HISTORY",
                    new XElement("Name", ""),
                    new XElement("Time", ""),
                    new XElement("Remarks", ""),
                    new XElement("Date", ""))).Save("History.xml");
            }
            button_Stop.Enabled = false;
            button_Reset.Enabled = false;
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            stopWatch.Start();
            button_Start.Enabled = false;
            button_Stop.Enabled = true;
            button_Reset.Enabled = true;
            tabControl1.SelectedTab.BackColor = Color.Green;
            comboBox_Technique.Enabled = false;



        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            string x = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_Time.Text = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);

            ts = stopWatch.Elapsed;
            if((ts.Minutes%50==0|| ts.Minutes % 45 == 0 || ts.Minutes % 30 == 0 || ts.Minutes % 20 == 0) && ts.Minutes != 0 && breakMin != 0 && !breakMode)
            {
                Technique();
            }
           
           
            
        }
        private void Technique()
        {
            if (comboBox_Technique.Text.Contains("50 min work"))
            {
                if (ts.Minutes % 50 == 0 )
                {

                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else if(comboBox_Technique.Text.Contains("45 min work"))
            {
                if (ts.Minutes % 45 == 0 )
                {

                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else if (comboBox_Technique.Text.Contains("30 min work"))
            {
                if (ts.Minutes % 30 == 0)
                {

                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else if (comboBox_Technique.Text.Contains("20 min work"))
            {
                if (ts.Minutes % 20 == 0)
                {

                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }

        private void label_Time_Click(object sender, EventArgs e)
        {

        }

      
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            if (breakMin != 0)
            {
                breakMode = true;
                this.Invoke(new MethodInvoker(delegate {

                    tabControl1.SelectTab("Session");
                    tabControl1.SelectedTab.BackColor = Color.Red;
                   
                }));

                System.Threading.Thread.Sleep(TimeSpan.FromMinutes(breakMin));

                this.Invoke(new MethodInvoker(delegate {

                    tabControl1.SelectTab("Session");
                    tabControl1.SelectedTab.BackColor = Color.Green;
                }));
                breakMode = false;
            }

        }

        private void comboBox_Technique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Technique.Text.Contains("10 min break")) 
            {
                breakMin = 10;
                
            }
            else if(comboBox_Technique.Text.Contains("15 min break"))
            {
                breakMin = 15;
            }
            else if (comboBox_Technique.Text.Contains("5 min break"))
            {
                breakMin = 5;
            }
            else
            {
                breakMin = 0;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            //new // form
        } 
    }
}
