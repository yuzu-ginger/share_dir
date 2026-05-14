namespace DeJongAttractor
{
    partial class Form1
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
            _pictureBox = new PictureBox();
            _trackBarA = new TrackBar();
            _trackBarB = new TrackBar();
            _trackBarC = new TrackBar();
            _trackBarD = new TrackBar();
            _labelA = new Label();
            _labelB = new Label();
            _labelC = new Label();
            _labelD = new Label();
            ((System.ComponentModel.ISupportInitialize)_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarD).BeginInit();
            SuspendLayout();
            // 
            // _pictureBox
            // 
            _pictureBox.Location = new Point(2, 1);
            _pictureBox.Name = "_pictureBox";
            _pictureBox.Size = new Size(450, 450);
            _pictureBox.TabIndex = 0;
            _pictureBox.TabStop = false;
            // 
            // _trackBarA
            // 
            _trackBarA.Location = new Point(496, 25);
            _trackBarA.Maximum = 500;
            _trackBarA.Minimum = -500;
            _trackBarA.Name = "_trackBarA";
            _trackBarA.Size = new Size(130, 56);
            _trackBarA.TabIndex = 1;
            _trackBarA.ValueChanged += ParameterChanged;
            // 
            // _trackBarB
            // 
            _trackBarB.Location = new Point(496, 75);
            _trackBarB.Maximum = 500;
            _trackBarB.Minimum = -500;
            _trackBarB.Name = "_trackBarB";
            _trackBarB.Size = new Size(130, 56);
            _trackBarB.TabIndex = 2;
            _trackBarB.VisibleChanged += ParameterChanged;
            // 
            // _trackBarC
            // 
            _trackBarC.Location = new Point(496, 126);
            _trackBarC.Maximum = 500;
            _trackBarC.Minimum = -500;
            _trackBarC.Name = "_trackBarC";
            _trackBarC.Size = new Size(130, 56);
            _trackBarC.TabIndex = 3;
            _trackBarC.VisibleChanged += ParameterChanged;
            // 
            // _trackBarD
            // 
            _trackBarD.Location = new Point(496, 178);
            _trackBarD.Maximum = 500;
            _trackBarD.Minimum = -500;
            _trackBarD.Name = "_trackBarD";
            _trackBarD.Size = new Size(130, 56);
            _trackBarD.TabIndex = 4;
            _trackBarD.VisibleChanged += ParameterChanged;
            // 
            // _labelA
            // 
            _labelA.AutoSize = true;
            _labelA.Location = new Point(463, 27);
            _labelA.Name = "_labelA";
            _labelA.Size = new Size(17, 20);
            _labelA.TabIndex = 5;
            _labelA.Text = "a";
            // 
            // _labelB
            // 
            _labelB.AutoSize = true;
            _labelB.Location = new Point(463, 75);
            _labelB.Name = "_labelB";
            _labelB.Size = new Size(18, 20);
            _labelB.TabIndex = 6;
            _labelB.Text = "b";
            // 
            // _labelC
            // 
            _labelC.AutoSize = true;
            _labelC.Location = new Point(463, 126);
            _labelC.Name = "_labelC";
            _labelC.Size = new Size(16, 20);
            _labelC.TabIndex = 7;
            _labelC.Text = "c";
            // 
            // _labelD
            // 
            _labelD.AutoSize = true;
            _labelD.Location = new Point(463, 178);
            _labelD.Name = "_labelD";
            _labelD.Size = new Size(18, 20);
            _labelD.TabIndex = 8;
            _labelD.Text = "d";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(647, 450);
            Controls.Add(_labelD);
            Controls.Add(_labelC);
            Controls.Add(_labelB);
            Controls.Add(_labelA);
            Controls.Add(_trackBarD);
            Controls.Add(_trackBarC);
            Controls.Add(_trackBarB);
            Controls.Add(_trackBarA);
            Controls.Add(_pictureBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarA).EndInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarB).EndInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarC).EndInit();
            ((System.ComponentModel.ISupportInitialize)_trackBarD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox _pictureBox;
        private TrackBar _trackBarA;
        private TrackBar _trackBarB;
        private TrackBar _trackBarC;
        private TrackBar _trackBarD;
        private Label _labelA;
        private Label _labelB;
        private Label _labelC;
        private Label _labelD;
    }
}
