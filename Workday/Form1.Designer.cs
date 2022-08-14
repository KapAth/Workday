
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
            this.label_BreakMin = new System.Windows.Forms.Label();
            this.label_WorkMin = new System.Windows.Forms.Label();
            this.textBox_BreakMin = new System.Windows.Forms.TextBox();
            this.textBox_WorkMin = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_break = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Technique = new System.Windows.Forms.Label();
            this.comboBox_Technique = new System.Windows.Forms.ComboBox();
            this.History = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.Session.SuspendLayout();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.BackColor = System.Drawing.Color.Transparent;
            this.label_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 57.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label_Time.Location = new System.Drawing.Point(243, 85);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(337, 87);
            this.label_Time.TabIndex = 0;
            this.label_Time.Text = "00:00:00";
            this.label_Time.Click += new System.EventHandler(this.label_Time_Click);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.Transparent;
            this.button_Start.Location = new System.Drawing.Point(181, 197);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(89, 31);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(296, 197);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(89, 31);
            this.button_Stop.TabIndex = 2;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Location = new System.Drawing.Point(415, 197);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(89, 31);
            this.button_Reset.TabIndex = 3;
            this.button_Reset.Text = "Reset";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
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
            this.tabControl1.Size = new System.Drawing.Size(841, 371);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Session
            // 
            this.Session.BackColor = System.Drawing.Color.White;
            this.Session.Controls.Add(this.label_BreakMin);
            this.Session.Controls.Add(this.label_WorkMin);
            this.Session.Controls.Add(this.textBox_BreakMin);
            this.Session.Controls.Add(this.textBox_WorkMin);
            this.Session.Controls.Add(this.progressBar1);
            this.Session.Controls.Add(this.label_break);
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
            this.Session.Size = new System.Drawing.Size(833, 345);
            this.Session.TabIndex = 0;
            this.Session.Text = "Session";
            this.Session.Paint += new System.Windows.Forms.PaintEventHandler(this.Session_Paint);
            this.Session.Resize += new System.EventHandler(this.Session_Resize);
            // 
            // label_BreakMin
            // 
            this.label_BreakMin.AutoSize = true;
            this.label_BreakMin.BackColor = System.Drawing.Color.Transparent;
            this.label_BreakMin.Location = new System.Drawing.Point(5, 89);
            this.label_BreakMin.Name = "label_BreakMin";
            this.label_BreakMin.Size = new System.Drawing.Size(55, 13);
            this.label_BreakMin.TabIndex = 11;
            this.label_BreakMin.Text = "Break Min";
            this.label_BreakMin.Visible = false;
            // 
            // label_WorkMin
            // 
            this.label_WorkMin.AutoSize = true;
            this.label_WorkMin.BackColor = System.Drawing.Color.Transparent;
            this.label_WorkMin.Location = new System.Drawing.Point(7, 63);
            this.label_WorkMin.Name = "label_WorkMin";
            this.label_WorkMin.Size = new System.Drawing.Size(53, 13);
            this.label_WorkMin.TabIndex = 10;
            this.label_WorkMin.Text = "Work Min";
            this.label_WorkMin.Visible = false;
            // 
            // textBox_BreakMin
            // 
            this.textBox_BreakMin.Location = new System.Drawing.Point(62, 86);
            this.textBox_BreakMin.Name = "textBox_BreakMin";
            this.textBox_BreakMin.Size = new System.Drawing.Size(31, 20);
            this.textBox_BreakMin.TabIndex = 9;
            this.textBox_BreakMin.Visible = false;
            this.textBox_BreakMin.TextChanged += new System.EventHandler(this.textBox_BreakMin_TextChanged);
            // 
            // textBox_WorkMin
            // 
            this.textBox_WorkMin.Location = new System.Drawing.Point(62, 60);
            this.textBox_WorkMin.Name = "textBox_WorkMin";
            this.textBox_WorkMin.Size = new System.Drawing.Size(31, 20);
            this.textBox_WorkMin.TabIndex = 8;
            this.textBox_WorkMin.Visible = false;
            this.textBox_WorkMin.TextChanged += new System.EventHandler(this.textBox_WorkMin_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(258, 169);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(366, 13);
            this.progressBar1.TabIndex = 7;
            // 
            // label_break
            // 
            this.label_break.AutoSize = true;
            this.label_break.BackColor = System.Drawing.Color.Transparent;
            this.label_break.Location = new System.Drawing.Point(189, 169);
            this.label_break.Name = "label_break";
            this.label_break.Size = new System.Drawing.Size(35, 13);
            this.label_break.TabIndex = 5;
            this.label_break.Text = "Break";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(535, 197);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(89, 31);
            this.button_Save.TabIndex = 6;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // label_Technique
            // 
            this.label_Technique.AutoSize = true;
            this.label_Technique.Location = new System.Drawing.Point(8, 14);
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
            "Custom",
            "None"});
            this.comboBox_Technique.Location = new System.Drawing.Point(8, 33);
            this.comboBox_Technique.Name = "comboBox_Technique";
            this.comboBox_Technique.Size = new System.Drawing.Size(178, 21);
            this.comboBox_Technique.TabIndex = 4;
            this.comboBox_Technique.SelectedIndexChanged += new System.EventHandler(this.comboBox_Technique_SelectedIndexChanged);
            // 
            // History
            // 
            this.History.Controls.Add(this.dataGridView1);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(833, 345);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(827, 339);
            this.dataGridView1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(841, 371);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workday";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.Session.ResumeLayout(false);
            this.Session.PerformLayout();
            this.History.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_break;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox_BreakMin;
        private System.Windows.Forms.TextBox textBox_WorkMin;
        private System.Windows.Forms.Label label_BreakMin;
        private System.Windows.Forms.Label label_WorkMin;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

