using Xunit;
using AreaCalc;

namespace AreaCalcUnitTests
{

    public class CircleUnitTest
    {
        [Fact]
        public void Circle_GetArea_ShouldReturnCorrectArea()
        {
            // Arrange
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedArea = Math.PI * Math.Pow(radius, 2);

            // Act
            double actualArea = circle.GetArea();

            // Assert
            Assert.Equal(expectedArea, actualArea, 5); // 5 - точность сравнения
        }

        [Fact]
        public void Circle_GetPerimeter_ShouldReturnCorrectPerimeter()
        {
            // Arrange
            double radius = 5;
            Circle circle = new Circle(radius);
            double expectedPerimeter = 2 * Math.PI * radius;

            // Act
            double actualPerimeter = circle.GetPerimeter();

            // Assert
            Assert.Equal(expectedPerimeter, actualPerimeter, 5);
        }

        [Fact]
        public void Circle_isCircle_ShouldReturnTrue_ForValidRadius()
        {
            // Arrange
            double radius = 5;
            Circle circle = new Circle(radius);

            // Act
            bool isCircle = circle.isCircle();

            // Assert
            Assert.True(isCircle);
        }

        [Fact]
        public void Circle_isCircle_ShouldReturnFalse_ForInvalidRadius()
        {
            // Arrange
            double radius = -5;
            Circle circle = new Circle(radius);

            // Act
            bool isCircle = circle.isCircle();

            // Assert
            Assert.False(isCircle);
        }

        [Fact]
        public void Circle_GetArea_ShouldReturnZero_ForInvalidCircle()
        {
            // Arrange
            double radius = -5;
            Circle circle = new Circle(radius);

            // Act
            double area = circle.GetArea();

            // Assert
            Assert.Equal(0, area);
        }

        [Fact]
        public void Circle_GetPerimeter_ShouldReturnZero_ForInvalidCircle()
        {
            // Arrange
            double radius = -5;
            Circle circle = new Circle(radius);

            // Act
            double perimeter = circle.GetPerimeter();

            // Assert
            Assert.Equal(0, perimeter);
        }
    }

    public class TriangleUnitTest
    {
        [Fact]
        public void Triangle_GetArea_ShouldReturnCorrectArea()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double s = (sideA + sideB + sideC) / 2;
            double expectedArea = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));

            // Act
            double actualArea = triangle.GetArea();

            // Assert
            Assert.Equal(expectedArea, actualArea, 5); // 5 - точность сравнения
        }

        [Fact]
        public void Triangle_GetPerimeter_ShouldReturnCorrectPerimeter()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double expectedPerimeter = sideA + sideB + sideC;

            // Act
            double actualPerimeter = triangle.GetPerimeter();

            // Assert
            Assert.Equal(expectedPerimeter, actualPerimeter);
        }

        [Fact]
        public void Triangle_isTriangle_ShouldReturnTrue_ForValidTriangle()
        {
            // Arrange
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isTriangle = triangle.isTriangle();

            // Assert
            Assert.True(isTriangle);
        }

        [Fact]
        public void Triangle_isTriangle_ShouldReturnFalse_ForInvalidTriangle()
        {
            // Arrange
            double sideA = 1;
            double sideB = 1;
            double sideC = 10;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            bool isTriangle = triangle.isTriangle();

            // Assert
            Assert.False(isTriangle);
        }

        [Fact]
        public void Triangle_GetArea_ShouldReturnZero_ForInvalidTriangle()
        {
            // Arrange
            double sideA = 1;
            double sideB = 1;
            double sideC = 10;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double area = triangle.GetArea();

            // Assert
            Assert.Equal(0, area);
        }

        [Fact]
        public void Triangle_GetPerimeter_ShouldReturnZero_ForInvalidTriangle()
        {
            // Arrange
            double sideA = 1;
            double sideB = 1;
            double sideC = 10;
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            // Act
            double perimeter = triangle.GetPerimeter();

            // Assert
            Assert.Equal(0, perimeter);
        }

        [Fact]
        public void TriangleTypeCheck_ShouldIdentifyEquilateralTriangle()
        {
            // Arrange
            var triangle = new Triangle(5, 5, 5);
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Треугольник равносторонний.", result);
            }
            finally
            {
                // Восстанавливаем стандартный вывод в консоль
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }

        [Fact]
        public void TriangleTypeCheck_ShouldIdentifyIsoscelesRightAngledTriangle()
        {
            // Arrange
            var triangle = new Triangle(1, 1, Math.Sqrt(2));
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Треугольник равнобедренный и прямоугольный.", result);
            }
            finally
            {
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }

        [Fact]
        public void TriangleTypeCheck_ShouldIdentifyIsoscelesTriangle()
        {
            // Arrange
            var triangle = new Triangle(5, 5, 8);
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Треугольник равнобедренный.", result);
            }
            finally
            {
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }

        [Fact]
        public void TriangleTypeCheck_ShouldIdentifyRightAngledTriangle()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 5);
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Треугольник прямоугольный.", result);
            }
            finally
            {
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }

        [Fact]
        public void TriangleTypeCheck_ShouldIdentifyGeneralTriangle()
        {
            // Arrange
            var triangle = new Triangle(3, 4, 6);
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Треугольник общего типа.", result);
            }
            finally
            {
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }

        [Fact]
        public void TriangleTypeCheck_ShouldHandleInvalidTriangle()
        {
            // Arrange
            var triangle = new Triangle(1, 1, 10);
            var sw = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(sw);

                // Act
                triangle.TriangleTypeCheck();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal("Фигура не является треугольником или такой треугольник не может существовать.", result);
            }
            finally
            {
                Console.SetOut(originalOut);
                sw.Dispose();
            }
        }
    }

}