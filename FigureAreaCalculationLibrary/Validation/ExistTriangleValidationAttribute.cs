using System.ComponentModel.DataAnnotations;

namespace FigureAreaCalculationLibrary.Validation
{
    public class ExistTriangleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is Triangle triangle)
            {
                if (triangle.FirstSide > triangle.SecondSide + triangle.ThirdSide ||
                    triangle.SecondSide > triangle.FirstSide + triangle.ThirdSide ||
                    triangle.ThirdSide > triangle.FirstSide + triangle.SecondSide)
                {
                    ErrorMessage = "Треугольник с указанными сторонами не может существовать, так как одна сторона треугольника больше суммы двух других сторон.";
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
