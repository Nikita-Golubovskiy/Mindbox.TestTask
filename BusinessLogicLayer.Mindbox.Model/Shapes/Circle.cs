namespace BusinessLogicLayer.Mindbox.Model.Shapes;

/// <summary>
/// Circle model class.
/// </summary>
public sealed class Circle : Shape
{
    /// <summary>
    /// Calculate square method.
    /// </summary>
    /// <returns>Circle square value.</returns>
    protected override double calculateSquare()
    {
        var result = Math.PI * Math.Pow(this.Radius, 2);

        return result;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="radius">Circle radius value.</param>
    public Circle(double radius)
    {
        if (radius <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(this.Radius));
        }

        this.Radius = radius;
    }

    /// <summary>
    /// Circle radius property.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "Radius: {0}, square: {1}",
            this.Radius,
            this.Square
        );
    }
}