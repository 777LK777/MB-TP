namespace CliClient.Helpers;

internal class StringToCordinateConverter
{
    public Dictionary<TEnum, double> Convert<TEnum>(string input) where TEnum : struct, Enum
    {
        var result = new Dictionary<TEnum, double>();
        var axes = Enum.GetValues<TEnum>();
        var coord = input.Trim('[', ']').Split(';');

        for (int i = 0; i < axes.Length; i++)
        {
            var axis = axes[i];
            double val;
            if (!result.ContainsKey(axis) && double.TryParse(coord[i], out val))
                result.Add(axis, val);
        }

        return result;
    }

    public List<Dictionary<TEnum, double>> ConvertMany<TEnum>(string input) where TEnum : struct, Enum
    {
        var result = new List<Dictionary<TEnum, double>>();
        var coords = input.Split(' ');

        for (int i = 0; i < coords.Length; i++)
        {
            result.Add(Convert<TEnum>(coords[i]));
        }

        return result;
    }
}
