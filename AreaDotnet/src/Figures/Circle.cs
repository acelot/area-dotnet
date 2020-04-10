using System;

namespace AreaDotnet.Figures
{
    public class Circle : IFigure
    {
        /// <value>Circle radius.</value>
        public double Radius { get; protected set; }

        /// <inheritdoc/>
        /// <see>https://en.wikipedia.org/wiki/Area_of_a_circle</see>
        public double Area => Math.PI * Radius * Radius;

        /// <summary><c>Circle</c> class constructor.</summary>
        /// <param name="radius">A double precision number.</param>
        public Circle(double radius)
        {
            SetRadius(radius);
        }

        /// <summary>Sets the raduis of the circle.</summary>
        /// <param name="radius">A double precision number.</param>
        /// <exception cref="System.ArgumentException">If the radius is invalid.</exception>
        public Circle SetRadius(double radius)
        {
            if (radius < 0 || double.IsNaN(radius))
            {
                throw new ArgumentException("Radius must be a positive double");
            }

            Radius = radius;
            return this;
        }
    }
}
