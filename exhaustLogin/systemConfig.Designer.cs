namespace exhaustDetect
{
    partial class systemConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(systemConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoPrint = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxPrinter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonSelectShy = new System.Windows.Forms.Button();
            this.comboBoxSHY = new System.Windows.Forms.ComboBox();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxAutoPrint);
            this.groupBox1.Controls.Add(this.buttonCancel);
            this.groupBox1.Controls.Add(this.buttonOK);
            this.groupBox1.Controls.Add(this.comboBoxPrinter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印机设置";
            // 
            // checkBoxAutoPrint
            // 
            this.checkBoxAutoPrint.AutoSize = true;
            this.checkBoxAutoPrint.Enabled = false;
            this.checkBoxAutoPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.checkBoxAutoPrint.Location = new System.Drawing.Point(150, 64);
            this.checkBoxAutoPrint.Name = "checkBoxAutoPrint";
            this.checkBoxAutoPrint.Size = new System.Drawing.Size(112, 24);
            this.checkBoxAutoPrint.TabIndex = 95;
            this.checkBoxAutoPrint.Text = "是否自动打印";
            this.checkBoxAutoPrint.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(97, 105);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(207, 105);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "确认";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // comboBoxPrinter
            // 
            this.comboBoxPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPrinter.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBoxPrinter.FormattingEnabled = true;
            this.comboBoxPrinter.Location = new System.Drawing.Point(107, 20);
            this.comboBoxPrinter.Name = "comboBoxPrinter";
            this.comboBoxPrinter.Size = new System.Drawing.Size(276, 27);
            this.comboBoxPrinter.TabIndex = 93;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 92;
            this.label1.Text = "选择打印机";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1154, 584);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox23);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1146, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "打印机设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.button2);
            this.groupBox23.Controls.Add(this.buttonSelectShy);
            this.groupBox23.Controls.Add(this.comboBoxSHY);
            this.groupBox23.Controls.Add(this.label57);
            this.groupBox23.Location = new System.Drawing.Point(6, 155);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(403, 99);
            this.groupBox23.TabIndex = 1;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "报告单设置";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(97, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonSelectShy
            // 
            this.buttonSelectShy.Location = new System.Drawing.Point(207, 63);
            this.buttonSelectShy.Name = "buttonSelectShy";
            this.buttonSelectShy.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectShy.TabIndex = 1;
            this.buttonSelectShy.Text = "确认";
            this.buttonSelectShy.UseVisualStyleBackColor = true;
            this.buttonSelectShy.Click += new System.EventHandler(this.buttonSelectShy_Click);
            // 
            // comboBoxSHY
            // 
            this.comboBoxSHY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSHY.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.comboBoxSHY.FormattingEnabled = true;
            this.comboBoxSHY.Location = new System.Drawing.Point(173, 20);
            this.comboBoxSHY.Name = "comboBoxSHY";
            this.comboBoxSHY.Size = new System.Drawing.Size(98, 27);
            this.comboBoxSHY.TabIndex = 93;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.ForeColor = System.Drawing.Color.DarkGreen;
            this.label57.Location = new System.Drawing.Point(116, 22);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(51, 20);
            this.label57.TabIndex = 92;
            this.label57.Text = "审核员";
            // 
            // systemConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 584);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "systemConfig";
            this.Text = "本线设置";
            this.Load += new System.EventHandler(this.systemConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxPrinter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxAutoPrint;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSelectShy;
        private System.Windows.Forms.ComboBox comboBoxSHY;
        private System.Windows.Forms.Label label57;
    }
}