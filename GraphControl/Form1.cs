namespace GraphControl
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private double _x = 0;

        public Form1()
        {
            InitializeComponent();

            _realTimeGraph.VisibleCount = 120;
            _realTimeGraph.HighThreshold = 70;
            _realTimeGraph.LowThreshold = 30;
            _realTimeGraph.AutoScale = true;

            _timer.Interval = 50;
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            _x += 0.15;

            float value =
                50 +
                25 * (float)Math.Sin(_x) +
                (float)(Random.Shared.NextDouble() * 5 - 2.5);

            _realTimeGraph.AddPoint(value);
        }
    }
}
