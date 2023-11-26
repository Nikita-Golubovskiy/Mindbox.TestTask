// See https://aka.ms/new-console-template for more information
using BusinessLogicLayer.Mindbox.Model.Interfaces;
using BusinessLogicLayer.Mindbox.Model.Shapes;
using System.Collections.Concurrent;
using System.Diagnostics;

Console.WriteLine("Enter:");
Console.WriteLine("1 - to calculate the area of the shape");
Console.WriteLine("2 - just for lulz :)");

var modeToString = Console.ReadLine();

if (!int.TryParse(modeToString, out var mode))
{
    throw new ArgumentException();
}

if (mode is not (1 or 2))
{
    throw new ArgumentException();
}

if (mode == 1)
{
    IShape shape;

    Console.WriteLine("Enter type shape:");
    Console.WriteLine("1 - circle");
    Console.WriteLine("2 - triangular");

    var shapeTypeToString = Console.ReadLine();

    if (!int.TryParse(shapeTypeToString, out var shapeType))
    {
        throw new ArgumentException();
    }

    if (shapeType is not (1 or 2))
    {
        throw new ArgumentException();
    }

    switch (shapeType)
    {
        case 1:
            Console.WriteLine("Enter radius");
            var radiusToString = Console.ReadLine();

            if (!int.TryParse(radiusToString, out var radius))
            {
                throw new ArgumentException();
            }

            shape = new Circle(radius);
            break;

        case 2:
            Console.WriteLine("Enter first side");
            var firstSideToString = Console.ReadLine();

            Console.WriteLine("Enter second side");
            var secondSideToString = Console.ReadLine();

            Console.WriteLine("Enter third side");
            var thirdSideToString = Console.ReadLine();

            if (!int.TryParse(firstSideToString, out var firstSide))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(secondSideToString, out var secondSide))
            {
                throw new ArgumentException();
            }

            if (!int.TryParse(thirdSideToString, out var thirdSide))
            {
                throw new ArgumentException();
            }

            shape = new Triangular(
                firstSide,
                secondSide,
                thirdSide
            );
            break;

        default: throw new ArgumentException();
    }

    Console.WriteLine($"Shape square is {shape.Square}");

    if (shape is Triangular triangular)
    {
        var triangleMessage = triangular.IsRightTriangle ?
            "The triangle is right angled." :
            "The triangle is not right angled.";

        Console.WriteLine(triangleMessage);
    }
}
else
{
    var shapes = new ConcurrentQueue<IShape>();

    var createShape = new Action<int>(index =>
    {
        var random = new Random();

        if (index % 2 == 0)
        {
            var circle = new Circle(random.Next(1, 100));

            shapes.Enqueue(circle);
        }
        else
        {
            Triangular triangular = null;

            while (triangular is null)
            {
                var firstSide = random.Next(1, 100);
                var secondSide = random.Next(1, 100);
                var thirdSide = random.Next(1, 100);

                if (firstSide + secondSide > thirdSide &&
                    firstSide + thirdSide > secondSide &&
                    secondSide + thirdSide > firstSide
                )
                {
                    triangular = new Triangular(
                        firstSide,
                        secondSide,
                        thirdSide
                    );
                }
            }

            shapes.Enqueue(triangular);
        }
    });

    Parallel.For(0, 1_000_000, createShape);

    var index = 0;

    foreach (var shape in shapes)
    {
        index++;

        Console.WriteLine($"{index} - shape has square = {shape.Square}.");
    }
}