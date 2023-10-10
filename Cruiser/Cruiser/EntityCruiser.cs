using System;

namespace Cruiser
{

	/// <summary>
	/// Класс, который отвечает за объект "Крейсер"
	/// </summary>
	public class EntityCruiser
	{
            /// <summary>
            /// Скорость
            /// </summary>
        
        public int Speed { get; private set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; private set; }
        /// <summary>
        /// Основной цвет
        /// </summary>
        public Color BodyColor { get; private set; }
        /// <summary>
        /// Дополнительный цвет (для опциональных элементов)
        /// </summary>
        public Color AdditionalColor { get; private set; }
        /// <summary>
        /// Шаг перемещения крейсера
        /// </summary>
        public double Step => (double)Speed * 100 / Weight;
        /// <summary>
        /// Инициализация полей объекта-класса крейсера
        /// </summary>
        /// <param name="speed">Скорость</param>
        /// <param name="weight">Вес крейсера</param>
        /// <param name="bodyColor">Основной цвет</param>
        /// <param name="additionalColor">Дополнительный цвет</param>
        
        public void Init(int speed, double weight, Color bodyColor, Color
        additionalColor)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            AdditionalColor = additionalColor;
		}

	}
}