using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Workday
{
    public partial class frmSave : Form
    {
        private Form _frm;
        private string TotalTime = "";
        private string ID = "";
        
        public frmSave(Form frm)
        {
            _frm = frm;
            InitializeComponent();
            
        }

        private void frmSave_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Form1.edit)
                {
                    textBox_Title.Text = Form1.title;
                    label_Total_Time.Text = "Total Time: " + Form1.totalTime;
                    richTextBox_Remarks.Text = Form1.remarks;
                    TotalTime = Form1.totalTime;
                }
                else
                {
                    TotalTime = string.Format("{0:hh\\:mm\\:ss}", Form1.stopWatch.Elapsed);
                    label_Total_Time.Text = "Total Time: " + TotalTime;
                }

            }
            catch { }
          
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            WriteOrUpdateHistoryXML();
        }

        private void WriteOrUpdateHistoryXML()
        {
            try
            {
                if (File.Exists("History.xml"))
                {
                    XDocument doc = XDocument.Load(@"History.xml");
                    XElement existingId;
                    try // check if id Exists
                    {
                        existingId = doc.Element("HISTORY").Elements("Session")
                                          .Where(idElement => idElement.Element("ID").Value == Form1.SessionID)
                                          .FirstOrDefault();
                    }
                    catch { existingId = null; }

                    if (existingId == null) // its not edit, create new
                    {
                       // string NewID = DateTime.Now.ToString("yyyyMMddHHmmss");
                        XElement newSession = doc.Element("HISTORY");
                        newSession.Add(new XElement("Session",
                                   new XElement("ID", DateTime.Now.ToString("yyyyMMddHHmmss")),
                                   new XElement("Title", textBox_Title.Text),
                                   new XElement("Technique", Form1.techniqueStr),
                                   new XElement("Remarks", richTextBox_Remarks.Text),
                                   new XElement("Date", DateTime.Now.ToShortDateString()),
                                   new XElement("Sessions", Form1.sessionNo),
                                   new XElement("TotalTime", TotalTime)));
                        doc.Save("History.xml");
                    }
                    else // its editing, change existing elements
                    {
                        existingId.Element("Title").Value = textBox_Title.Text;
                        existingId.Element("Remarks").Value = richTextBox_Remarks.Text;
                        existingId.Element("TotalTime").Value = TotalTime;
                      //  existingId.Element("Date").Value = DateTime.Now.ToShortDateString();
                        doc.Save("History.xml");

                      //  Form1.SessionID = "";
                        Form1.edit = false;
                        Form1 objMain = (Form1)_frm;
                        objMain.ReloadHistoryGrid();
                        objMain.SelectedGridRow(1);

                    }
                    this.Close();
                    MessageBox.Show("Saved Succefully!", "Workday",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                //string x = ex.Message;
                MessageBox.Show("WriteOrUpdateHistoryXML: " + ex.Message,"Workday",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            try { textBox_Title.Clear(); } catch { }
            try { richTextBox_Remarks.Clear(); } catch { }
            try { this.Close(); } catch { }
        }

        private void frmSave_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { Form1._frmSave = null; } catch { }
            try { Form1.edit = false; } catch { }
        }

        private void frmSave_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                     Color.White,
                                                                     Color.BurlyWood,
                                                                     90F))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
            catch { }
        }

        private void frmSave_Resize(object sender, EventArgs e)
        {
            try { this.Invalidate(); } catch { }
        }

        private void frmSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            try { Form1.SessionID = ""; } catch { } //in case edit is open but not done
        }
    }
}
