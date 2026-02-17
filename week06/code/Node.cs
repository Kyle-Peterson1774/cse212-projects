public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        else
        {
            return;
        }
    }


    public bool Contains(int value)
    {
        if (value == Data)
        {   
            return true;
        }
        else if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }
        else
        {
            return Right is not null && Right.Contains(value);
        }

    }

    public int GetHeight()
    {
        int leftHeight = Left is null ? 0 : Left.GetHeight();
        int rightHeight = Right is null ? 0 : Right.GetHeight();

        return 1 + Math.Max(leftHeight, rightHeight);

    }
}