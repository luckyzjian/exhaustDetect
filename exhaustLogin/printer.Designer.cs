namespace exhaustDetect
{
    partial class printer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.buttonCheckInHistory = new System.Windows.Forms.Button();
            this.buttonCheckToday = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.textBoxPlateAtWait = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGrid_waitcar = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.标记为已缴费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标记未领ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonDataseconds = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCopy = new System.Windows.Forms.TextBox();
            this.checkBoxCZ = new System.Windows.Forms.CheckBox();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.checkBoxSafeUnFinished = new System.Windows.Forms.CheckBox();
            this.checkBoxSafeFinished = new System.Windows.Forms.CheckBox();
            this.checkBoxExhaust = new System.Windows.Forms.CheckBox();
            this.checkBoxNoPrinted = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButtonThisMonth = new System.Windows.Forms.RadioButton();
            this.radioButtonThisWeek = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButtonToday = new System.Windows.Forms.RadioButton();
            this.补传检测数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_waitcar)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.dateTimeEnd);
            this.groupBox1.Controls.Add(this.dateTimeStart);
            this.groupBox1.Controls.Add(this.buttonCheckInHistory);
            this.groupBox1.Controls.Add(this.buttonCheckToday);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.textBoxPlateAtWait);
            this.groupBox1.Location = new System.Drawing.Point(2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(907, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(505, 21);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 20);
            this.label35.TabIndex = 115;
            this.label35.Text = "至";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dateTimeEnd.Location = new System.Drawing.Point(532, 21);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(121, 23);
            this.dateTimeEnd.TabIndex = 114;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Font = new System.Drawing.Font("宋体", 10.5F);
            this.dateTimeStart.Location = new System.Drawing.Point(379, 21);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(121, 23);
            this.dateTimeStart.TabIndex = 113;
            // 
            // buttonCheckInHistory
            // 
            this.buttonCheckInHistory.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonCheckInHistory.Location = new System.Drawing.Point(659, 17);
            this.buttonCheckInHistory.Name = "buttonCheckInHistory";
            this.buttonCheckInHistory.Size = new System.Drawing.Size(110, 30);
            this.buttonCheckInHistory.TabIndex = 91;
            this.buttonCheckInHistory.Text = "历史查询";
            this.buttonCheckInHistory.UseVisualStyleBackColor = true;
            this.buttonCheckInHistory.Click += new System.EventHandler(this.buttonCheckInHistory_Click);
            // 
            // buttonCheckToday
            // 
            this.buttonCheckToday.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonCheckToday.Location = new System.Drawing.Point(241, 17);
            this.buttonCheckToday.Name = "buttonCheckToday";
            this.buttonCheckToday.Size = new System.Drawing.Size(110, 30);
            this.buttonCheckToday.TabIndex = 90;
            this.buttonCheckToday.Text = "当日查询";
            this.buttonCheckToday.UseVisualStyleBackColor = true;
            this.buttonCheckToday.Click += new System.EventHandler(this.buttonCheckToday_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(26, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 89;
            this.label21.Text = "车牌号";
            // 
            // textBoxPlateAtWait
            // 
            this.textBoxPlateAtWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlateAtWait.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBoxPlateAtWait.ForeColor = System.Drawing.Color.Black;
            this.textBoxPlateAtWait.Location = new System.Drawing.Point(88, 20);
            this.textBoxPlateAtWait.Name = "textBoxPlateAtWait";
            this.textBoxPlateAtWait.Size = new System.Drawing.Size(130, 25);
            this.textBoxPlateAtWait.TabIndex = 88;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(2, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 438);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "机动车列表";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGrid_waitcar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 418);
            this.panel1.TabIndex = 2;
            // 
            // dataGrid_waitcar
            // 
            this.dataGrid_waitcar.AllowUserToAddRows = false;
            this.dataGrid_waitcar.AllowUserToDeleteRows = false;
            this.dataGrid_waitcar.AllowUserToResizeColumns = false;
            this.dataGrid_waitcar.AllowUserToResizeRows = false;
            this.dataGrid_waitcar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid_waitcar.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGrid_waitcar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid_waitcar.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGrid_waitcar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_waitcar.Location = new System.Drawing.Point(0, 0);
            this.dataGrid_waitcar.MultiSelect = false;
            this.dataGrid_waitcar.Name = "dataGrid_waitcar";
            this.dataGrid_waitcar.ReadOnly = true;
            this.dataGrid_waitcar.RowHeadersVisible = false;
            this.dataGrid_waitcar.RowTemplate.Height = 23;
            this.dataGrid_waitcar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid_waitcar.Size = new System.Drawing.Size(731, 418);
            this.dataGrid_waitcar.TabIndex = 1;
            this.dataGrid_waitcar.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标记为已缴费ToolStripMenuItem,
            this.标记未领ToolStripMenuItem,
            this.补传检测数据ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 92);
            // 
            // 标记为已缴费ToolStripMenuItem
            // 
            this.标记为已缴费ToolStripMenuItem.Name = "标记为已缴费ToolStripMenuItem";
            this.标记为已缴费ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.标记为已缴费ToolStripMenuItem.Text = "标记报告已领";
            this.标记为已缴费ToolStripMenuItem.Click += new System.EventHandler(this.标记为已缴费ToolStripMenuItem_Click);
            // 
            // 标记未领ToolStripMenuItem
            // 
            this.标记未领ToolStripMenuItem.Name = "标记未领ToolStripMenuItem";
            this.标记未领ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.标记未领ToolStripMenuItem.Text = "标记报告未领";
            this.标记未领ToolStripMenuItem.Click += new System.EventHandler(this.标记未领ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.buttonDataseconds);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxCopy);
            this.groupBox3.Controls.Add(this.checkBoxCZ);
            this.groupBox3.Controls.Add(this.buttonPrint);
            this.groupBox3.Controls.Add(this.checkBoxSafeUnFinished);
            this.groupBox3.Controls.Add(this.checkBoxSafeFinished);
            this.groupBox3.Controls.Add(this.checkBoxExhaust);
            this.groupBox3.Controls.Add(this.checkBoxNoPrinted);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.radioButtonThisMonth);
            this.groupBox3.Controls.Add(this.radioButtonThisWeek);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.radioButtonToday);
            this.groupBox3.Location = new System.Drawing.Point(745, 64);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(164, 438);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button2.Location = new System.Drawing.Point(24, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 30);
            this.button2.TabIndex = 104;
            this.button2.Text = "过程数据";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonDataseconds
            // 
            this.buttonDataseconds.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonDataseconds.Location = new System.Drawing.Point(24, 92);
            this.buttonDataseconds.Name = "buttonDataseconds";
            this.buttonDataseconds.Size = new System.Drawing.Size(110, 30);
            this.buttonDataseconds.TabIndex = 103;
            this.buttonDataseconds.Text = "过程数据曲线";
            this.buttonDataseconds.UseVisualStyleBackColor = true;
            this.buttonDataseconds.Click += new System.EventHandler(this.buttonDataseconds_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(85, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 102;
            this.label1.Text = "份";
            // 
            // textBoxCopy
            // 
            this.textBoxCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCopy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxCopy.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.textBoxCopy.ForeColor = System.Drawing.Color.Black;
            this.textBoxCopy.Location = new System.Drawing.Point(24, 164);
            this.textBoxCopy.Name = "textBoxCopy";
            this.textBoxCopy.Size = new System.Drawing.Size(55, 25);
            this.textBoxCopy.TabIndex = 101;
            // 
            // checkBoxCZ
            // 
            this.checkBoxCZ.AutoSize = true;
            this.checkBoxCZ.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxCZ.Location = new System.Drawing.Point(29, 222);
            this.checkBoxCZ.Name = "checkBoxCZ";
            this.checkBoxCZ.Size = new System.Drawing.Size(116, 19);
            this.checkBoxCZ.TabIndex = 100;
            this.checkBoxCZ.Text = "显示车主信息";
            this.checkBoxCZ.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Font = new System.Drawing.Font("宋体", 10.5F);
            this.buttonPrint.Location = new System.Drawing.Point(24, 128);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(110, 30);
            this.buttonPrint.TabIndex = 92;
            this.buttonPrint.Text = "打印报告";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Visible = false;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // checkBoxSafeUnFinished
            // 
            this.checkBoxSafeUnFinished.AutoSize = true;
            this.checkBoxSafeUnFinished.Checked = true;
            this.checkBoxSafeUnFinished.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSafeUnFinished.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxSafeUnFinished.Location = new System.Drawing.Point(29, 298);
            this.checkBoxSafeUnFinished.Name = "checkBoxSafeUnFinished";
            this.checkBoxSafeUnFinished.Size = new System.Drawing.Size(101, 19);
            this.checkBoxSafeUnFinished.TabIndex = 99;
            this.checkBoxSafeUnFinished.Text = "安检未完成";
            this.checkBoxSafeUnFinished.UseVisualStyleBackColor = true;
            this.checkBoxSafeUnFinished.Visible = false;
            // 
            // checkBoxSafeFinished
            // 
            this.checkBoxSafeFinished.AutoSize = true;
            this.checkBoxSafeFinished.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxSafeFinished.Location = new System.Drawing.Point(29, 273);
            this.checkBoxSafeFinished.Name = "checkBoxSafeFinished";
            this.checkBoxSafeFinished.Size = new System.Drawing.Size(101, 19);
            this.checkBoxSafeFinished.TabIndex = 98;
            this.checkBoxSafeFinished.Text = "安检已完成";
            this.checkBoxSafeFinished.UseVisualStyleBackColor = true;
            this.checkBoxSafeFinished.Visible = false;
            // 
            // checkBoxExhaust
            // 
            this.checkBoxExhaust.AutoSize = true;
            this.checkBoxExhaust.Checked = true;
            this.checkBoxExhaust.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxExhaust.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxExhaust.Location = new System.Drawing.Point(29, 249);
            this.checkBoxExhaust.Name = "checkBoxExhaust";
            this.checkBoxExhaust.Size = new System.Drawing.Size(86, 19);
            this.checkBoxExhaust.TabIndex = 97;
            this.checkBoxExhaust.Text = "环保检查";
            this.checkBoxExhaust.UseVisualStyleBackColor = true;
            this.checkBoxExhaust.Visible = false;
            // 
            // checkBoxNoPrinted
            // 
            this.checkBoxNoPrinted.AutoSize = true;
            this.checkBoxNoPrinted.Checked = true;
            this.checkBoxNoPrinted.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNoPrinted.Font = new System.Drawing.Font("宋体", 11F);
            this.checkBoxNoPrinted.Location = new System.Drawing.Point(29, 197);
            this.checkBoxNoPrinted.Name = "checkBoxNoPrinted";
            this.checkBoxNoPrinted.Size = new System.Drawing.Size(101, 19);
            this.checkBoxNoPrinted.TabIndex = 96;
            this.checkBoxNoPrinted.Text = "未领取报告";
            this.checkBoxNoPrinted.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button3.Location = new System.Drawing.Point(29, 403);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 30);
            this.button3.TabIndex = 95;
            this.button3.Text = "刷新数据";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButtonThisMonth
            // 
            this.radioButtonThisMonth.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonThisMonth.AutoSize = true;
            this.radioButtonThisMonth.Font = new System.Drawing.Font("宋体", 10.5F);
            this.radioButtonThisMonth.Location = new System.Drawing.Point(52, 379);
            this.radioButtonThisMonth.Name = "radioButtonThisMonth";
            this.radioButtonThisMonth.Size = new System.Drawing.Size(53, 18);
            this.radioButtonThisMonth.TabIndex = 94;
            this.radioButtonThisMonth.Text = "本月";
            this.radioButtonThisMonth.UseVisualStyleBackColor = true;
            // 
            // radioButtonThisWeek
            // 
            this.radioButtonThisWeek.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonThisWeek.AutoSize = true;
            this.radioButtonThisWeek.Font = new System.Drawing.Font("宋体", 10.5F);
            this.radioButtonThisWeek.Location = new System.Drawing.Point(52, 355);
            this.radioButtonThisWeek.Name = "radioButtonThisWeek";
            this.radioButtonThisWeek.Size = new System.Drawing.Size(53, 18);
            this.radioButtonThisWeek.TabIndex = 93;
            this.radioButtonThisWeek.Text = "本周";
            this.radioButtonThisWeek.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.button1.Location = new System.Drawing.Point(24, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 91;
            this.button1.Text = "查看报告";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButtonToday
            // 
            this.radioButtonToday.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioButtonToday.AutoSize = true;
            this.radioButtonToday.Checked = true;
            this.radioButtonToday.Font = new System.Drawing.Font("宋体", 10.5F);
            this.radioButtonToday.Location = new System.Drawing.Point(52, 331);
            this.radioButtonToday.Name = "radioButtonToday";
            this.radioButtonToday.Size = new System.Drawing.Size(53, 18);
            this.radioButtonToday.TabIndex = 92;
            this.radioButtonToday.TabStop = true;
            this.radioButtonToday.Text = "当天";
            this.radioButtonToday.UseVisualStyleBackColor = true;
            // 
            // 补传检测数据ToolStripMenuItem
            // 
            this.补传检测数据ToolStripMenuItem.Name = "补传检测数据ToolStripMenuItem";
            this.补传检测数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.补传检测数据ToolStripMenuItem.Text = "补传检测数据";
            this.补传检测数据ToolStripMenuItem.Click += new System.EventHandler(this.补传检测数据ToolStripMenuItem_Click);
            // 
            // printer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 504);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "printer";
            this.Text = "报告单打印";
            this.Load += new System.EventHandler(this.printer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_waitcar)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonCheckInHistory;
        private System.Windows.Forms.Button buttonCheckToday;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBoxPlateAtWait;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGrid_waitcar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonThisMonth;
        private System.Windows.Forms.RadioButton radioButtonThisWeek;
        private System.Windows.Forms.RadioButton radioButtonToday;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 标记为已缴费ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxNoPrinted;
        private System.Windows.Forms.CheckBox checkBoxSafeFinished;
        private System.Windows.Forms.CheckBox checkBoxExhaust;
        private System.Windows.Forms.CheckBox checkBoxSafeUnFinished;
        private System.Windows.Forms.ToolStripMenuItem 标记未领ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBoxCZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCopy;
        private System.Windows.Forms.Button buttonDataseconds;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.ToolStripMenuItem 补传检测数据ToolStripMenuItem;
    }
}