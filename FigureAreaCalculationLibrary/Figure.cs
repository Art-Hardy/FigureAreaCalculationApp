using FigureAreaCalculationLibrary.Validation;

namespace FigureAreaCalculationLibrary
{
    public abstract class Figure : IFigure
    {
        public double GetArea(int round)
        {
            SpecialValidator.ValidateAreaRounding(round);
            return CalculateArea(round);
        }

        protected abstract double CalculateArea(int round);
    }
}
