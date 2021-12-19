namespace ParticleSystem
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAttractionVision = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sunAttractionTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedParticleSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sunAttractionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedParticleSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picDisplay.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.picDisplay.Location = new System.Drawing.Point(12, 27);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(1523, 922);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAttractionVision,
            this.toolStripSeparator1,
            this.generateBtn});
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // changeAttractionVision
            // 
            this.changeAttractionVision.Checked = true;
            this.changeAttractionVision.CheckOnClick = true;
            this.changeAttractionVision.CheckState = System.Windows.Forms.CheckState.Checked;
            this.changeAttractionVision.Name = "changeAttractionVision";
            this.changeAttractionVision.Size = new System.Drawing.Size(259, 22);
            this.changeAttractionVision.Text = "Отображать области притяжения";
            this.changeAttractionVision.Click += new System.EventHandler(this.changeAttractionVision_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(256, 6);
            // 
            // generateBtn
            // 
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(259, 22);
            this.generateBtn.Text = "Создать новуюс систему";
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // sunAttractionTrackBar
            // 
            this.sunAttractionTrackBar.Location = new System.Drawing.Point(1541, 52);
            this.sunAttractionTrackBar.Maximum = 50;
            this.sunAttractionTrackBar.Minimum = -50;
            this.sunAttractionTrackBar.Name = "sunAttractionTrackBar";
            this.sunAttractionTrackBar.Size = new System.Drawing.Size(181, 45);
            this.sunAttractionTrackBar.TabIndex = 3;
            this.sunAttractionTrackBar.Value = 10;
            this.sunAttractionTrackBar.Scroll += new System.EventHandler(this.sunAttractionTrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1541, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Притяжение солнца:";
            // 
            // selectedParticleSpeed
            // 
            this.selectedParticleSpeed.Enabled = false;
            this.selectedParticleSpeed.Location = new System.Drawing.Point(1541, 118);
            this.selectedParticleSpeed.Maximum = 100;
            this.selectedParticleSpeed.Name = "selectedParticleSpeed";
            this.selectedParticleSpeed.Size = new System.Drawing.Size(181, 45);
            this.selectedParticleSpeed.TabIndex = 5;
            this.selectedParticleSpeed.Scroll += new System.EventHandler(this.selectedParticleSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1541, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Скорость выбранной частицы:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 961);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedParticleSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sunAttractionTrackBar);
            this.Controls.Add(this.picDisplay);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Солненчная система";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sunAttractionTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedParticleSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAttractionVision;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generateBtn;
        private System.Windows.Forms.TrackBar sunAttractionTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar selectedParticleSpeed;
        private System.Windows.Forms.Label label2;
    }
}
