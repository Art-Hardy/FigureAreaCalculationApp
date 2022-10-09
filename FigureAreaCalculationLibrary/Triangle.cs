using FigureAreaCalculationLibrary.Validation;
using System.ComponentModel.DataAnnotations;

namespace FigureAreaCalculationLibrary
{
    [ExistTriangleValidation]
    public class Triangle : Figure
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;
        private readonly bool _isRightAngled;

        #region Стороны треугольника.
        [NegativeValue]
        public double FirstSide { get => _firstSide; set => _firstSide = value; }
        [NegativeValue]
        public double SecondSide { get => _secondSide; set => _secondSide = value; }
        [NegativeValue]
        public double ThirdSide { get => _thirdSide; set => _thirdSide = value; } 
        #endregion
        /// <summary>
        /// Треугольник является прямоугольным.
        /// </summary>
        public bool IsRightAngled { get => _isRightAngled; }

        private Triangle(double firstSide, double secondSide, double thirdSide)
        {
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;

            _isRightAngled = CheckIsRightAngled();
        }

        /// <summary>
        /// Создаёт треугольник с заданными сторонами.
        /// </summary>
        /// <param name="firstSide">Сторона 1.</param>
        /// <param name="secondSide">Сторона 2.</param>
        /// <param name="thirdSide">Сторона 3.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Если заданы не положительные стороны или если треугольник с заданными сторонами не существует.</exception>
        public static Triangle CreateTriangle(double firstSide, double secondSide, double thirdSide)
        {
            var triangle = new Triangle(firstSide, secondSide, thirdSide);

            var result = new List<ValidationResult>();
            var context = new ValidationContext(triangle);
            if (!Validator.TryValidateObject(triangle, context, result, true))
            {
                foreach (var error in result)
                {
                    throw new Exception(error.ErrorMessage);
                }
            }

            return triangle;
        }
        /// <summary>
        /// Выполняет расчёт площади треугольника по трём сторонам.
        /// </summary>
        /// <param name="round"></param>
        /// <returns></returns>
        protected override double CalculateArea(int round)
        {
            var semiPerimeter = (_firstSide + _secondSide + _thirdSide) / 2;

            return Math.Round(
                Math.Sqrt(semiPerimeter * (semiPerimeter - _firstSide) * (semiPerimeter - _secondSide) * (semiPerimeter - _thirdSide)),
                round);
        }
        /// <summary>
        /// Проверят, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns></returns>
        private bool CheckIsRightAngled()
        {
            if (_firstSide > _secondSide && _firstSide > _thirdSide)
            {
                return TriangleRightAngledFormula(_firstSide, _secondSide, _thirdSide);
            }
            else if (_secondSide > _firstSide && _secondSide > _thirdSide)
            {
                return TriangleRightAngledFormula(_secondSide, _firstSide, _thirdSide);
            }
            else
            {
                return TriangleRightAngledFormula(_thirdSide, _firstSide, _secondSide);
            }
        }
        /// <summary>
        /// Формула проверки прямоугольного треугольника.
        /// </summary>
        /// <param name="hypotenuse">Гипотенуза.</param>
        /// <param name="cathetusA">Катет 1.</param>
        /// <param name="cathetusB">Катет 2.</param>
        /// <returns></returns>
        private bool TriangleRightAngledFormula(double hypotenuse, double cathetusA, double cathetusB)
        {
            var sum = Math.Pow(cathetusA, 2) + Math.Pow(cathetusB, 2);
            var difference = Math.Pow(hypotenuse, 2) - sum;

            return Math.Abs(difference) <= double.Epsilon;
        }
    }
}
