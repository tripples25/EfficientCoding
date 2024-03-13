using EfficientCoding;

var symbols = new List<Symbol>
{
    new Symbol { Character = '1', Probability = 0.155 },
    new Symbol { Character = '2', Probability = 0.147 },
    new Symbol { Character = '3', Probability = 0.138 },
    new Symbol { Character = '4', Probability = 0.137 },
    new Symbol { Character = '5', Probability = 0.116 },
    new Symbol { Character = '6', Probability = 0.110 },
    new Symbol { Character = '7', Probability = 0.085 },
    new Symbol { Character = '8', Probability = 0.112 }
};

Console.WriteLine("Метод Шеннона-Фано");
var shannonFano = new ShannonFano(symbols);
shannonFano.Encode();
shannonFano.PrintCodes();

var entropy = Math.Log2(symbols.Count);
var relativeEntropy = -symbols.Sum(x => x.Probability * Math.Log2(x.Probability));
var medianLength = symbols.Sum(x => x.Probability * x.Code.Length);

Console.WriteLine();
Console.WriteLine($@"Энтропия: {relativeEntropy:F3}");
Console.WriteLine($@"Средняя длина символа: {medianLength:F3}");
Console.WriteLine($@"Коэффициент статического сжатия: {entropy / medianLength:F3}");
Console.WriteLine($@"Коэффициент относительной эффективности: {relativeEntropy / medianLength:F3}");

Console.WriteLine();
Console.WriteLine("Метод Хаффмена");

var huffman = new Huffman(symbols);
huffman.Encode();
huffman.PrintCodes();

entropy = Math.Log2(symbols.Count);
relativeEntropy = -symbols.Sum(x => x.Probability * Math.Log2(x.Probability));
medianLength = symbols.Sum(x => x.Probability * x.Code.Length);

Console.WriteLine();
Console.WriteLine($@"Энтропия: {relativeEntropy:F3}");
Console.WriteLine($@"Средняя длина символа: {medianLength:F3}");
Console.WriteLine($@"Коэффициент статического сжатия: {entropy / medianLength:F3}");
Console.WriteLine($@"Коэффициент относительной эффективности: {relativeEntropy / medianLength:F3}");



