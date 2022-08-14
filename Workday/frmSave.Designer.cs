
namespace Workday
{
    partial class frmSave
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
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Remarks = new System.Windows.Forms.Label();
            this.richTextBox_Remarks = new System.Windows.Forms.RichTextBox();
            this.label_Total_Time = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(12, 78);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(267, 20);
            this.textBox_Title.TabIndex = 0;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Location = new System.Drawing.Point(13, 59);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(27, 13);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "Title";
            // 
            // label_Remarks
            // 
            this.label_Remarks.AutoSize = true;
            this.label_Remarks.Location = new System.Drawing.Point(9, 127);
            this.label_Remarks.Name = "label_Remarks";
            this.label_Remarks.Size = new System.Drawing.Size(49, 13);
            this.label_Remarks.TabIndex = 2;
            this.label_Remarks.Text = "Remarks";
            // 
            // richTextBox_Remarks
            // 
            this.richTextBox_Remarks.Location = new System.Drawing.Point(12, 155);
            this.richTextBox_Remarks.Name = "richTextBox_Remarks";
            this.richTextBox_Remarks.Size = new System.Drawing.Size(267, 222);
            this.richTextBox_Remarks.TabIndex = 3;
            this.richTextBox_Remarks.Text = "";
            // 
            // label_Total_Time
            // 
            this.label_Total_Time.AutoSize = true;
            this.label_Total_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_Total_Time.Location = new System.Drawing.Point(13, 9);
            this.label_Total_Time.Name = "label_Total_Time";
            this.label_Total_Time.Size = new System.Drawing.Size(98, 18);
            this.label_Total_Time.TabIndex = 4;
            this.label_Total_Time.Text = "Total Time: ";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(130, 398);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 20);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(211, 398);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(75, 20);
            this.button_close.TabIndex = 6;
            this.button_close.Text = "close";
            this.button_close.UseVisualStyleBackColor = true;
            // 
            // frmSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 428);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_Total_Time);
            this.Controls.Add(this.richTextBox_Remarks);
            this.Controls.Add(this.label_Remarks);
            this.Controls.Add(this.label_Title);
            this.Controls.Add(this.textBox_Title);
            this.Name = "frmSave";
            this.Text = "Save";
            this.VisibleChanged += new System.EventHandler(this.frmSave_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_Remarks;
        private System.Windows.Forms.RichTextBox richTextBox_Remarks;
        private System.Windows.Forms.Label label_Total_Time;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_close;
    }
}