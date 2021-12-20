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
            this.генераторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.количесвтоПланетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planetsCountComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.isRingNecessary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.generateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sunAttractionTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedParticleSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.asteroidsSpeedTrack = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.sunAttractionRadiusTrack = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sunAttractionTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedParticleSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asteroidsSpeedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sunAttractionRadiusTrack)).BeginInit();
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
            this.параметрыToolStripMenuItem,
            this.генераторToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1734, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeAttractionVision});
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
            // генераторToolStripMenuItem
            // 
            this.генераторToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.количесвтоПланетToolStripMenuItem,
            this.isRingNecessary,
            this.toolStripSeparator2,
            this.generateBtn});
            this.генераторToolStripMenuItem.Name = "генераторToolStripMenuItem";
            this.генераторToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.генераторToolStripMenuItem.Text = "Генератор";
            // 
            // количесвтоПланетToolStripMenuItem
            // 
            this.количесвтоПланетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planetsCountComboBox});
            this.количесвтоПланетToolStripMenuItem.Name = "количесвтоПланетToolStripMenuItem";
            this.количесвтоПланетToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.количесвтоПланетToolStripMenuItem.Text = "Количесвто планет";
            // 
            // planetsCountComboBox
            // 
            this.planetsCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.planetsCountComboBox.Name = "planetsCountComboBox";
            this.planetsCountComboBox.Size = new System.Drawing.Size(121, 23);
            this.planetsCountComboBox.Text = "1";
            this.planetsCountComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.planetsCountComboBox_KeyPress);
            this.planetsCountComboBox.TextChanged += new System.EventHandler(this.planetsCountComboBox_TextChanged);
            // 
            // isRingNecessary
            // 
            this.isRingNecessary.Name = "isRingNecessary";
            this.isRingNecessary.Size = new System.Drawing.Size(245, 22);
            this.isRingNecessary.Text = "Создавать астероидное кольцо";
            this.isRingNecessary.Click += new System.EventHandler(this.isRingNecessary_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // generateBtn
            // 
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(245, 22);
            this.generateBtn.Text = "Создать новую систему";
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // sunAttractionTrackBar
            // 
            this.sunAttractionTrackBar.Location = new System.Drawing.Point(1541, 52);
            this.sunAttractionTrackBar.Maximum = 50;
            this.sunAttractionTrackBar.Minimum = -50;
            this.sunAttractionTrackBar.Name = "sunAttractionTrackBar";
            this.sunAttractionTrackBar.Size = new System.Drawing.Size(181, 45);
            this.sunAttractionTrackBar.TabIndex = 1;
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
            this.selectedParticleSpeed.Location = new System.Drawing.Point(1541, 184);
            this.selectedParticleSpeed.Maximum = 100;
            this.selectedParticleSpeed.Name = "selectedParticleSpeed";
            this.selectedParticleSpeed.Size = new System.Drawing.Size(181, 45);
            this.selectedParticleSpeed.TabIndex = 3;
            this.selectedParticleSpeed.Scroll += new System.EventHandler(this.selectedParticleSpeed_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1541, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Скорость выбранной частицы:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1541, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Общая скорость астероидов:";
            // 
            // asteroidsSpeedTrack
            // 
            this.asteroidsSpeedTrack.Enabled = false;
            this.asteroidsSpeedTrack.Location = new System.Drawing.Point(1541, 250);
            this.asteroidsSpeedTrack.Maximum = 100;
            this.asteroidsSpeedTrack.Name = "asteroidsSpeedTrack";
            this.asteroidsSpeedTrack.Size = new System.Drawing.Size(181, 45);
            this.asteroidsSpeedTrack.TabIndex = 4;
            this.asteroidsSpeedTrack.Value = 100;
            this.asteroidsSpeedTrack.Scroll += new System.EventHandler(this.asteroidsSpeedTrack_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1541, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Радиус притяжения солнца:";
            // 
            // sunAttractionRadiusTrack
            // 
            this.sunAttractionRadiusTrack.Location = new System.Drawing.Point(1541, 118);
            this.sunAttractionRadiusTrack.Maximum = 1000;
            this.sunAttractionRadiusTrack.Name = "sunAttractionRadiusTrack";
            this.sunAttractionRadiusTrack.Size = new System.Drawing.Size(181, 45);
            this.sunAttractionRadiusTrack.TabIndex = 2;
            this.sunAttractionRadiusTrack.Value = 450;
            this.sunAttractionRadiusTrack.Scroll += new System.EventHandler(this.sunAttractionRadiusTrack_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 961);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sunAttractionRadiusTrack);
            this.Controls.Add(this.asteroidsSpeedTrack);
            this.Controls.Add(this.label3);
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
            ((System.ComponentModel.ISupportInitialize)(this.asteroidsSpeedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sunAttractionRadiusTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeAttractionVision;
        private System.Windows.Forms.TrackBar sunAttractionTrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar selectedParticleSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar asteroidsSpeedTrack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar sunAttractionRadiusTrack;
        private System.Windows.Forms.ToolStripMenuItem генераторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem количесвтоПланетToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox planetsCountComboBox;
        private System.Windows.Forms.ToolStripMenuItem isRingNecessary;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem generateBtn;
    }
}
