using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Workday
{
    public partial class frmToDo : Form
    {
        private Form _frm;
        private static string AppPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public frmToDo(Form frm)
        {
            _frm = frm;
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
          
            try { this.Close(); } catch { }
        }

        private void frmToDo_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { Form1._frmToDo = null; } catch { }
            try { Form1.edit = false;} catch { }
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 objMain = (Form1)_frm;
                XDocument doc = XDocument.Load(AppPath+@"/ToDoAndNotes.xml");
                XElement existingId;
                try // check if id Exists
                {
                    existingId = doc.Element("TODO").Elements("ToDo")
                                      .Where(idElement => idElement.Element("ID").Value == Form1.ToDoID)
                                      .FirstOrDefault();
                }
                catch { existingId = null; }

                if (existingId == null) // its not edit, create new
                {
                    
                    XElement newSession = doc.Element("TODO");
                    newSession.Add(new XElement("ToDo",
                               new XElement("ID", DateTime.Now.ToString("yyyyMMddHHmmss")),
                               new XElement("Status", "Pending"),
                               new XElement("Title", richTextBox_ToDo.Text)));
                    doc.Save(AppPath+"/ToDoAndNotes.xml");
                    objMain.ReloadTodoGrid();
                }
                else // its editing, change existing elements
                {
                    existingId.Element("Title").Value =richTextBox_ToDo.Text;
                    doc.Save(AppPath+@"/ToDoAndNotes.xml");

                   
                   

                    objMain.ReloadTodoGrid();
                    objMain.SelectedGridRow(2);
                   

                }
                Form1.edit = false;
                this.Close();

                
               
  


            }
            catch (Exception ex)
            {

                MessageBox.Show("Button Add:" + ex.Message, "Workday", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmToDo_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                int a;
                if (Form1.edit)
                {
                    richTextBox_ToDo.Text = Form1.ToDoTitle;
                }
                else
                {
                    richTextBox_ToDo.Clear();
                }
            }
            catch { }
        }

        private void frmToDo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //in case edit is open but not done

            try { Form1.ToDoID = ""; } catch { } 
        }
    }
}
