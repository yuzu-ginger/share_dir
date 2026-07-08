namespace GraphControl
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
            _realTimeGraph = new RealTimeGraph();
            SuspendLayout();
            // 
            // _realTimeGraph
            // 
            _realTimeGraph.AutoScale = true;
            _realTimeGraph.HighColor = Color.Red;
            _realTimeGraph.HighThreshold = 0F;
            _realTimeGraph.IsPaused = false;
            _realTimeGraph.Location = new Point(12, 12);
            _realTimeGraph.LowColor = Color.Blue;
            _realTimeGraph.LowThreshold = 0F;
            _realTimeGraph.Max = 0F;
            _realTimeGraph.Min = 0F;
            _realTimeGraph.Name = "_realTimeGraph";
            _realTimeGraph.NormalColor = Color.Black;
            _realTimeGraph.ShowAxis = true;
            _realTimeGraph.ShowPoint = true;
            _realTimeGraph.Size = new Size(557, 403);
            _realTimeGraph.TabIndex = 0;
            _realTimeGraph.VisibleCount = 30;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_realTimeGraph);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RealTimeGraph _realTimeGraph;
    }
}
