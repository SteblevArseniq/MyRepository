using NewtonLibrary;

namespace NewtonTests
{
    [TestClass]
    public class NewtonTest
    {
        /// <summary>
        /// Метод проверки эквивалентности полученного значения.
        /// </summary>
        [TestMethod]
        public void SolvingSystem_Equal()
        {
            // Тестируем значение конечной точки (корня системы)
            Assert.AreEqual(new Point(0, 0), GetPoint());
        }

        /// <summary>
        /// Метод проверки логического значения в зависимости от результата.
        /// </summary>
        [TestMethod]
        public void SolvingSystem_IsTrue()
        {
            // Тестируем значение конечной точки (корня системы)
            Point point = GetPoint();
            Assert.IsTrue(point.x > 0 && point.y > 0);
        }

        /// <summary>
        /// Метод выбросит исключение выхода за границы допустимых значений, если в методе GetPoint будет выброшено то же исключение.
        /// </summary>
        [TestMethod]
        public void SolvingSystem_ThrowsException()
        {
            // Тестируем значение конечной точки (корня системы)
            Assert.ThrowsException<ArgumentOutOfRangeException>(GetPoint);
        }

        /// <summary>
        /// Метод выбросит исключение выхода за границы допустимых значений, если в методе GetPoint будет выброшено то же исключение.
        /// </summary>
        [TestMethod]
        public void SolvingSystem_ThrowsException_TryCatch()
        {
            // Тестируем значение конечной точки (корня системы)
            Assert.ThrowsException<ArgumentOutOfRangeException>(GetPoint);
            try
            {
                GetPoint();
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message,
                    "Too Big Value");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        /// <summary>
        /// Метод получения корня уравнения для тестов.
        /// </summary>
        /// <returns>Объект корня уравнения (точка в системе координат)</returns>
        /// <exception cref="ArgumentOutOfRangeException">Исключение выхода за границы допустимых значений</exception>
        private Point GetPoint()
        {
            Equation systemEquation1 = new Equation(-2.6e-15, -0.76, -1.6e-15, 1.6, 16, 2.76e+19, 3.26e-8, -1.6e-23, 6, 17.6);
            Equation systemEquation2 = new Equation(-9.6e-16, -0.6, -4.6e-17, 0.96, 1.6, 2.6e+20, 4.6e-9, -3.6e-23, 1, 1.05);
            var point = new Point(NewtonMethod.SolvingSystem(systemEquation1, systemEquation2));
            if (point.x > 10)
            {
                throw new ArgumentOutOfRangeException($"Too Big Value");
            }
            if (point.x < 10)
            {
                throw new ArgumentOutOfRangeException($"Too Small Value");
            }
            return point;
        }
    }
}