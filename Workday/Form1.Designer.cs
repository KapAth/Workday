
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_Time = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Session = new System.Windows.Forms.TabPage();
            this.checkBox_Sound = new System.Windows.Forms.CheckBox();
            this.label_SessionNo = new System.Windows.Forms.Label();
            this.label_BreakMin = new System.Windows.Forms.Label();
            this.label_WorkMin = new System.Windows.Forms.Label();
            this.textBox_BreakMin = new System.Windows.Forms.TextBox();
            this.textBox_WorkMin = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_break = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.label_Technique = new System.Windows.Forms.Label();
            this.comboBox_Technique = new System.Windows.Forms.ComboBox();
            this.ToDo = new System.Windows.Forms.TabPage();
            this.button_Add_Todo = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.History = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Notes = new System.Windows.Forms.TabPage();
            this.button_Save_Notes = new System.Windows.Forms.Button();
            this.richTextBox_Notes = new System.Windows.Forms.RichTextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip_History = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Edit_History = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_History = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip_ToDo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.Completed = new System.Windows.Forms.ToolStripMenuItem();
            this.Pending = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteTodo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.Session.SuspendLayout();
            this.ToDo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.History.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.Notes.SuspendLayout();
            this.contextMenuStrip_History.SuspendLayout();
            this.contextMenuStrip_ToDo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Time
            // 
            this.label_Time.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.button_Start.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.button_Stop.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.button_Reset.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.tabControl1.Controls.Add(this.ToDo);
            this.tabControl1.Controls.Add(this.History);
            this.tabControl1.Controls.Add(this.Notes);
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
            this.Session.Controls.Add(this.checkBox_Sound);
            this.Session.Controls.Add(this.label_SessionNo);
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
            // checkBox_Sound
            // 
            this.checkBox_Sound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox_Sound.AutoSize = true;
            this.checkBox_Sound.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Sound.Checked = true;
            this.checkBox_Sound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Sound.Location = new System.Drawing.Point(8, 325);
            this.checkBox_Sound.Name = "checkBox_Sound";
            this.checkBox_Sound.Size = new System.Drawing.Size(57, 17);
            this.checkBox_Sound.TabIndex = 13;
            this.checkBox_Sound.Text = "Sound";
            this.checkBox_Sound.UseVisualStyleBackColor = false;
            // 
            // label_SessionNo
            // 
            this.label_SessionNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SessionNo.AutoSize = true;
            this.label_SessionNo.BackColor = System.Drawing.Color.Transparent;
            this.label_SessionNo.Location = new System.Drawing.Point(377, 60);
            this.label_SessionNo.Name = "label_SessionNo";
            this.label_SessionNo.Size = new System.Drawing.Size(47, 13);
            this.label_SessionNo.TabIndex = 12;
            this.label_SessionNo.Text = "Session ";
            this.label_SessionNo.Visible = false;
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
            this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.progressBar1.Location = new System.Drawing.Point(258, 169);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(366, 13);
            this.progressBar1.TabIndex = 7;
            // 
            // label_break
            // 
            this.label_break.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.button_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // ToDo
            // 
            this.ToDo.Controls.Add(this.button_Add_Todo);
            this.ToDo.Controls.Add(this.dataGridView2);
            this.ToDo.Location = new System.Drawing.Point(4, 22);
            this.ToDo.Name = "ToDo";
            this.ToDo.Size = new System.Drawing.Size(833, 345);
            this.ToDo.TabIndex = 2;
            this.ToDo.Text = "To Do";
            this.ToDo.UseVisualStyleBackColor = true;
            // 
            // button_Add_Todo
            // 
            this.button_Add_Todo.Image = global::Workday.Properties.Resources.plus_sign24;
            this.button_Add_Todo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Add_Todo.Location = new System.Drawing.Point(8, 4);
            this.button_Add_Todo.Name = "button_Add_Todo";
            this.button_Add_Todo.Size = new System.Drawing.Size(86, 23);
            this.button_Add_Todo.TabIndex = 2;
            this.button_Add_Todo.Text = "   Add New";
            this.button_Add_Todo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Add_Todo.UseVisualStyleBackColor = true;
            this.button_Add_Todo.Click += new System.EventHandler(this.button_Add_Todo_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView2.Location = new System.Drawing.Point(3, 32);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(830, 313);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            this.dataGridView2.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDown);
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.LightGray;
            this.History.Controls.Add(this.dataGridView1);
            this.History.Location = new System.Drawing.Point(4, 22);
            this.History.Name = "History";
            this.History.Padding = new System.Windows.Forms.Padding(3);
            this.History.Size = new System.Drawing.Size(833, 345);
            this.History.TabIndex = 1;
            this.History.Text = "History";
            this.History.Paint += new System.Windows.Forms.PaintEventHandler(this.History_Paint);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(827, 339);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // Notes
            // 
            this.Notes.Controls.Add(this.button_Save_Notes);
            this.Notes.Controls.Add(this.richTextBox_Notes);
            this.Notes.Location = new System.Drawing.Point(4, 22);
            this.Notes.Name = "Notes";
            this.Notes.Size = new System.Drawing.Size(833, 345);
            this.Notes.TabIndex = 3;
            this.Notes.Text = "Notes";
            this.Notes.UseVisualStyleBackColor = true;
            // 
            // button_Save_Notes
            // 
            this.button_Save_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Save_Notes.Location = new System.Drawing.Point(750, 316);
            this.button_Save_Notes.Name = "button_Save_Notes";
            this.button_Save_Notes.Size = new System.Drawing.Size(75, 23);
            this.button_Save_Notes.TabIndex = 1;
            this.button_Save_Notes.Text = "Save";
            this.button_Save_Notes.UseVisualStyleBackColor = true;
            this.button_Save_Notes.Click += new System.EventHandler(this.button_Save_Notes_Click);
            // 
            // richTextBox_Notes
            // 
            this.richTextBox_Notes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox_Notes.Font = new System.Drawing.Font("Noto Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Notes.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_Notes.Name = "richTextBox_Notes";
            this.richTextBox_Notes.Size = new System.Drawing.Size(822, 307);
            this.richTextBox_Notes.TabIndex = 0;
            this.richTextBox_Notes.Text = "";
            // 
            // timer2
            // 
            this.timer2.Interval = 300;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // contextMenuStrip_History
            // 
            this.contextMenuStrip_History.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Edit_History,
            this.Delete_History});
            this.contextMenuStrip_History.Name = "contextMenuStrip_History";
            this.contextMenuStrip_History.Size = new System.Drawing.Size(108, 48);
            // 
            // Edit_History
            // 
            this.Edit_History.Image = global::Workday.Properties.Resources.pencil32;
            this.Edit_History.Name = "Edit_History";
            this.Edit_History.Size = new System.Drawing.Size(107, 22);
            this.Edit_History.Text = "Edit";
            this.Edit_History.Click += new System.EventHandler(this.Edit_History_Click);
            // 
            // Delete_History
            // 
            this.Delete_History.Image = global::Workday.Properties.Resources.trash;
            this.Delete_History.Name = "Delete_History";
            this.Delete_History.Size = new System.Drawing.Size(107, 22);
            this.Delete_History.Text = "Delete";
            this.Delete_History.Click += new System.EventHandler(this.Delete_History_Click);
            // 
            // contextMenuStrip_ToDo
            // 
            this.contextMenuStrip_ToDo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditTodo,
            this.Completed,
            this.Pending,
            this.DeleteTodo});
            this.contextMenuStrip_ToDo.Name = "contextMenuStrip_ToDo";
            this.contextMenuStrip_ToDo.Size = new System.Drawing.Size(134, 92);
            // 
            // EditTodo
            // 
            this.EditTodo.Image = global::Workday.Properties.Resources.pencil32;
            this.EditTodo.Name = "EditTodo";
            this.EditTodo.Size = new System.Drawing.Size(133, 22);
            this.EditTodo.Text = "Edit";
            this.EditTodo.Click += new System.EventHandler(this.EditTodo_Click);
            // 
            // Completed
            // 
            this.Completed.Image = global::Workday.Properties.Resources.check24;
            this.Completed.Name = "Completed";
            this.Completed.Size = new System.Drawing.Size(133, 22);
            this.Completed.Text = "Completed";
            this.Completed.Click += new System.EventHandler(this.Completed_Click);
            // 
            // Pending
            // 
            this.Pending.Image = global::Workday.Properties.Resources.hourglass24;
            this.Pending.Name = "Pending";
            this.Pending.Size = new System.Drawing.Size(133, 22);
            this.Pending.Text = "Pending";
            this.Pending.Click += new System.EventHandler(this.Pending_Click);
            // 
            // DeleteTodo
            // 
            this.DeleteTodo.Image = global::Workday.Properties.Resources.trash;
            this.DeleteTodo.Name = "DeleteTodo";
            this.DeleteTodo.Size = new System.Drawing.Size(133, 22);
            this.DeleteTodo.Text = "Delete";
            this.DeleteTodo.Click += new System.EventHandler(this.DeleteTodo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(841, 371);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Workday";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.Session.ResumeLayout(false);
            this.Session.PerformLayout();
            this.ToDo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.History.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.Notes.ResumeLayout(false);
            this.contextMenuStrip_History.ResumeLayout(false);
            this.contextMenuStrip_ToDo.ResumeLayout(false);
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
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_break;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox textBox_BreakMin;
        private System.Windows.Forms.TextBox textBox_WorkMin;
        private System.Windows.Forms.Label label_BreakMin;
        private System.Windows.Forms.Label label_WorkMin;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label_SessionNo;
        private System.Windows.Forms.TabPage ToDo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_History;
        private System.Windows.Forms.ToolStripMenuItem Edit_History;
        private System.Windows.Forms.ToolStripMenuItem Delete_History;
        private System.Windows.Forms.Button button_Add_Todo;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage Notes;
        private System.Windows.Forms.RichTextBox richTextBox_Notes;
        private System.Windows.Forms.Button button_Save_Notes;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ToDo;
        private System.Windows.Forms.ToolStripMenuItem Completed;
        private System.Windows.Forms.ToolStripMenuItem Pending;
        private System.Windows.Forms.ToolStripMenuItem DeleteTodo;
        private System.Windows.Forms.ToolStripMenuItem EditTodo;
        private System.Windows.Forms.CheckBox checkBox_Sound;
    }
}

