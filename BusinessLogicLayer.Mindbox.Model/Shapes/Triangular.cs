namespace BusinessLogicLayer.Mindbox.Model.Shapes;

/// <summary>
/// Triangular model class.
/// </summary>
public sealed class Triangular : Shape
{
    /// <summary>
    /// Calculate square method.
    /// </summary>
    /// <returns>Circle square value.</returns>
    protected override double calculateSquare()
    {
        var perimeter = (this.FirstSide + this.SecondSide + this.ThirdSide) / 2;

        var result = Math.Sqrt(
            perimeter * (perimeter - this.FirstSide) * (perimeter - this.SecondSide) * (perimeter - this.ThirdSide)
        );

        return result;
    }

    /// <summary>
    /// Triangular first side property.
    /// </summary>
    public double FirstSide { get; }

    /// <summary>
    /// Triangular second side property.
    /// </summary>
    public double SecondSide { get; }

    /// <summary>
    /// Triangular third side property.
    /// </summary>
    public double ThirdSide { get; }

    /// <summary>
    /// Triangular is right angled computed property.
    /// </summary>
    // ReSharper disable once CompareOfFloatsByEqualityOperator
    public bool IsRightTriangle => Math.Pow(this.ThirdSide, 2) == Math.Pow(this.FirstSide, 2) + Math.Pow(this.SecondSide, 2);

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    public Triangular(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        if (firstSide <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(FirstSide));
        }

        if (secondSide <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(SecondSide));
        }

        if (thirdSide <= 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(ThirdSide));
        }

        if (firstSide + secondSide <= thirdSide ||
            firstSide + thirdSide <= secondSide ||
            secondSide + thirdSide <= firstSide
        ) {
            throw new ArgumentException("There is impossible triangle with the given sides.");
        }

        this.FirstSide = firstSide;
        this.SecondSide = secondSide;
        this.ThirdSide = thirdSide;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
    {
        // ReSharper disable once UseStringInterpolation
        return string.Format(
            "First side: {0}, second side: {1}, third side: {2}, square: {3}",
            this.FirstSide,
            this.SecondSide,
            this.ThirdSide,
            this.Square
        );
    }
}