using FigureAreaCalculationLibrary.Validation;
using System.ComponentModel.DataAnnotations;

namespace FigureAreaCalculationLibrary
{
    public class Circle : Figure
    {
        private double _radius;

        /// <summary>
        /// Радиус круга.
        /// </summary>
        [NegativeValue]
        public double Radius { get => _radius; set => _radius = value; }

        private Circle(double radius)
        {
            _radius = radius;
        }

        /// <summary>
        /// Создаёт круг заданного радиуса.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">Если радиус меньше, либо равен нулю.</exception>
        public static Circle CreateCircle(double radius)
        {
            var circle = new Circle(radius);

            var results = new List<ValidationResult>();
            var context = new ValidationContext(circle);
            if (!Validator.TryValidateObject(circle, context, results, true))
            {
                foreach (var error in results)
                {
                    throw new ArgumentOutOfRangeException($"{error.ErrorMessage}");
                }
            }
            return circle;
        }
        /// <summary>
        /// Выполняет расчёт площади круга по радиусу.
        /// </summary>
        /// <param name="round">Округлить до указанного значения (0-15).</param>
        /// <returns></returns>
        protected override double CalculateArea(int round)
        {
            return Math.Round(Math.PI * Math.Pow(_radius, 2), round);
        }
    }
}
