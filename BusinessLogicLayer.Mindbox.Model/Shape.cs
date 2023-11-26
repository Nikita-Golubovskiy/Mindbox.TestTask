using BusinessLogicLayer.Mindbox.Model.Interfaces;

namespace BusinessLogicLayer.Mindbox.Model;

/// <summary>
/// Shape based model class.
/// </summary>
public abstract class Shape : IShape
{
    /// <summary>
    /// Calculate square method.
    /// </summary>
    /// <returns>Square value.</returns>
    protected abstract double calculateSquare();

    /// <summary>
    /// Square computed property.
    /// </summary>
    public double Square => this.calculateSquare();
}
