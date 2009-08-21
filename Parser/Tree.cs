using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
	public class Tree<T>
	{
		public Tree(T value)
		{
			this.value = value;
		}

		private T value;
		public T Value
		{
			get { return value; }
		}

		private readonly List<Tree<T>> leafs = new List<Tree<T>>();
		public List<Tree<T>> Leafs
		{
			get { return leafs; }
		} 

		public bool IsLeaf
		{
			get { return leafs.Count == 0; }
		}
	}
}
