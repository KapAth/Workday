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
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            try
            {

                XDocument doc = XDocument.Load(@"ToDoAndNotes.xml");
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
                    // string NewID = DateTime.Now.ToString("yyyyMMddHHmmss");
                    XElement newSession = doc.Element("TODO");
                    newSession.Add(new XElement("ToDo",
                               new XElement("ID", DateTime.Now.ToString("yyyyMMddHHmmss")),
                               new XElement("Status", "Pending"),
                               new XElement("Title", richTextBox_ToDo.Text)));
                    doc.Save("ToDoAndNotes.xml");
                }
                else // its editing, change existing elements
                {
                    existingId.Element("Title").Value =richTextBox_ToDo.Text;
                    doc.Save("History.xml");

                    //  Form1.SessionID = "";
                    Form1.edit = false;
                    


                }

                this.Close();

                Form1 objMain = (Form1)_frm;
                objMain.ReloadTodoGrid();
                //MessageBox.Show("Saved Succefully!", "Workday", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
