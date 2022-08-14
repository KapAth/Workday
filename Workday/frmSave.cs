using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
          TotalTime= string.Format("{0:hh\\:mm\\:ss}", Form1.stopWatch.Elapsed);
            label_Total_Time.Text = "Total Time: "+TotalTime;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("History.xml"))
                {
                    XDocument doc = XDocument.Load(@"History.xml");
                    XElement existingId;
                    try
                    {
                        existingId = doc.Element("HISTORY").Elements("Session")
                                          .Where(idElement => idElement.Element("ID").Value == ID)
                                          .FirstOrDefault();
                    }
                    catch {existingId = null;}

                    if (existingId == null) // its not edit
                    {
                        string NewID = DateTime.Now.ToString("yyyyMMddHHmmss");
                        XElement newSession = doc.Element("HISTORY");
                        newSession.Add(new XElement("Session",
                                   new XElement("ID", NewID),
                                   new XElement("Title", textBox_Title.Text),
                                   new XElement("Technique", textBox_Title.Text),
                                   new XElement("Remarks", richTextBox_Remarks.Text),
                                   new XElement("Date", DateTime.Now.ToShortDateString()),
                                   new XElement("TotalTime", TotalTime)));
                        doc.Save("History.xml");
                    }
                    else // its editing, change existing elements
                    {
                        existingId.Element("Title").Value = textBox_Title.Text;
                        existingId.Element("Remarks").Value = richTextBox_Remarks.Text;
                        existingId.Element("TotalTime").Value = richTextBox_Remarks.Text;
                        existingId.Element("Date").Value = DateTime.Now.ToShortDateString();
                        doc.Save("History.xml");
                    }
                }

            }
            catch (Exception ex) { string x = ex.Message; }
        }
    }
}
