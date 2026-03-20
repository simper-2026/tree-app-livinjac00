public class Node
{
    public int Value { get; private set; }
    public Node? Parent { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public int Height;
    public int Depth;

    public Node(int value, Node? parent = null, Node? left = null, Node? right = null)
    {
        Parent = parent;
        Left = left;
        Right = right;
        Value = value;

        Height = 1;
        Depth = 0;
    }
}