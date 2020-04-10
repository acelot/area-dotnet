using System;
using AreaDotnet.Figures;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AreaDotnet.Tests
{
    public class TriangleTests
    {
        [Test]
        public void TestConstructor1()
        {
            ActualValueDelegate<object> d = () => new Triangle(-1, 1, 1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestConstructor2()
        {
            ActualValueDelegate<object> d = () => new Triangle(1, -1, 1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestConstructor3()
        {
            ActualValueDelegate<object> d = () => new Triangle(1, 1, -1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestConstructor4()
        {
            ActualValueDelegate<object> d = () => new Triangle(double.NaN, 1, 1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestConstructor5()
        {
            ActualValueDelegate<object> d = () => new Triangle(double.PositiveInfinity, 1, 1);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestNonExistentTriangle1()
        {
            ActualValueDelegate<object> d = () => new Triangle(3, 1, 1);
            Assert.That(d, Throws.TypeOf<NonExistentTriangleException>());
        }

        [Test]
        public void TestNonExistentTriangle2()
        {
            ActualValueDelegate<object> d = () => new Triangle(1, 3, 1);
            Assert.That(d, Throws.TypeOf<NonExistentTriangleException>());
        }

        [Test]
        public void TestNonExistentTriangle3()
        {
            ActualValueDelegate<object> d = () => new Triangle(1, 1, 3);
            Assert.That(d, Throws.TypeOf<NonExistentTriangleException>());
        }

        [Test]
        public void TestSidesGetter()
        {
            var t = new Triangle(2, 2, 3);
            Assert.AreEqual(t.SideA, 2);
            Assert.AreEqual(t.SideB, 2);
            Assert.AreEqual(t.SideC, 3);
        }

        [Test]
        public void TestSidesSetter1()
        {
            var t = new Triangle(2, 2, 3);
            ActualValueDelegate<object> d = () => t.SetSides(-1, 2, 3);
            Assert.That(d, Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestSidesSetter2()
        {
            var t = new Triangle(2, 2, 3);
            ActualValueDelegate<object> d = () => t.SetSides(1, 1, 3);
            Assert.That(d, Throws.TypeOf<NonExistentTriangleException>());
        }

        [Test]
        public void TestSidesSetter3()
        {
            var t = new Triangle(2, 2, 3);
            t.SetSides(4, 4, 3);
            Assert.AreEqual(t.SideA, 4);
            Assert.AreEqual(t.SideB, 4);
            Assert.AreEqual(t.SideC, 3);
        }

        [Test]
        public void TestIsRight1()
        {
            var t = new Triangle(3, 4, 5);
            Assert.IsTrue(t.IsRight);
        }

        [Test]
        public void TestIsRight2()
        {
            var t = new Triangle(4, 3, 5);
            Assert.IsTrue(t.IsRight);
        }

        [Test]
        public void TestIsRight3()
        {
            var t = new Triangle(5, 3, 4);
            Assert.IsTrue(t.IsRight);
        }

        [Test]
        public void TestIsRight4()
        {
            var t = new Triangle(3, 4, 4);
            Assert.IsFalse(t.IsRight);
        }

        [Test]
        public void TestIsRight5()
        {
            var t = new Triangle(1, 1, Math.Sqrt(2));
            Assert.IsTrue(t.IsRight);
        }

        [Test]
        public void TestIsRight6()
        {
            var t = new Triangle(Math.Sqrt(2), Math.Sqrt(2), 2);
            Assert.IsTrue(t.IsRight);
        }

        [Test]
        public void TestArea1()
        {
            var t = new Triangle(1, 1, 2);
            Assert.AreEqual(t.Area, 0);
        }

        [Test]
        public void TestArea2()
        {
            var t = new Triangle(3, 3, 2);
            Assert.AreEqual(t.Area, 2.8284271247461903d);
        }

        [Test]
        public void TestArea3()
        {
            var t = new Triangle(0, 0, 0);
            Assert.AreEqual(t.Area, 0);
        }
    }
}
