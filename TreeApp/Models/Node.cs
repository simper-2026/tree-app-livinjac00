public class Node
{
    public int Value { get; private set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(Node? left = null, Node? right = null, int value = 0)
    {
        Left = left;
        Right = right;
        Value = value;
    }
}