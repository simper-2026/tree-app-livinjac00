public class BinaryTree
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        Root = GreaterOrLessThan(Root, value, parent: null);
        if (Root != null)
        {
            Root.Parent = null;
            UpdateDepths(Root, 0);
        }
    }

    // public string InOrder()
    // {
    //     return null;
    // }


    public string ToMermaid()
    {
        int links = 0;

        if (Root == null)
        {
            return "graph TD\n";
        }
        else if (Root.Left == null && Root.Right == null)
        {
            return $"graph TD; \n{Root.Value}\n";
        }
        return $"graph TD;\n{ToMermaid(Root, ref links)}";
    }

    private string ToMermaid(Node? node, ref int links)
    {
        if (node == null || (node.Right == null && node.Left == null))
        {
            return string.Empty;
        }
        string result = string.Empty;
        if (node.Left != null)
        {
            result += $"{node.Value} --> {node.Left.Value}[ {node.Left.Value} h:{node.Left.Height} d: {node.Left.Depth} ] \n";
            links++;
            result += ToMermaid(node.Left, ref links);
        }
        else
        {
            result += $"{node.Value} --> _ph1{node.Value}[ ] \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _ph1{node.Value} fill:none,stroke:none,color:none \n";
            links++;
        }
        if (node.Right != null)
        {
            result += $"{node.Value} --> {node.Right.Value}[ {node.Right.Value} h:{node.Right.Height} d: {node.Right.Depth} ] \n";
            links++;
            result += ToMermaid(node.Right, ref links);
        }
        else
        {
            result += $"{node.Value} --> _phr{node.Value}[ ] \n";
            result += $"linkStyle {links} stroke:none,stroke-width:0,fill:none \n";
            result += $"style _phr{node.Value} fill:none,stroke:none,color:none \n";
            links++;
        }

        return result;
    }


    private Node GreaterOrLessThan(Node? currentNode, int value, Node? parent)
    {
        if (currentNode == null)
        {
            return new Node(value: value, parent: parent);
        }

        if (value < currentNode.Value)
        {
            currentNode.Left = GreaterOrLessThan(currentNode.Left, value, currentNode);
            currentNode.Left.Parent = currentNode;
        }
        else if (value > currentNode.Value)
        {
            currentNode.Right = GreaterOrLessThan(currentNode.Right, value, currentNode);
            currentNode.Right.Parent = currentNode;
        }

        return Balance(currentNode);
    }

    private Node RotateRight(Node z)
    {
        Node y = z.Left!;
        Node? t3 = y.Right;
        Node? previousParent = z.Parent;

        y.Right = z;
        y.Parent = previousParent;

        z.Parent = y;
        z.Left = t3;
        if (t3 != null)
        {
            t3.Parent = z;
        }

        UpdateHeight(z);
        UpdateHeight(y);

        return y;
    }

    private Node RotateLeft(Node z)
    {
        Node y = z.Right!;
        Node? t2 = y.Left;
        Node? previousParent = z.Parent;

        y.Left = z;
        y.Parent = previousParent;

        z.Parent = y;
        z.Right = t2;
        if (t2 != null)
        {
            t2.Parent = z;
        }

        UpdateHeight(z);
        UpdateHeight(y);

        return y;
    }

    private Node Balance(Node node)
    {
        UpdateHeight(node);

        int balanceFactor = GetBalance(node);

        if (balanceFactor > 1)
        {
            if (GetBalance(node.Left!) < 0)
            {
                node.Left = RotateLeft(node.Left!);
                node.Left.Parent = node;
            }

            return RotateRight(node);
        }

        if (balanceFactor < -1)
        {
            if (GetBalance(node.Right!) > 0)
            {
                node.Right = RotateRight(node.Right!);
                node.Right.Parent = node;
            }

            return RotateLeft(node);
        }

        return node;
    }

    private static int Height(Node? node)
    {
        return node?.Height ?? 0;
    }

    private static int GetBalance(Node node)
    {
        return Height(node.Left) - Height(node.Right);
    }

    private static void UpdateHeight(Node node)
    {
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
    }

    private static void UpdateDepths(Node? node, int depth)
    {
        if (node == null)
        {
            return;
        }

        node.Depth = depth;
        UpdateDepths(node.Left, depth + 1);
        UpdateDepths(node.Right, depth + 1);
    }
}