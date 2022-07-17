
namespace Workday
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label_Time = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Session = new System.Windows.Forms.TabPage();
            this.label_Technique = new System.Windows.Forms.Label();
            this.comboBox_Technique = new System.Windows.Forms.ComboBox();
            this.History = new System.Windows.Forms.TabPage();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button_Save = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Session.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_Time.Location = new System.Drawing.Point(38, 22);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(284, 73);
            this.label_Time.TabIndex = 0;
            this.label_Time.Text = "00:00:00";
            this.label_Time.Click += new System.EventHandler(this.label_Time_Click);
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(28, 109);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(89, 31);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(136, 109);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(89, 31);
            this.button_Stop.TabIndex = 2;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(244, 109);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(89, 31);
            this.button_Reset.TabIndex = 3;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Session);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 4;
            // 
            // Session
            // 
            this.Session.BackColor = System.Drawing.Color.DimGray;
            this.Session.Controls.Add(this.button_Save);
            this.Session.Controls.Add(this.label_Technique);
            this.Session.Controls.Add(this.comboBox_Technique);
            this.Session.Controls.Add(this.button_Stop);
            this.Session.Controls.Add(this.button_Reset);
            this.Session.Controls.Add(this.label_Time);
            this.Session.Controls.Add(this.button_Start);
            this.Session.Location = new System.Drawing.Point(4, 22);
            this.Session.Name = "Session";
            this.Session.Padding = new System.Windows.Forms.Padding(3);
            this.Session.Size = new System.Drawing.Size(792, 424);
            this.Session.TabIndex = 0;
            this.Session.Text = "Session";
            // 
            // label_Technique
            // 
            this.label_Technique.AutoSize = true;
            this.label_Technique.Location = new System.Drawing.Point(358, 24);
            this.label_Technique.Name = "label_Technique";
            this.label_Technique.Size = new System.Drawing.Size(58, 13);
            this.label_Technique.TabIndex = 5;
            this.label_Technique.Text = "Technique";
            // 
            // comboBox_Technique
            // 
            this.comboBox_Technique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Technique.FormattingEnabled = true;
            this.comboBox_Technique.Items.AddRange(new object[] {
            "50 min work - 10 min break",
            "45 min work - 15 min break",
            "30 min work - 10 min break",
            "20 min work - 5 min break",
            "none"});
            this.comboBox_Technique.Location = new System.Drawing.Point(358, 43);
            this.comboBox_Technique.Name = "comboBox_Technique";
            this.comboBox_Technique.Size = new System.Drawing.Size(178, 21);
            this.comboBox_Technique.TabIndex = 4;
            this.comboBox_Technique.SelectedIndexChanged += new System.EventHandler(this.comboBox_Technique_SelectedIndexChanged);
            // 
            // History
            // 
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(792, 424);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(514, 117);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workday";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.tabControl1.ResumeLayout(false);
            this.Session.ResumeLayout(false);
            this.Session.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_Time;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Session;
        private System.Windows.Forms.TabPage History;
        private System.Windows.Forms.Label label_Technique;
        private System.Windows.Forms.ComboBox comboBox_Technique;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button_Save;
    }
}

