<Query Kind="Program">
  <Reference Relative="..\ObjectDumper\bin\Debug\ObjectDumper.dll">C:\Dev\VS.NET\ObjectDumper\ObjectDumper\bin\Debug\ObjectDumper.dll</Reference>
  <Namespace>ObjectDumper</Namespace>
</Query>

void Main()
{
	var root = new Node
    {
        Value = "root",
        Left = new Node
        {
            Value = "left sub-tree",
            Left = new Node
            {
                Value = "left-left sub-tree",
            },
        },
        Right = new Node
        {
            Value = "right sub-tree",
            Left = new Node
            {
                Value = "right-left sub-tree",
            },
        }
    };
    ObjectDumperExtensions.Dump(root, "root");
}

public class Node
{
    public string Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}