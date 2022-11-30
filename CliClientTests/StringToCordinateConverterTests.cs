using CliClient.Helpers;

namespace CliClientTests;

enum Axis
{
    X, Y, Z
}

public class StringToCordinateConverterTests
{
    [Fact]
    public void ConvertCorrectStringToCoordinate()
    {
        var converter = new StringToCordinateConverter(',');
        var correctString = "[11,22,33]";

        var result = converter.Convert<Axis>(correctString);

        var expectation = new Dictionary<Axis, double> { { Axis.X, 11 }, { Axis.Y, 22 }, { Axis.Z, 33 } };
        Assert.Equal(expectation, result);
    }

    [Fact]
    public void ConvertCorrectStringToManyCoordinates()
    {
        var converter = new StringToCordinateConverter(',');
        var correctString = "[11,22,33] [12,23,34] [13,24,35]";

        var result = converter.ConvertMany<Axis>(correctString);

        var expectation = new List<Dictionary<Axis, double>>
        {
            new Dictionary<Axis, double> { { Axis.X, 11 }, { Axis.Y, 22 }, { Axis.Z, 33 } },
            new Dictionary<Axis, double> { { Axis.X, 12 }, { Axis.Y, 23 }, { Axis.Z, 34 } },
            new Dictionary<Axis, double> { { Axis.X, 13 }, { Axis.Y, 24 }, { Axis.Z, 35 } },
        };
        Assert.Equal(expectation, result);
    }

    [Fact]
    public void ConvertIncorrectStringToCoordinate()
    {
        var converter = new StringToCordinateConverter(',');
        var correctString = "[11; 22; 33]";

        Assert.Throws<IndexOutOfRangeException>(() => converter.ConvertMany<Axis>(correctString));
    }

    [Fact]
    public void ConvertIncorrectStringToManyCoordinates()
    {
        var converter = new StringToCordinateConverter(',');
        var correctString = "[11, 22, 33] [12, 23, 34] [13, 24, 35]";

        Assert.Throws<IndexOutOfRangeException>(() => converter.ConvertMany<Axis>(correctString));
    }
}