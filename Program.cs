var genrator = new PasswordGenerater(new ChossenRandomNumbers());


for (int i = 0; i < 10; i++)
{
    Console.WriteLine(genrator.Generate(5, 10, false));
}

Console.ReadKey();

public class PasswordGenerater
{
    private  IRandomChossenNumbers _randomChossenNumbers { get; set; }

    public PasswordGenerater(IRandomChossenNumbers randomNumbers)
    {
        _randomChossenNumbers = randomNumbers;
    }

    public   string Generate(int minumValue, int MaxmumValue, bool useSpecial)
    {
        Validates(minumValue, MaxmumValue);
        var PickRandomNumber = _randomChossenNumbers.Next(minumValue, MaxmumValue + 1);
        string PasswordChars = CharsType(useSpecial);
        var repeatedValues = Enumerable.Repeat(PasswordChars, PickRandomNumber);
        char[] CollictionOFChars = selectedPasswordChars(repeatedValues, PasswordChars);
        return new string(CollictionOFChars);


    }

    public char[] selectedPasswordChars(IEnumerable<string> repeatedValues, string PasswordChars) =>
        repeatedValues.Select(chars => chars[_randomChossenNumbers.Next(0, PasswordChars.Length)]).ToArray();


    private static string CharsType(bool useSpecial) => useSpecial ?
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+="
        : "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


    private static void Validates(int MinValue, int MaxValue)
    {

        if (MinValue < 1)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be greater than 0");
        }
        if (MaxValue < MinValue)
        {
            throw new ArgumentOutOfRangeException(
                $"leftRange must be smaller than rightRange");
        }

    }
}

public interface IRandomChossenNumbers
{
    public int Next(int minValue = 0, int maxValue = 0);
}

public class ChossenRandomNumbers : IRandomChossenNumbers
{
    private static readonly Random rand = new Random();
    public int Next(int minValue = 0, int maxValue = 0) => rand.Next(minValue, maxValue);


}


