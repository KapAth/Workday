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
using System.Xml;
using System.Xml.Linq;
using System.Media;
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

        private SoundPlayer _soundPlayer;

        private static int breakMin = 0;
        private bool breakMode = false;
        private int nextBreak = 0;
        private static int workTime = 0;
        private bool stop = false;
        private  int selectedRow;
        //  TimeSpan ts = new TimeSpan();
        TimeSpan tsRemainingTime;
        private bool gridInitialized = false;
        private bool ToDogridInitialized = false;
        

        public static Form _frmSave;
        public static Form _frmToDo;
        public static string xxx = "";
        public static string techniqueStr= "";
        public static int sessionNo = 0;
        public static bool edit = false;
        // public static string newID;

        // private static string AppPath = AppDomain.CurrentDomain.BaseDirectory;
        //private static string AppPath = Application.StartupPath;
     //   private static string AppPath = Environment.SpecialFolder.ApplicationData.ToString();
        private static string AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public struct history
        {
            public string ID { get; set; }
            public  string totalTime { get; set; }
            public  string title { get; set; }
            public  string technique { get; set; }
            public  string remarks { get; set; }
            public  DateTime date { get; set; }
            public  string sessions { get; set; }
        }
        public static string SessionID;
        public static string ToDoID;
        public static string totalTime;
        public static string title;
        public static string technique;
        public static string remarks;
        public static string date;
        public static string sessions;
        public static string ToDoTitle;


        //public static Form1 _frmMain;
        public Form1()
        {
            InitializeComponent();
            //_frmMain = this;
            _soundPlayer = new SoundPlayer("bell.wav");


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                stopWatch = new Stopwatch();
                if (!File.Exists(AppPath+@"/History.xml"))
                {
                    new XDocument(
                        new XElement("HISTORY", "")).Save(AppPath+@"/History.xml");
                }
                if (!File.Exists(AppPath+@"/ToDoAndNotes.xml"))
                {
                    new XDocument(
                        new XElement("TODO", "")).Save(AppPath+@"/ToDoAndNotes.xml");
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
                TransparetBackground(dataGridView1);
                TransparetBackground(checkBox_Sound);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Form Load: "+ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_Technique.Text == "Custom" && (string.IsNullOrEmpty(textBox_WorkMin.Text) || string.IsNullOrEmpty(textBox_BreakMin.Text)))
                {
                    MessageBox.Show("Please set work time and break time to start", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (!breakMode && comboBox_Technique.Text == "Custom" && (!string.IsNullOrEmpty(textBox_WorkMin.Text) || !string.IsNullOrEmpty(textBox_BreakMin.Text)))
                {
                    TextBoxCustomMinutesEnable(false);
                    workTime = Convert.ToInt32(textBox_WorkMin.Text);
                    breakMin = Convert.ToInt32(textBox_BreakMin.Text);
                    techniqueStr = textBox_WorkMin.Text + "-" + textBox_BreakMin.Text;
                    nextBreak = workTime;
                    tsRemainingTime = new TimeSpan(0, breakMin, 1);

                    stopwatchBreak = new Stopwatch();
                }

                /*to get new ID in case of just started
                or keep the same ID in case of saved 2 times during same session
                ensures dublicates are not created in History.xml */
                if (stopWatch.Elapsed.TotalSeconds == 0)
                {
                    SessionID = DateTime.Now.ToString("yyyyMMddHHmmss");
                }
                stopWatch.Start();

                timer1.Start();
                button_Start.Enabled = false;
                button_Stop.Enabled = true;
                button_Reset.Enabled = true;

                comboBox_Technique.Enabled = false;

                if (breakMode)//if started after a stop while in break
                {
                    stop = false;
                    stopwatchBreak.Start();
                    timer2.Start();
                }
                if (label_SessionNo.Visible == false)
                {
                    label_SessionNo.Visible = true;
                }
                if (sessionNo == 0)
                {
                    label_SessionNo.Text = "Session 1";
                    sessionNo = 1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Button Start: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Button Stop: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            try
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
                label_SessionNo.Visible = false;
                sessionNo = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Button Resset: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label_Time.Text = string.Format("{0:hh\\:mm\\:ss}", stopWatch.Elapsed);


                int totalMinutes = (int)stopWatch.Elapsed.TotalMinutes;
                if (breakMin != 0 && totalMinutes != 0 && (totalMinutes % nextBreak == 0) && !breakMode)
                {
                    stopwatchBreak.Start();
                    timer2.Start();

                    StartBreak();

                   // File.AppendAllText("BREAKS.txt", "break: " + nextBreak + " TotalMinutes: " + totalMinutes + Environment.NewLine);

                    nextBreak = totalMinutes + workTime + breakMin;
                    breakMode = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Timer1 tick: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  

        private void label_Time_Click(object sender, EventArgs e)
        {

        }
        private void BringUpWindow()
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
               // try { this.Activate(); } catch { }
               
              //  try { this.Focus(); } catch { }
               // try { this.BringToFront(); } catch { }
               try { this.TopMost = true; } catch { }
               try { this.TopMost = false; } catch { }
            }
            catch { }
        }
        private void StartBreak()
        {
            BringUpWindow();
            try
            {
                if (checkBox_Sound.Checked)
                {
                    _soundPlayer.Play();
                }
            }
            catch { }
            try
            {
                tabControl1.SelectTab("Session");
                label_break.Visible = true;
                progressBar1.Visible = true;

                //progressBar1.Maximum = (breakMin *60* 1000)-300;
                //progressBar1.Value = (breakMin *60*1000)-300;
                progressBar1.Maximum = breakMin * 60;
                progressBar1.Value = breakMin * 60;
                breakMode = true;
            }
            catch { }
        }
        private void EndBreak()
        {
            BringUpWindow();
            try
            {
                if (checkBox_Sound.Checked)
                {
                    _soundPlayer.Play();
                }
            }
            catch { }
            try
            {
                timer2.Stop();
                stopwatchBreak.Reset();
                progressBar1.Value = 0;

                tabControl1.SelectTab("Session");
                label_break.Visible = false;
                progressBar1.Visible = false;
                breakMode = false;
                sessionNo++;
                label_SessionNo.Text = "Session " + sessionNo;
            }
            catch { }
        }

      
      
        private void TextBoxCustomMinutesEnable(bool enable)
        {
            try
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
            catch { }
            
        }


        private void CustomTextBoxVisible(bool visible)
        {
            try
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
            catch { }
            
        }
        private void comboBox_Technique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Technique.Text == "50 min work - 10 min break")
            {
                workTime = 50;
                breakMin = 10;
                nextBreak = 50;
                CustomTextBoxVisible(false);
                techniqueStr = "50-10";
            }
            else if (comboBox_Technique.Text == "45 min work - 15 min break")
            {
                workTime = 45;
                breakMin = 15;
                nextBreak = 45;
                CustomTextBoxVisible(false);
                techniqueStr = "45-15";
            }
            else if (comboBox_Technique.Text == "30 min work - 10 min break")
            {
                workTime = 30;
                breakMin = 10;
                nextBreak = 30;
                CustomTextBoxVisible(false);
                techniqueStr = "30-10";
            }
            else if (comboBox_Technique.Text == "20 min work - 5 min break")
            {
                workTime = 20;
                breakMin = 5;
                nextBreak = 20;
                CustomTextBoxVisible(false);
                techniqueStr = "20-5";
            }
            else if(comboBox_Technique.Text == "None")
            {
                breakMin = 0;
                CustomTextBoxVisible(false);
                techniqueStr = "None";
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
                        button_Start.Enabled = true;
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
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Button Save: "+ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == History)
            //{
                //dataGridView1.Visible = false;
                //ReloadGrid();
                //dataGridView1.Visible = true;
           // }
           // else if (tabControl1.SelectedTab == ToDo)
           // {
                //dataGridView2.Visible = false;
                //ReloadTodoGrid();
                //dataGridView2.Visible = true;
            //}
        }

        private void Session_Paint(object sender, PaintEventArgs e)
        {
            PaintGradient(sender,e);
         
        }

        private void PaintGradient(object sender, PaintEventArgs e)
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
                    MessageBox.Show("Please enter an integer number with minimum value 1", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBox.Text = txtBox.Text.Remove(txtBox.Text.Length - 1);
                }
            }
            catch { }
        }
        public void ReloadHistoryGrid()
        {
            InitializeHistoryGrid();
            LoadHistoryGridData();
        }
        private void LoadHistoryGridData()
        {
            try
            { 
              
                
                XmlDocument doc = new XmlDocument();
                doc.Load(AppPath+@"/History.xml");
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("Session");

                List<history> myHistoryList = new List<history>();
               

                foreach (XmlNode node in nodes)
                {
                    var myHistory = new history();
                   

                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "ID")
                        {
                       myHistory.ID = childNode.InnerText;
                        }
                        else if (childNode.Name == "TotalTime")
                        {
                          myHistory.totalTime = childNode.InnerText;
                        }
                        else if (childNode.Name == "Title")
                        {
                           myHistory.title = childNode.InnerText;
                        }
                        else if (childNode.Name == "Technique")
                        {
                          myHistory.technique = childNode.InnerText;
                        }
                        else if (childNode.Name == "Remarks")
                        {
                           myHistory.remarks = childNode.InnerText;
                        }
                        else if (childNode.Name == "Date")
                        {
                          myHistory.date =Convert.ToDateTime( childNode.InnerText);
                        }
                        else if (childNode.Name == "Sessions")
                        {
                           myHistory.sessions = childNode.InnerText;
                        }
                    }
                    //appear only the first words in datagrid
                    //if (myHistory.remarks.Length > 50)
                    //{
                    //    myHistory.remarks = myHistory.remarks.Substring(0, 50);
                    //}

                   
                    myHistoryList.Add(myHistory);
                   
                    //try { row.Cells[0].Value = ID.Trim(); } catch { }
                    //try { row.Cells[1].Value = title.Trim(); } catch { }
                    //try { row.Cells[2].Value = totalTime.Trim(); } catch { }
                    //try { row.Cells[3].Value = date.Trim(); } catch { }
                    //try { row.Cells[4].Value = technique.Trim(); } catch { }
                    //try { row.Cells[5].Value = sessions.Trim(); } catch { }
                    //try { row.Cells[6].Value = remarks.Trim(); } catch { }
                    //try { dataGridView1.Rows.Add(row); } catch { }
                   // row.Dispose();

                }
                
                //sort by date show latest on top
                myHistoryList.Sort((s1, s2) => s1.date.CompareTo(s2.date));
                myHistoryList.Reverse();

                for (int i = 0; i < myHistoryList.Count; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    try { row.Cells[0].Value = myHistoryList[i].ID.Trim(); } catch { }
                    try { row.Cells[1].Value = myHistoryList[i].title.Trim(); } catch { }
                    try { row.Cells[2].Value = myHistoryList[i].totalTime.Trim(); } catch { }
                    try { row.Cells[3].Value = myHistoryList[i].date.ToShortDateString(); } catch { }
                    try { row.Cells[4].Value = myHistoryList[i].technique.Trim(); } catch { row.Cells[4].Value = ""; }
                    try { row.Cells[5].Value = myHistoryList[i].sessions.Trim(); } catch { row.Cells[5].Value = ""; }
                    try { row.Cells[6].Value = myHistoryList[i].remarks.Trim(); } catch { row.Cells[6].Value = ""; }
                    try { dataGridView1.Rows.Add(row); } catch { }
                    row.Dispose();
                }
                
                dataGridView1.Refresh();
                dataGridView1.Update();
                
               // dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

            }
            catch (Exception ex)
            {

                MessageBox.Show("LoadGridData: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void InitializeHistoryGrid()
        {
            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.Update();
                if (!gridInitialized)
                {
                    DataGridViewColumn column0 = new DataGridViewTextBoxColumn();
                    column0.DataPropertyName = "ID";
                    column0.Name = "ID";
                    dataGridView1.Columns.Add(column0);

                    DataGridViewColumn column1 = new DataGridViewTextBoxColumn();
                    column1.DataPropertyName = "Title";
                    column1.Name = "Title";
                    dataGridView1.Columns.Add(column1);

                    DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
                    column2.DataPropertyName = "Total Time";
                    column2.Name = "Total Time";
                    dataGridView1.Columns.Add(column2);

                    DataGridViewColumn column3 = new DataGridViewTextBoxColumn();
                    column3.DataPropertyName = "Date";
                    column3.Name = "Date";
                    dataGridView1.Columns.Add(column3);

                    DataGridViewColumn column4 = new DataGridViewTextBoxColumn();
                    column4.DataPropertyName = "Technique";
                    column4.Name = "Technique";
                    dataGridView1.Columns.Add(column4);

                    DataGridViewColumn column5 = new DataGridViewTextBoxColumn();
                    column5.DataPropertyName = "Sessions";
                    column5.Name = "Sessions";
                    dataGridView1.Columns.Add(column5);

                    DataGridViewColumn column6 = new DataGridViewTextBoxColumn();
                    column6.DataPropertyName = "Remarks";
                    column6.Name = "Remarks";
                    dataGridView1.Columns.Add(column6);


                    gridInitialized = true;
                    column0.Dispose();
                    column1.Dispose();
                    column2.Dispose();
                    column3.Dispose();
                    dataGridView1.Columns["Date"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["Total Time"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["Title"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["Technique"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["Sessions"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns["Remarks"].SortMode = DataGridViewColumnSortMode.NotSortable;
                    try { dataGridView1.Columns[0].Visible = false; } catch { }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("InitializeGrid: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedTab == History)
            {
                ReloadHistoryGrid();
                dataGridView1.Refresh();

            }
            else if(tabControl1.SelectedTab == ToDo)
            {
                ReloadTodoGrid();
                dataGridView2.Refresh();
            }
            else if (tabControl1.SelectedTab == Notes)
            {
                LoadNotes();
            }
        }

        public void SelectedGridRow(int select)
        {
            if (select == 1)//1 for History, 2 for ToDo
            {
                try { dataGridView1.Rows[selectedRow].Selected = true; } catch { }
            }
            else
            {
                try { dataGridView2.Rows[selectedRow].Selected = true; } catch { }
            }
           
        }

        private void History_Paint(object sender, PaintEventArgs e)
        {
            PaintGradient(sender, e);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { selectedRow = e.RowIndex; } catch { }
            edit = true;
            EditSession(e.RowIndex);
        }

        private void EditSession(int RowIndex)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (RowIndex < 0)
                {
                    return;
                    Cursor.Current = Cursors.Default;
                }
               if(FindSessionWithID(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString()))
                {
                    if (_frmSave == null)
                    {
                        _frmSave = new frmSave(this);

                        _frmSave.ShowDialog();
                        Cursor.Current = Cursors.Default;
                        //e GlobalVariables.fForm2.TopLevel = true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please edit one session at a time", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                }
              
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("EditSession " + ex.Message,"Workday",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public static Boolean FindSessionWithID(string ID)
        {
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/History.xml");

                XElement existingId = doc.Element("HISTORY").Elements("Session")
                       .Where(idElement => idElement.Element("ID").Value == ID)
                       .FirstOrDefault();

                if ((existingId == null))
                {
                    MessageBox.Show("FindSessionWithID: Session ID is empty or does not match with any session in the History.xml");
                   
                    return (false);
                }
                
                SessionID = ID;

                title = existingId.Element("Title").Value;
                try { technique = existingId.Element("Technique").Value; } catch { technique = ""; }

                
                remarks = existingId.Element("Remarks").Value;
               

                date = existingId.Element("Date").Value;
                

                totalTime = existingId.Element("TotalTime").Value;
               
                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("FindSessionWithID: " + ex.Message,"Workday",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return (false);
            }
        }

        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            this.Refresh();
            this.Update();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //handle the row selection on right click
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {
                    string ID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    selectedRow = e.RowIndex;
                    try
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        // Can leave these here - doesn't hurt
                        dataGridView1.Rows[e.RowIndex].Selected = true;

                        dataGridView1.Focus();
                        contextMenuStrip_History.Show(Cursor.Position.X, Cursor.Position.Y);
                       
                    }
                    catch (Exception ex)
                    {
                       
                        MessageBox.Show(ex.Message,"Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void Edit_History_Click(object sender, EventArgs e)
        {
            edit = true;
            EditSession(selectedRow); 
        }

        private void Delete_History_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DeleteSelectedSession();
                Cursor.Current = Cursors.Default;
            }
            catch(Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteSelectedSession()
        {
            if (MessageBox.Show("Are you sure you want to delete the selected session ?", "Workday", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
           // if (MessageBox.Show("Are you sure you want to delete the selected session ? (1/2)", "WorkDay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
           // if (MessageBox.Show("Are you really sure you want to delete the selected session ? (2/2)","WorkDay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string ID = "";
            try
            {
                ID = dataGridView1.Rows[selectedRow].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a valid profile", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/History.xml");

                XElement existingId = doc.Element("HISTORY").Elements("Session")
                       .Where(idElement => idElement.Element("ID").Value == ID)
                       .FirstOrDefault();
                existingId.Remove();
                doc.Save(AppPath+@"/History.xml");
            }
            catch { }
            ReloadHistoryGrid();
        }

        public void ReloadTodoGrid()
        {
            InitializeTodo();
            LoadToDoGridData();
        }
        private void InitializeTodo()
        {

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView2.Update();
            if (!ToDogridInitialized)
            {
                
                try
                {
                    DataGridViewColumn column0 = new DataGridViewTextBoxColumn();
                    column0.DataPropertyName = "ID";
                    column0.Name = "ID";
                    dataGridView2.Columns.Add(column0);

                    DataGridViewImageColumn ic = new DataGridViewImageColumn();
                    ic.HeaderText = "Status";
                    ic.Image = null;
                    ic.Name = "cImg";
                    ic.Width = 35;
                    dataGridView2.Columns.Add(ic);

                    DataGridViewColumn column2 = new DataGridViewTextBoxColumn();
                    column2.DataPropertyName = "Title";
                    column2.Name = "Title";
                    dataGridView2.Columns.Add(column2);

                    ToDogridInitialized = true;

                    ic.Width = 35;
                    ic.MinimumWidth = 20;

                    ic.Dispose();
                    column2.Dispose();
                    column0.Dispose();
                    try { dataGridView2.Columns[0].Visible = false; } catch { }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("InitializeTodo: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadToDoGridData()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(AppPath+@"/ToDoAndNotes.xml");
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("ToDo");


                foreach (XmlNode node in nodes)
                {
                    // for each node make a new row
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView2);


                    //for each childnode add values to the row
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "ID")
                        {
                            row.Cells[0].Value = childNode.InnerText;
                        }
                        else if (childNode.Name == "Status")
                        {
                            if (childNode.InnerText.ToLower() == "pending")
                            {
                                DataGridViewImageCell cell = row.Cells[1] as DataGridViewImageCell;
                                cell.Value = (System.Drawing.Image)Properties.Resources.hourglass24;
                            }
                            else
                            {
                                DataGridViewImageCell cell = row.Cells[1] as DataGridViewImageCell;
                                cell.Value = (System.Drawing.Image)Properties.Resources.check24;
                            }
                        }
                        else if (childNode.Name == "Title")
                        {
                            row.Cells[2].Value = childNode.InnerText;
                        }

                        try { dataGridView2.Rows.Add(row); row.Dispose(); } catch { }
                    }
                    
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadToDoGridData: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == History)
                {
                    dataGridView1.Update();
                    dataGridView1.Refresh();
                }
                else if (tabControl1.SelectedTab == ToDo)
                {  
                    dataGridView2.Update();
                    dataGridView2.Refresh();
                }
            }
            catch { }
        }

        public void LoadNotes()
        {

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(AppPath+@"/ToDoAndNotes.xml");
                XmlElement root = doc.DocumentElement;
                // XmlNodeList nodes = root.SelectNodes("Notes");

                try { richTextBox_Notes.Text = doc.DocumentElement["notes"].InnerText; } catch { richTextBox_Notes.Text = ""; }
            }
            catch (Exception ex)
            {

                MessageBox.Show("LoadNotes: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Add_Todo_Click(object sender, EventArgs e)
        {

            try
            {
               
                Cursor.Current = Cursors.WaitCursor;
                if (_frmToDo == null)
                {
                    _frmToDo = new frmToDo(this);

                    _frmToDo.ShowDialog();
                    Cursor.Current = Cursors.Default;

                }
                else
                {

                    _frmToDo.BringToFront();
                    _frmToDo.WindowState = FormWindowState.Normal;
                    MessageBox.Show("Please add one todo at a time", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Button Add ToDo: " + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Cursor.Current = Cursors.Default;
            }


        }

        private void button_Save_Notes_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");
                XElement existing = doc.Element("TODO");

                try { existing.Element("notes").Value = richTextBox_Notes.Text; } catch { existing.Add(new XElement("notes", richTextBox_Notes.Text)); }
                doc.Save(AppPath+@"/ToDoAndNotes.xml");
                MessageBox.Show("Notes saved successfully", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message,"Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //handle the row selection on right click
                if (e.Button == MouseButtons.Right && e.RowIndex != -1)
                {
                    string ID = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    selectedRow = e.RowIndex;
                    try
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        // Can leave these here - doesn't hurt
                        dataGridView2.Rows[e.RowIndex].Selected = true;

                        dataGridView2.Focus();
                        contextMenuStrip_ToDo.Show(Cursor.Position.X, Cursor.Position.Y);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch { }
        }

        private void EditTodo_Click(object sender, EventArgs e)
        {
            edit = true;
            EditTodo2(selectedRow);
        }
        private void EditTodo2(int RowIndex)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (RowIndex < 0)
                {
                    return;
                    Cursor.Current = Cursors.Default;
                }
                if (FindToDoWithID(dataGridView2.Rows[RowIndex].Cells[0].Value.ToString()))
                {
                    if (_frmToDo == null)
                    {
                        _frmToDo = new frmToDo(this);

                        _frmToDo.ShowDialog();
                        Cursor.Current = Cursors.Default;
                        //e GlobalVariables.fForm2.TopLevel = true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Please edit one ToDo item at a time", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("EditSession " + ex.Message.ToString());
            }
        }

        public static Boolean FindToDoWithID(string ID)
        {
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");

                XElement existingId = doc.Element("TODO").Elements("ToDo")
                       .Where(idElement => idElement.Element("ID").Value == ID)
                       .FirstOrDefault();

                if ((existingId == null))
                {
                    MessageBox.Show("FindToDoWithID: ToDo ID is empty or does not match with any ToDo in the ToDoAndNotes.xml");

                    return (false);
                }

                ToDoID = ID;

                ToDoTitle = existingId.Element("Title").Value;
     

                return (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("FindToDoWithID: " + ex.Message);
                return (false);
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try { selectedRow = e.RowIndex; } catch { }
            edit = true;
            EditTodo2(e.RowIndex);
            
        }

        private void Completed_Click(object sender, EventArgs e)
        {
            try
            {
                ToDoID = dataGridView2.Rows[selectedRow].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Select a valid ToDo", " Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");

                XElement existingId = doc.Element("TODO").Elements("ToDo")
                       .Where(idElement => idElement.Element("ID").Value == ToDoID)
                       .FirstOrDefault();
                try { existingId.Element("Status").Value = "Completed"; doc.Save(AppPath+@"/ToDoAndNotes.xml"); } catch { existingId.Add(new XElement("Status", "Completed")); doc.Save(AppPath+@"/ToDoAndNotes.xml"); }
                ReloadTodoGrid();
                try { SelectedGridRow(2); } catch { }
            }
            catch { }
        }

        private void Pending_Click(object sender, EventArgs e)
        {
            try
            {
                ToDoID = dataGridView2.Rows[selectedRow].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Select a valid ToDo", " Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");

                XElement existingId = doc.Element("TODO").Elements("ToDo")
                       .Where(idElement => idElement.Element("ID").Value == ToDoID)
                       .FirstOrDefault();
                try { existingId.Element("Status").Value = "Pending"; doc.Save(AppPath+@"/ToDoAndNotes.xml"); } catch { existingId.Add(new XElement("Status", "Pending")); doc.Save(AppPath+@"/ToDoAndNotes.xml"); }
                ReloadTodoGrid();
                try { SelectedGridRow(2); } catch { }
            }
            catch { }
        }

        private void DeleteTodo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DeleteSelectedToDo();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteSelectedToDo()
        {
            if (MessageBox.Show("Are you sure you want to delete the selected ToDo ?", "Workday", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            // if (MessageBox.Show("Are you sure you want to delete the selected session ? (1/2)", "WorkDay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            // if (MessageBox.Show("Are you really sure you want to delete the selected session ? (2/2)","WorkDay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            string ID = "";
            try
            {
                ID = dataGridView2.Rows[selectedRow].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a valid ToDo", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");

                XElement existingId = doc.Element("TODO").Elements("ToDo")
                       .Where(idElement => idElement.Element("ID").Value == ID)
                       .FirstOrDefault();
                existingId.Remove();
                doc.Save(AppPath+@"/ToDoAndNotes.xml");
            }
            catch { }
            ReloadTodoGrid();
        }
    }
}

   

