namespace NumberInterpreter.Extensions;

public static class ConvertTripletExtensions
{
    public static List<string> ConvertTriplet(this int n, bool feminine = false)
    {
        var words = new List<string>();
        var h = n / 100;
        var rest = n % 100;

        if (h > 0) words.Add(Dictionaries.Hundreds[h]);

        if (rest >= 10 && rest < 20)
        {
            words.Add(Dictionaries.Teens[rest - 10]);
        }
        else
        {
            var t = rest / 10;
            var u = rest % 10;
            if (t > 0) words.Add(Dictionaries.Tens[t]);
            if (u > 0) words.Add((feminine ? Dictionaries.UnitsFeminine : Dictionaries.UnitsMasculine)[u]);
        }

        return words;
    }
}
