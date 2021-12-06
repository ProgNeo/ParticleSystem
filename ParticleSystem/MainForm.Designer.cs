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
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.cbColorPoint = new System.Windows.Forms.ComboBox();
            this.tbGraviton = new System.Windows.Forms.TrackBar();
            this.spreading = new System.Windows.Forms.Label();
            this.direction = new System.Windows.Forms.Label();
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(900, 488);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseClick);
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(215, 521);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(0, 15);
            this.lblDirection.TabIndex = 3;
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(473, 521);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(0, 15);
            this.lblSpreading.TabIndex = 6;
            // 
            // cbColorPoint
            // 
            this.cbColorPoint.FormattingEnabled = true;
            this.cbColorPoint.Items.AddRange(new object[] {
            "Красный",
            "Ораньжевый",
            "Жёлтый",
            "Зелёный",
            "Голубой",
            "Синий",
            "Фиолетовый"});
            this.cbColorPoint.Location = new System.Drawing.Point(612, 521);
            this.cbColorPoint.Name = "cbColorPoint";
            this.cbColorPoint.Size = new System.Drawing.Size(121, 23);
            this.cbColorPoint.TabIndex = 9;
            this.cbColorPoint.Text = "Красный";
            // 
            // tbGraviton
            // 
            this.tbGraviton.Location = new System.Drawing.Point(479, 521);
            this.tbGraviton.Maximum = 100;
            this.tbGraviton.Name = "tbGraviton";
            this.tbGraviton.Size = new System.Drawing.Size(79, 45);
            this.tbGraviton.TabIndex = 7;
            this.tbGraviton.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbGraviton.Value = 1;
            this.tbGraviton.Scroll += new System.EventHandler(this.tbGraviton_Scroll);
            // 
            // spreading
            // 
            this.spreading.AutoSize = true;
            this.spreading.Location = new System.Drawing.Point(270, 503);
            this.spreading.Name = "spreading";
            this.spreading.Size = new System.Drawing.Size(52, 15);
            this.spreading.TabIndex = 5;
            this.spreading.Text = "Разброс";
            // 
            // direction
            // 
            this.direction.AutoSize = true;
            this.direction.Location = new System.Drawing.Point(12, 503);
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(81, 15);
            this.direction.TabIndex = 2;
            this.direction.Text = "Направление";
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(12, 521);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(197, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(270, 521);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(197, 45);
            this.tbSpreading.TabIndex = 4;
            this.tbSpreading.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSpreading.Value = 10;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 634);
            this.Controls.Add(this.cbColorPoint);
            this.Controls.Add(this.tbGraviton);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.spreading);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.direction);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGraviton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.ComboBox cbColorPoint;
        private System.Windows.Forms.TrackBar tbGraviton;
        private System.Windows.Forms.Label spreading;
        private System.Windows.Forms.Label direction;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpreading;
    }
}
