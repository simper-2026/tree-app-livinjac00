public class BinaryTree
{
    public Node? Root { get; private set; }

    public void Insert(int value)
    {
        Root = GreaterOrLessThan(Root, value: value);
    }

    public string InOrder()
    {
        return null;
    }

    public int Height()
    {
        return 0;
    }

    public string ToMermaid()
    {
        return @"graph TD
    8 --> 5
    8 --> 15
    5 --> 3
    5 --> _ph1[ ]
    linkStyle 3 stroke:none,stroke-width:0,fill:none
    style _ph1 fill:none,stroke:none,color:none
    3 --> _ph2[ ]
    linkStyle 4 stroke:none,stroke-width:0,fill:none
    style _ph2 fill:none,stroke:none,color:none
    3 --> 4";
    }


    private Node GreaterOrLessThan(Node? currentNode, int value)
    {
        if (currentNode == null)
        {
            return new Node (value: value);
        }

        if (value < currentNode.Value)
        {
            currentNode.Left = GreaterOrLessThan(currentNode.Left, value);
        }
        else if(value > currentNode.Value)
        {
            currentNode.Right = GreaterOrLessThan(currentNode.Right, value);
        }

        return currentNode;
    }
}