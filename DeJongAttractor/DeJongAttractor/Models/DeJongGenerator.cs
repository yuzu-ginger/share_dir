// Attractor の数式
namespace DeJongAttractor.Models
{
    internal class DeJongGenerator
    {
        public List<PointF> Generate(AttractorParameters p, int iterations)
        {
            List<PointF> points = new List<PointF>();
            double x = 1.0;
            double y = 1.0;
            
            for(int i = 0; i < iterations; i++)
            {
                double nextX = Math.Sin(p.A * y) - Math.Cos(p.B * x);
                double nextY = Math.Sin(p.C * x) - Math.Cos(p.D * y);

                points.Add(new PointF((float)nextX, (float)nextY));

                x = nextX;
                y = nextY;
            }
            return points;
        }
    }
}
