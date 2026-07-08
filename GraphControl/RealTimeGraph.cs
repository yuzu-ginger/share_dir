using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GraphControl
{
    public partial class RealTimeGraph : UserControl
    {
        private readonly List<GraphPoint> _points = new List<GraphPoint>();

        private readonly float _margin = 0.1f;

        // 描画余白
        private const int LeftMargin = 45;
        private const int RightMargin = 15;
        private const int TopMargin = 15;
        private const int BottomMargin = 25;

        public float Min { get; set; }
        public float Max { get; set; }

        public bool AutoScale { get; set; } = true;

        public int VisibleCount { get; set; } = 100;

        public float HighThreshold { get; set; }
        public float LowThreshold { get; set; }

        public Color HighColor { get; set; } = Color.Red;
        public Color NormalColor { get; set; } = Color.Black;
        public Color LowColor { get; set; } = Color.Blue;

        public bool ShowPoint { get; set; } = true;
        public bool ShowAxis { get; set; } = true;

        public bool IsPaused { get; set; }

        public RealTimeGraph()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw,
                true);
        }

        public void AddPoint(float value)
        {
            if (IsPaused)
                return;

            _points.Add(new GraphPoint
            {
                Time = DateTime.Now,
                Value = value
            });

            Invalidate();
        }

        public void Clear()
        {
            _points.Clear();
            Invalidate();
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void ApplyAutoScale()
        {
            int start = Math.Max(0, _points.Count - VisibleCount);

            var visible = _points.Skip(start).ToList();

            if (visible.Count == 0)
                return;

            float min = visible.Min(p => p.Value);
            float max = visible.Max(p => p.Value);

            if (Math.Abs(max - min) < 0.0001f)
            {
                max += 1;
                min -= 1;
            }

            float range = max - min;

            Min = min - range * _margin;
            Max = max + range * _margin;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (_points.Count == 0)
                return;

            if (AutoScale)
                ApplyAutoScale();

            DrawAxis(e.Graphics);
            DrawGraph(e.Graphics);

            if (ShowPoint)
                DrawPoint(e.Graphics);
        }

        public void DrawAxis(Graphics g)
        {
            if (!ShowAxis)
                return;

            Rectangle area = GetGraphArea();

            using Pen pen = new Pen(Color.Black);

            // Y軸
            g.DrawLine(
                pen,
                area.Left,
                area.Top,
                area.Left,
                area.Bottom);

            // X軸
            g.DrawLine(
                pen,
                area.Left,
                area.Bottom,
                area.Right,
                area.Bottom);
        }

        public void DrawGraph(Graphics g)
        {
            int start = Math.Max(0, _points.Count - VisibleCount);

            var visible = _points.Skip(start).ToList();

            if (visible.Count < 2)
                return;

            for (int i = 1; i < visible.Count; i++)
            {
                PointF p1 = GetPoint(i - 1, visible[i - 1]);
                PointF p2 = GetPoint(i, visible[i]);

                using Pen pen = new Pen(GetColor(visible[i].Value), 2);

                g.DrawLine(pen, p1, p2);
            }
        }

        public void DrawPoint(Graphics g)
        {
            int start = Math.Max(0, _points.Count - VisibleCount);

            var visible = _points.Skip(start).ToList();

            foreach (var pair in visible.Select((p, i) => new { p, i }))
            {
                PointF pt = GetPoint(pair.i, pair.p);


                using Brush brush = new SolidBrush(GetColor(pair.p.Value));

                g.FillEllipse(
                    brush,
                    pt.X - 3,
                    pt.Y - 3,
                    6,
                    6);
            }
        }

        /// <summary>
        /// データ→画面座標
        /// </summary>
        private PointF GetPoint(int index, GraphPoint point)
        {
            Rectangle area = GetGraphArea();
            int count = Math.Min(_points.Count, VisibleCount);

            float x = count <= 1
                ? area.Left
                : area.Left + index * area.Width / (float)(count - 1);

            float range = Max - Min;

            if (Math.Abs(range) < 0.0001f)
                range = 1f;

            float yRatio = (point.Value - Min) / range;
            float y = area.Bottom - yRatio * area.Height;
            return new PointF(x, y);
        }

        private Color GetColor(float value)
        {
            if (value > HighThreshold)
                return HighColor;

            if (value < LowThreshold)
                return LowColor;

            return NormalColor;
        }

        private Rectangle GetGraphArea()
        {
            return new Rectangle(
                LeftMargin,
                TopMargin,
                Width - LeftMargin - RightMargin,
                Height - TopMargin - BottomMargin);
        }
    }
}