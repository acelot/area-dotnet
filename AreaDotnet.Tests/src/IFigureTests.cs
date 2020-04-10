using AreaDotnet.Figures;
using NUnit.Framework;

namespace AreaDotnet.Tests
{
    public class IFigureTests
    {
        static object[] Figures =
        {
            new object[] { new Circle(2), 12.566370614359172d},
            new object[] { new Triangle(1, 1, 2), 0},
            new object[] { new Circle(4), 50.26548245743669d},
            new object[] { new Triangle(3, 3, 2), 2.8284271247461903d},
            new object[] { new Circle(1000), 3141592.653589793d},
            new object[] { new Triangle(3, 4, 5), 6},
        };

        [Test]
        [TestCaseSource("Figures")]
        public void Test(IFigure figure, double area)
        {
            Assert.AreEqual(figure.Area, area);
        }
    }
}
