// 描画関連
namespace DeJongAttractor.Models
{
    internal class AttractorRenderer
    {
        public Bitmap Render(List<PointF> points, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);

            // TODO colorhelperを使ってHSV -> RGB変換
            Color color = Color.FromArgb(30, 0, 255, 255);
            foreach(var p in points)
            {
                float px = p.X * 100 + width / 2f;
                float py = p.Y * 100 + height / 2f;
                bmp.SetPixel((int)px, (int)py, color);
            }
            return bmp;
        }
    }
}
