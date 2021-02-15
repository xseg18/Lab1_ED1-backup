﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ELineales
{
	public class DoublyList<T> : IEnumerable<T>
	{
		class NODE
		{
			public T Data;
			public NODE Prev;
			public NODE Next;
			public NODE(T data)	
			{
				Data = data;
			}
		};
		NODE Top;

		public void Push(T data)
		{
			NODE AddNew = new NODE(data);
			AddNew.Next = Top;
			AddNew.Prev = null;
			if (Top != null)
			{
				Top.Prev = AddNew;
			}
			Top = AddNew;
		}
		public int Count()
		{
			int contador = 0;
			NODE count = Top;
			while (count != null)
			{
				contador++;
				count = count.Next;
			}
			return contador;
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
			NODE temp = Top;
			while (temp.Next != null && count != index)
			{
				if (count == index - 1)
				{
					NODE prev = temp;
					NODE del = temp.Next;
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
			NODE temp = Top;
			while (temp != null)
			{
				yield return temp.Data;
				temp = temp.Next;
			}
		}
		public IEnumerator<T> GetEnumerator()
		{
			return Events().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		public void Foreach(Action<T> action)
		{
			NODE temp = Top;
			while (temp != null)
			{
				action(temp.Data);
				temp = temp.Next;
			}
		}
		public int IndexOf(T item)
		{
			int pos = 0;
			NODE actual = Top;
			while (actual.Next != null)
			{
				if (actual.Data.Equals(item))
				{
					return pos;
				}
				else
				{
					actual = actual.Next;
					pos++;
				}
			}
			return -1;
		}

		public T this[int index]
		{
			get
			{
				NODE temp = Top;
				int cont = 0;
				while (temp != null)
				{
					if (cont == index)
					{
						return temp.Data;
					}
					else
					{
						temp = temp.Next;
						cont++;
					}
				}
				throw new System.ArgumentNullException("OutOfRange");
			}
			set
			{
				NODE temp = Top;
				int cont = 0;
				while (temp != null)
				{
					if (cont == index)
					{
						temp.Data = value;
						break;
					}
					else
					{
						temp = temp.Next;
						cont++;
					}
				}
			}
		}
		public void Clear()
		{

			NODE temp = Top;
			while (temp != null)
			{
				temp = null;
				temp = temp.Next;
			}
		}
	}
}
