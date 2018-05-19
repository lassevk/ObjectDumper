using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumper.Tests
{
    public class EmptyClass { }

    public class TwoProperties
	{
		public string Property1 { get; set; }
		public int Property2 { get; set; }
	}

	public class Node
	{
		public string Value { get; set; }
		public Node Left { get; set; }
		public Node Right { get; set; }

		public static Node Root = new Node
		{
			Value = "root", //1
			Left = new Node
			{
				Value = "left sub-tree", // 2
				Left = new Node
				{
					Value = "left-left sub-tree", // 3
				},
			},
		};
	}


}
