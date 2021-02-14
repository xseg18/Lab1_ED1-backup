using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ELineales
{
	public class DoublyList<T> : Lista<T>, IEnumerable<T>
	{
		class Node1
		{
			public T Data;
			public Node1 Prev;
			public Node1 Next;
			public Node1(T data)
			{
				Data = data;
			}
		};
		Node1 Top;

		public void Push(T data)
		{
			Node1 AddNew = new Node1(data);
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
			Node1 temp = Top;
			while (temp.Next != null && count != index)
			{
				if (count == index - 1)
				{
					Node1 prev = temp;
					Node1 del = temp.Next;
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
			Node1 temp = Top;
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
