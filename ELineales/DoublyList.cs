using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ELineales
{
	public class DoublyList<T> : Lista<T>, IEnumerable<T>
	{
		class Node
		{
			public T Data;
			public Node Prev;
			public Node Next;
			public Node(T data)
			{
				Data = data;
			}
		};
		Node Top;

		public void Push(T data)
		{
			Node AddNew = new Node(data);
			AddNew.Next = Top;
			AddNew.Prev = null;
			if (Top != null)
			{
				Top.Prev = AddNew;
			}
			Top = AddNew;
		}
		public bool DeleteAt(int index)
		{
			if (Top == null || index == 0)
			{
				throw new System.ArgumentNullException("Empty List");
			}
			if (index == 0)
			{
				Top = Top.Next;
			}
			int count = 0;
			Node temp = Top;
			while (temp.Next != null && count != index)
			{
				if (count == index - 1)
				{
					Node prev = temp;
					Node del = temp.Next;
					prev.Next = del;
					del.Prev = prev;
					return true;
				}
				else
				{
					temp = temp.Next;
				}
			}
			return false;
		}
		private IEnumerable<T> Events()
		{
			Node temp = Top;
			while (temp != null)
			{
				yield return temp.Data;
				temp = temp.Next;
			}
		}
		public new IEnumerator<T> GetEnumerator()
		{
			return Events().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}
