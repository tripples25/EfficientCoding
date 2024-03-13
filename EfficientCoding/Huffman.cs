namespace EfficientCoding;

public class Huffman
{
    private readonly List<Symbol> symbols;

    public Huffman(List<Symbol> symbols)
    {
        this.symbols = symbols;
    }

    public void Encode()
    {
        EncodeRecursive(symbols.Select(x => new HuffmanNode(x)));
    }

    private void EncodeRecursive(IEnumerable<HuffmanNode> symbols)
    {
        var enumerable = symbols.OrderByDescending(x => x.Probability).ToList();
        if (enumerable.Count == 1)
        {
            var node = enumerable.First();
            if (node.Symbol != null)
            {
                node.Encode("0");
            }
            else
            {
                node.LeftNode!.Encode("1");
                node.RightNode!.Encode("0");
            }

            return;
        }

        var block = new HuffmanNode(enumerable[^2], enumerable[^1]);
        
        EncodeRecursive(enumerable.Take(enumerable.Count - 2).Concat(new []{block}));
    }

    public void PrintCodes()
    {
        foreach (var symbol in symbols)
        {
            Console.WriteLine($"Character: {symbol.Character}, Probability: {symbol.Probability}, Code: {symbol.Code}");
        }
    }
}
