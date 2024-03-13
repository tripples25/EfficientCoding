namespace EfficientCoding;

public class HuffmanNode
{
    public Symbol? Symbol;
    public readonly double Probability;
    public HuffmanNode? RightNode;
    public HuffmanNode? LeftNode;

    public HuffmanNode(Symbol symbol)
    {
        Symbol = symbol;
        Probability = symbol.Probability;
    }
    
    public HuffmanNode(HuffmanNode node1, HuffmanNode node2)
    {
        LeftNode = node1;
        RightNode = node2;
        Probability = node1.Probability + node2.Probability;
    }

    public void Encode(string code)
    {
        if (Symbol == null)
        {
            LeftNode!.Encode(code + "1");
            RightNode!.Encode(code + "0");
        }
        else
        {
            Symbol.Code = code;
        }
    }
}
