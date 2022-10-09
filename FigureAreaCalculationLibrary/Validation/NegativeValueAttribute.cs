using System.ComponentModel.DataAnnotations;

namespace FigureAreaCalculationLibrary.Validation
{
    public class NegativeValueAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is double dValue && dValue <= 0)
            {
                ErrorMessage = "Значение не может быть отрицательным или равным нулю.";
                return false;
            }
            return true;
        }
    }
}
