namespace FigureAreaCalculationLibrary.Tests
{
    [TestClass]
    public class TriangleAreaCalculationTest
    {
        /// <summary>
        /// Проверяет создание треугольника, в котором одна из сторон (или все) отрицательная или нулевая.
        /// </summary>
        [DataTestMethod]
        [DataRow(-5, 1, 2)]
        [DataRow(1, 0, 2)]
        [DataRow(10, 5, -5)]
        [DataRow(-5, -5, -5)]
        public void CreateTriangleWithNegativeSidesTest(double first, double second, double third)
        {
            Assert.ThrowsException<Exception>(() => Triangle.CreateTriangle(first, second, third));
        }
        /// <summary>
        /// Провекрка создания несуществующего треугольника.
        /// </summary>
        [TestMethod]
        public void CreateNonexistentTriangleTest()
        {
            Assert.ThrowsException<Exception>(() => Triangle.CreateTriangle(12, 4, 2));
        }
        /// <summary>
        /// Проверяет рассчёт площади треугольника по трём сторонам.
        /// </summary>
        [TestMethod]
        public void CalculateTriangleAreaTest()
        {
            // Arrange
            var triangle = Triangle.CreateTriangle(3, 4, 5);
            // Act
            var area = 6;
            // Assert
            Assert.AreEqual(area, triangle.GetArea(2));
        }
        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным.
        /// </summary>
        [TestMethod]
        public void TriangleIsRightAngledTest()
        {
            var triangle = Triangle.CreateTriangle(3, 4, 5);

            Assert.IsTrue(triangle.IsRightAngled);
        }
        /// <summary>
        /// Проверяет, не является ли треугольник прямоугольным.
        /// </summary>
        [TestMethod]
        public void TriangleIsNotRightAngledTest()
        {
            var triangle = Triangle.CreateTriangle(3, 4, 6);

            Assert.IsFalse(triangle.IsRightAngled);
        }
    }
}
