public class Node
{
    public int Value { get; private set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public int Height;
    public int Depth;

    public Node(int value, Node? left = null, Node? right = null)
    {
        Left = left;
        Right = right;
        Value = value;

        Height = 13;
        Depth = 7;
    }
}