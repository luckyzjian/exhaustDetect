namespace exhaustDetect
{
    partial class DriverShow
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
            this.panelTs2 = new System.Windows.Forms.Panel();
            this.labelts2 = new System.Windows.Forms.Label();
            this.panelts1 = new System.Windows.Forms.Panel();
            this.labelTs1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelTs2.SuspendLayout();
            this.panelts1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTs2
            // 
            this.panelTs2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTs2.Controls.Add(this.labelts2);
            this.panelTs2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTs2.Location = new System.Drawing.Point(0, 430);
            this.panelTs2.Name = "panelTs2";
            this.panelTs2.Size = new System.Drawing.Size(1360, 431);
            this.panelTs2.TabIndex = 3;
            // 
            // labelts2
            // 
            this.labelts2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelts2.AutoSize = true;
            this.labelts2.Font = new System.Drawing.Font("宋体", 140F, System.Drawing.FontStyle.Bold);
            this.labelts2.ForeColor = System.Drawing.Color.Red;
            this.labelts2.Location = new System.Drawing.Point(292, 132);
            this.labelts2.Name = "labelts2";
            this.labelts2.Size = new System.Drawing.Size(831, 187);
            this.labelts2.TabIndex = 1;
            this.labelts2.Text = "设备待命";
            this.labelts2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panelts1
            // 
            this.panelts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelts1.Controls.Add(this.labelTs1);
            this.panelts1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelts1.Location = new System.Drawing.Point(0, 0);
            this.panelts1.Name = "panelts1";
            this.panelts1.Size = new System.Drawing.Size(1360, 430);
            this.panelts1.TabIndex = 2;
            // 
            // labelTs1
            // 
            this.labelTs1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTs1.AutoSize = true;
            this.labelTs1.Font = new System.Drawing.Font("宋体", 140F, System.Drawing.FontStyle.Bold);
            this.labelTs1.ForeColor = System.Drawing.Color.Red;
            this.labelTs1.Location = new System.Drawing.Point(188, 134);
            this.labelTs1.Name = "labelTs1";
            this.labelTs1.Size = new System.Drawing.Size(1021, 187);
            this.labelTs1.TabIndex = 0;
            this.labelTs1.Text = "01号环检线";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DriverShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1360, 742);
            this.Controls.Add(this.panelTs2);
            this.Controls.Add(this.panelts1);
            this.Name = "DriverShow";
            this.Text = "DriverShow";
            this.Load += new System.EventHandler(this.DriverShow_Load);
            this.panelTs2.ResumeLayout(false);
            this.panelTs2.PerformLayout();
            this.panelts1.ResumeLayout(false);
            this.panelts1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTs2;
        private System.Windows.Forms.Label labelts2;
        private System.Windows.Forms.Panel panelts1;
        private System.Windows.Forms.Label labelTs1;
        private System.Windows.Forms.Timer timer1;
    }
}