namespace FigureAreaCalculationLibrary.Tests
{
    [TestClass]
    public class CircleAreaCalculationTest
    {
        /// <summary>
        /// Проверяет создание круга с отрицательным или нулевым радиусом.
        /// </summary>
        [DataTestMethod]
        [DataRow(-5)]
        [DataRow(0)]
        public void CreateCircleWithNegativeRadiusTest(double radius)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Circle.CreateCircle(radius));
        }
        /// <summary>
        /// Проверяет рассчёт площади круга по радиусу.
        /// </summary>
        [TestMethod]
        public void CalculateCircleAreaTest()
        {
            // Arrange
            var circle = Circle.CreateCircle(5);
            // Act
            var area = 78.54;
            // Assert
            Assert.AreEqual(area, circle.GetArea(2));
        }
        /// <summary>
        /// Проверяет округление площади. Количество знаков после запятой не входит в диапазон допустимых значений.
        /// </summary>
        [TestMethod]
        public void AreaRoundingTest()
        {
            var circle = Circle.CreateCircle(5);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => circle.GetArea(17));
        }
    }
}
