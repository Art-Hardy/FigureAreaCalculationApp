namespace FigureAreaCalculationLibrary.Validation
{
    public static class SpecialValidator
    {
        public static void ValidateAreaRounding(int value)
        {
            if (value < 0 || value > 15)
            {
                throw new ArgumentOutOfRangeException("Значение должно быть в диапазоне от 0 до 15.");
            }
        }
    }
}
