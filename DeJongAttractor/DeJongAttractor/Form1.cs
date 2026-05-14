using DeJongAttractor.Models;
namespace DeJongAttractor
{
    public partial class Form1 : Form
    {
        private Bitmap? _currectBitmap;
        private readonly DeJongGenerator _generator = new DeJongGenerator();
        private readonly AttractorRenderer _renderer = new AttractorRenderer();
        private AttractorParameters _parameters = new AttractorParameters();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Render();
        }

        // TrackBarのValueChangedイベントに以下を追加(A~Dすべて)
        private void ParameterChanged(object sender, EventArgs e)
        {
            _parameters.A = _trackBarA.Value / 100.0;
            _parameters.B = _trackBarB.Value / 100.0;
            _parameters.C = _trackBarC.Value / 100.0;
            _parameters.D = _trackBarD.Value / 100.0;

            Render();
        }

        private void Render()
        {
            _currectBitmap?.Dispose();
            var points = _generator.Generate(_parameters, 200000);
            _currectBitmap = _renderer.Render(
                points,
                _pictureBox.Width,
                _pictureBox.Height);
            _pictureBox.Image = _currectBitmap;
        }

        // TODO
        // パラメータの値を表示(labelValueA~Dを追加)
        // Value.Text = parameters.A.ToString("F5"); // ParameterChanged()
        // カラー変換をHelperに追記
        // 色のTrackBarも追加(0~360の範囲)->ParamChangedのたびにランダム生成
    }
}
