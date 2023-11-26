using Xunit;
using BusinessLogicLayer.Mindbox.Model.Shapes;

namespace Test.Mindbox.Unit.Shapes;

/// <summary>
/// <see cref="Triangular">Triangular</see> model tests.
/// </summary>
public class TriangularTests
{
    /// <summary>
    /// Triangular instance constructed with correct parameters testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    [Theory]
    [InlineData(10.0, 10.0, 10.0)]
    [InlineData(4.0, 5.0, 5.0)]
    [InlineData(10.0, 5.0, 6.0)]
    public void Triangular_WhenConstructWithCorrectParameters_ReturnsProperInstance(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        var triangular = new Triangular(
            firstSide,
            secondSide,
            thirdSide
        );

        Assert.Equal(triangular.FirstSide, firstSide);
        Assert.Equal(triangular.SecondSide, secondSide);
        Assert.Equal(triangular.ThirdSide, thirdSide);
    }

    /// <summary>
    /// Triangular instance constructed with not correct parameters testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    [Theory]
    [InlineData(10.0, 10.0, -10.0)]
    [InlineData(-1.0, 16.0, 4.0)]
    [InlineData(0.0, 0.0, 0.0)]
    public void Triangular_WhenConstructWithNotCorrectParameters_ThrowsArgumentOutOfRangeException(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        var exception = Record.Exception(
            () => new Triangular(
                firstSide,
                secondSide,
                thirdSide
            )
        );

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    /// <summary>
    /// Triangular instance constructed with not correct parameters testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    [Theory]
    [InlineData(10.0, 9.0, 20.0)]
    [InlineData(1.0, 16.0, 12.0)]
    [InlineData(4.0, 1.0, 8.0)]
    public void Triangular_WhenConstructWithNotCorrectParameters_ThrowsArgumentException(
        double firstSide,
        double secondSide,
        double thirdSide
    ) {
        var exception = Record.Exception(
            () => new Triangular(
                firstSide,
                secondSide,
                thirdSide
            )
        );

        Assert.IsType<ArgumentException>(exception);
    }

    /// <summary>
    /// Triangular calculate square testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    /// <param name="square">Triangular square value.</param>
    [Theory]
    [InlineData(10.0, 10.0, 10.0, 43.30)]
    [InlineData(4.0, 5.0, 5.0, 9.16)]
    [InlineData(10.0, 5.0, 6.0, 11.39)]
    public void Triangular_WhenConstructWithCorrectParameters_ReturnsProperSquare(
        double firstSide,
        double secondSide,
        double thirdSide,
        double square
    ) {
        var triangular = new Triangular(
            firstSide,
            secondSide,
            thirdSide
        );

        Assert.Equal(triangular.FirstSide, firstSide);
        Assert.Equal(triangular.SecondSide, secondSide);
        Assert.Equal(triangular.ThirdSide, thirdSide);
        Assert.Equal(triangular.Square, square, 1E-2);
    }

    /// <summary>
    /// Triangular is right angled testing method.
    /// </summary>
    /// <param name="firstSide">Triangular first side value.</param>
    /// <param name="secondSide">Triangular second side value.</param>
    /// <param name="thirdSide">Triangular third side value.</param>
    /// <param name="isRightAngle">Triangular square value.</param>
    [Theory]
    [InlineData(3.0, 4.0, 5.0, true)]
    [InlineData(5.0, 12.0, 13.0, true)]
    [InlineData(10.0, 5.0, 6.0, false)]
    public void Triangular_WhenConstructWithCorrectParameters_ReturnsTriangleIsRightAngled(
        double firstSide,
        double secondSide,
        double thirdSide,
        bool isRightAngle
    ) {
        var triangular = new Triangular(
            firstSide,
            secondSide,
            thirdSide
        );

        Assert.Equal(triangular.FirstSide, firstSide);
        Assert.Equal(triangular.SecondSide, secondSide);
        Assert.Equal(triangular.ThirdSide, thirdSide);
        Assert.Equal(triangular.IsRightTriangle, isRightAngle);
    }
}