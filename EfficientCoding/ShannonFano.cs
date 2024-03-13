namespace EfficientCoding;

public class ShannonFano
{
    private readonly List<Symbol> symbols;

    public ShannonFano(List<Symbol> symbols)
    {
        this.symbols = symbols;
    }

    public void Encode()
    {
        symbols.Sort((a, b) => b.Probability.CompareTo(a.Probability));
        EncodeRecursive(symbols, symbols.Sum(x => x.Probability), string.Empty);
    }

    private void EncodeRecursive(IEnumerable<Symbol> symbols, double localSum, string code)
    {
        var enumerable = symbols.ToArray();
        if (enumerable.Length == 1)
        {
            enumerable.First().Code = code;
            return;
        }

        var sum = 0d;
        var takeCount = 0;
        foreach (var symbol in this.symbols)
        {
            sum += symbol.Probability;
            takeCount += 1;
            if (sum >= localSum / 2 || enumerable.Length - takeCount == 1)
                break;
        }
        
        EncodeRecursive(enumerable.Take(takeCount), sum, code + "0");
        EncodeRecursive(enumerable.Skip(takeCount), localSum - sum, code + "1");
    }

    public void PrintCodes()
    {
        foreach (var symbol in symbols)
        {
            Console.WriteLine($"Character: {symbol.Character}, Probability: {symbol.Probability}, Code: {symbol.Code}");
        }
    }
}
