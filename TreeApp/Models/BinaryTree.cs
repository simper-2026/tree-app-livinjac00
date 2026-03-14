public class BinaryTree
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        Root = GreaterOrLessThan(Root, value: value);
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


    private Node GreaterOrLessThan(Node? currentNode, int value)
    {
        if (currentNode == null)
        {
            return new Node(value: value);
        }

        if (value < currentNode.Value)
        {
            currentNode.Left = GreaterOrLessThan(currentNode.Left, value);
        }
        else if (value > currentNode.Value)
        {
            currentNode.Right = GreaterOrLessThan(currentNode.Right, value);
        }

        return currentNode;
    }
}