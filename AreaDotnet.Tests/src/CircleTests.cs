using System;
using AreaDotnet.Figures;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AreaDotnet.Tests
{
    public class CircleTests
    {
        [Test]
        public void TestConstructor1()
        {
            ActualValueDelegate<object> d = () => new Circle(-1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestConstructor2()
        {
            ActualValueDelegate<object> d = () => new Circle(double.NaN);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestRadiusSetter1()
        {
            var c = new Circle(0);
            ActualValueDelegate<object> d = () => c.SetRadius(-1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }


        [Test]
        public void TestRadiusSetter2()
        {
            var c = new Circle(0);
            c.SetRadius(1);
            Assert.AreEqual(c.Radius, 1);
        }

        [Test]
        public void TestRadiusGetter()
        {
            var c = new Circle(Math.PI);
            Assert.AreEqual(c.Radius, Math.PI);
        }

        [Test]
        public void TestArea1()
        {
            var c = new Circle(0);
            Assert.AreEqual(c.Area, 0);
        }

        [Test]
        public void TestArea2()
        {
            var c = new Circle(1);
            Assert.AreEqual(c.Area, Math.PI);
        }

        [Test]
        public void TestArea3()
        {
            var c = new Circle(2);
            Assert.AreEqual(c.Area, Math.PI * 4);
        }

        [Test]
        public void TestArea4()
        {
            var c = new Circle(2.1d);
            Assert.AreEqual(c.Area, Math.PI * 2.1d * 2.1d);
        }

        [Test]
        public void TestArea5()
        {
            var c = new Circle(double.PositiveInfinity);
            Assert.IsTrue(double.IsInfinity(c.Area));
        }
    }
}
