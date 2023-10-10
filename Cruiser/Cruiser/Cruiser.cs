namespace Cruiser
{
    public partial class Cruiser : Form
    {
        /// <summary>
        /// Поле-объект для прорисовки объекта
        /// </summary>
        private DrawningCruiser? _drawningCruiser;

        public Cruiser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод прорисовки Крейсера
        /// </summary>
        private void Draw()
        {
            if (_drawningCruiser == null)
            {
                return;
            }
            Bitmap bmp = new(pictureBoxCruiser.Width,
            pictureBoxCruiser.Height);
            Graphics gr = Graphics.FromImage(bmp);
            _drawningCruiser.DrawTransport(gr);
            pictureBoxCruiser.Image = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random random = new();
            _drawningCruiser = new DrawningCruiser();
            _drawningCruiser.Init(random.Next(100, 300),
            random.Next(1000, 3000),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            Color.FromArgb(random.Next(0, 256), random.Next(0, 256),
            random.Next(0, 256)),
            pictureBoxCruiser.Width, pictureBoxCruiser.Height);
            _drawningCruiser.SetPosition(random.Next(10, 100),
            random.Next(pictureBoxCruiser.Height - 140, pictureBoxCruiser.Height - 40));
            Draw();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            if (_drawningCruiser == null)
            {
                return;
            }
            string name = ((Button)sender)?.Name ?? string.Empty;
            switch (name)
            {
                case "buttonUp":
                    _drawningCruiser.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    _drawningCruiser.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    _drawningCruiser.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    _drawningCruiser.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}