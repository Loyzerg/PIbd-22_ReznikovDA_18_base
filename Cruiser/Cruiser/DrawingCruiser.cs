using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cruiser
{
    /// <summary>
    /// Класс, отвечающий за прорисовку и перемещение объекта-сущности
    /// </summary>
    public class DrawningCruiser
    {
        /// <summary>
        /// Класс-сущность
        /// </summary>
        public EntityCruiser? EntityCruiser { get; private set; }
        /// <summary>
        /// Ширина окна
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Левая координата прорисовки Крейсера
        /// </summary>
        private int _startPosX;
        /// <summary>
        /// Верхняя кооридната прорисовки Крейсера
        /// </summary>
        private int _startPosY;
        /// <summary>
        /// Ширина прорисовки Крейсера
        /// </summary>
        private readonly int _cruiserWidth = 120;
        /// <summary>
        /// Высота прорисовки Крейсера
        /// </summary>
        private readonly int _cruiserHeight = 40;
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес</param>
        /// <param name="bodyColor">Цвет кузова</param>
        /// <param name="additionalColor">Дополнительный цвет</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        /// <returns>true - объект создан, false - проверка не пройдена, нельзя создать объект в этих размерах</returns>
        public bool Init(int speed, double weight, Color bodyColor, Color additionalColor, int width, int height)
        {
            if (_cruiserWidth > width || _cruiserHeight > height) return false;
            _pictureWidth = width;
            _pictureHeight = height;
            EntityCruiser = new EntityCruiser();
            EntityCruiser.Init(speed, weight, bodyColor, additionalColor);
            return true;
        }
        /// <summary>
        /// Установка позиции
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        public void SetPosition(int x, int y)
        {
            if (x > _pictureWidth - _cruiserWidth || y > _pictureHeight - _cruiserHeight)
            {
                x = 0;
                y = 0;
            }
            _startPosX = x;
            _startPosY = y;
        }
        /// <summary>
        /// Изменение направления перемещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            if (EntityCruiser == null)
        {
                return;
            }
            switch (direction)
            {
                //влево
                case Direction.Left:
                    if (_startPosX - EntityCruiser.Step > 0)
                    {
                        _startPosX -= (int)EntityCruiser.Step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - EntityCruiser.Step > 0)
                    {
                        _startPosY -= (int)EntityCruiser.Step;
                    }
                    break;
                // вправо
                case Direction.Right:
                    if (_startPosX + EntityCruiser.Step < _pictureWidth - _cruiserWidth)
                    {
                        _startPosX += (int)EntityCruiser.Step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + EntityCruiser.Step < _pictureHeight - _cruiserHeight)
                    {
                        _startPosY += (int)EntityCruiser.Step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Прорисовка объекта
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            if (EntityCruiser == null)
            {
                return;
            }
            Pen pen = new(Color.Black);
            Brush additionalBrush = new
            SolidBrush(EntityCruiser.AdditionalColor);

            //границы крейсера
            Point point1 = new Point(_startPosX + 3, _startPosY);
            Point point2 = new Point(_startPosX + 80, _startPosY);
            Point point3 = new Point(_startPosX + 120, _startPosY + 20);
            Point point4 = new Point(_startPosX + 80, _startPosY + 40);
            Point point5 = new Point(_startPosX + 3, _startPosY + 40);

            Point[] points =
            {
                point1, point2, point3, point4, point5
            };
            Brush br = new SolidBrush(EntityCruiser.BodyColor);
            g.FillPolygon(br, points);
            g.DrawPolygon(pen, points);
            // турбины
            Brush brBlack = new SolidBrush(Color.Black);

            g.FillRectangle(brBlack, _startPosX, _startPosY + 10, 3, 10);
            g.FillRectangle(brBlack, _startPosX, _startPosY + 21, 3, 10);

            //блоки на палубе
            Brush brBrown = new SolidBrush(Color.Brown);
            g.FillRectangle(additionalBrush, _startPosX + 30, _startPosY + 12, 30, 15);
            g.DrawRectangle(pen, _startPosX + 30, _startPosY + 12, 30, 15);

            g.FillRectangle(additionalBrush, _startPosX + 60, _startPosY + 5, 15, 30);
            g.DrawRectangle(pen, _startPosX + 60, _startPosY + 5, 15, 30);

            g.FillEllipse(brBrown, _startPosX + 80, _startPosY + 12, 15, 15);
            g.DrawEllipse(pen, _startPosX + 80, _startPosY + 12, 15, 15);
        }
    }
}
