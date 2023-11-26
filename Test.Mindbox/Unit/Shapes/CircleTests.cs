using Xunit;
using BusinessLogicLayer.Mindbox.Model.Shapes;

namespace Test.Mindbox.Unit.Shapes;

/// <summary>
/// <see cref="Circle">Circle</see> model tests.
/// </summary>
public class CircleTests
{
    /// <summary>
    /// Circle instance constructed with correct parameters testing method.
    /// </summary>
    /// <param name="radius">Circle radius value.</param>
    [Theory]
    [InlineData(100.0)]
    [InlineData(4.0)]
    [InlineData(25.0)]
    public void Circle_WhenConstructWithCorrectParameters_ReturnsProperInstance(double radius)
    {
        var circle = new Circle(radius);

        Assert.Equal(circle.Radius, radius);
    }

    /// <summary>
    /// Circle instance constructed with not correct parameters testing method.
    /// </summary>
    /// <param name="radius">Circle radius value.</param>
    [Theory]
    [InlineData(-100.0)]
    [InlineData(-4.0)]
    [InlineData(0.0)]
    public void Circle_WhenConstructWithNotCorrectParameters_ThrowsArgumentOutOfRangeException(double radius)
    {
        var exception = Record.Exception(
            () => new Circle(radius)
        );

        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    /// <summary>
    /// Circle calculate square testing method.
    /// </summary>
    /// <param name="radius">Circle radius value.</param>
    /// <param name="square">Circle square value.</param>
    [Theory]
    [InlineData(80.0, 20106.19)]
    [InlineData(41.0, 5281.01)]
    [InlineData(91.0, 26015.52)]
    public void Circle_WhenConstructWithCorrectParameters_ReturnsProperSquare(double radius, double square)
    {
        var circle = new Circle(radius);

        Assert.Equal(circle.Square, square, 1E-2);
    }
}