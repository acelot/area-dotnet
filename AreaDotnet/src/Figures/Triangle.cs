using System;

namespace AreaDotnet.Figures
{
    public class Triangle : IFigure
    {
        protected const int RIGHT_PRECISION = 12;

        public double SideA { get; protected set; }
        public double SideB { get; protected set; }
        public double SideC { get; protected set; }

        /// <inheritdoc/>
        /// <see>https://en.wikipedia.org/wiki/Heron%27s_formula</see>
        public double Area
        {
            get
            {
                var p = (SideA + SideB + SideC) / 2;
                return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            }
        }

        /// <value>True if triangle is right.</value>
        /// <see>https://en.wikipedia.org/wiki/Right_triangle</see>
        /// <see>https://en.wikipedia.org/wiki/Pythagorean_theorem</see>
        public bool IsRight
        {
            get
            {
                double hypotenuse = SideC;
                double leg1 = SideA;
                double leg2 = SideB;
                if (SideA > SideB && SideA > SideC)
                {
                    hypotenuse = SideA;
                    leg1 = SideB;
                    leg2 = SideC;
                }
                else if (SideB > SideA && SideB > SideC)
                {
                    hypotenuse = SideB;
                    leg1 = SideA;
                    leg2 = SideC;
                }
                return Math.Round(leg1 * leg1 + leg2 * leg2, RIGHT_PRECISION)
                    == Math.Round(hypotenuse * hypotenuse, RIGHT_PRECISION);
            }
        }

        /// <summary><c>Triangle</c> class constructor.</summary>
        /// <param name="sideA">A double precision number.</param>
        /// <param name="sideB">A double precision number.</param>
        /// <param name="sideC">A double precision number.</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            SetSides(sideA, sideB, sideC);
        }

        /// <summary>Sets the sides of triangle.</summary>
        /// <param name="sideA">A double precision number.</param>
        /// <param name="sideB">A double precision number.</param>
        /// <param name="sideC">A double precision number.</param>
        /// <exception cref="System.ArgumentException">If one of the sides is invalid.</exception>
        /// <exception cref="AreaDotnet.Figures.NonExistentTriangleException">
        /// If the triangle cannot exists with these sides.</exception>
        public Triangle SetSides(double sideA, double sideB, double sideC)
        {
            if (sideA < 0 || double.IsNaN(sideA) || double.IsInfinity(sideA))
            {
                throw new ArgumentException("Side A must be a positive finite double");
            }
            if (sideB < 0 || double.IsNaN(sideB) || double.IsInfinity(sideB))
            {
                throw new ArgumentException("Side B must be a positive finite double");
            }
            if (sideC < 0 || double.IsNaN(sideC) || double.IsInfinity(sideC))
            {
                throw new ArgumentException("Side C must be a positive finite double");
            }
            if (!((sideA <= sideB + sideC) && (sideB <= sideA + sideC) && (sideC <= sideA + sideB)))
            {
                throw new NonExistentTriangleException("A triangle with such sides cannot exist");
            }

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            return this;
        }
    }

    public class NonExistentTriangleException : ArgumentException
    {
        public NonExistentTriangleException() : base() { }
        public NonExistentTriangleException(string message) : base(message) { }
        public NonExistentTriangleException(string message, Exception innerException)
            : base(message, innerException) { }
        public NonExistentTriangleException(string message, string paramName)
            : base(message, paramName) { }
        public NonExistentTriangleException(string message, string paramName, Exception innerException)
            : base(message, paramName, innerException) { }
    }
}
