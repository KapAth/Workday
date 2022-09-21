
namespace Workday
{
    partial class frmToDo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox_ToDo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Add = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_ToDo
            // 
            this.richTextBox_ToDo.Location = new System.Drawing.Point(6, 22);
            this.richTextBox_ToDo.Name = "richTextBox_ToDo";
            this.richTextBox_ToDo.Size = new System.Drawing.Size(786, 50);
            this.richTextBox_ToDo.TabIndex = 0;
            this.richTextBox_ToDo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To Do:";
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(583, 78);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(90, 23);
            this.button_Add.TabIndex = 2;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(708, 78);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(90, 23);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // frmToDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BurlyWood;
            this.ClientSize = new System.Drawing.Size(800, 107);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_ToDo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmToDo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmToDo_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_ToDo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Button button_Close;
    }
}