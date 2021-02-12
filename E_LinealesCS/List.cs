using System;
using System.Collections.Generic;
using System.Text;

namespace E_LinealesCS
{
    class List<T>
    {
        public class Node
        {
            public T Data;
            public Node Next;
            public Node(T data)
            {
                Data = data;
            }
        }
        Node Top;
        public void Add(T data)
        {
            Node AddNew = new Node(data);
            AddNew.Next = null;
            if(Top == null)
            {
                Top = AddNew;
            }
            else
            {
                Node temp = Top;
                while(temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = AddNew;
            }
        }
        public bool Remove(T data)
        {
            Node temp = Top;
            while(temp.Next != null)
            {
                //node to be deleted is head node
                if(temp.Data.Equals(data) && temp == Top)
                {
                    //head node is the only node
                    if(temp.Next == null)
                    {
                        throw new ArgumentNullException("HeadNode");
                    }
                    temp.Data = temp.Next.Data;
                    Top = temp.Next;
                    temp.Next = temp.Next.Next;
                    GC.Collect();
                    return true;
                }
                else if (temp.Data.Equals(data))
                {
                    Node prev = Top;
                    while (prev != temp)
                    {
                        prev = prev.Next;
                    }
                    prev.Next = prev.Next.Next;
                    GC.Collect();
                    return true;
                }
            }
            return false;
        }

        public int Count()
        {
            int cont = 0;
            Node temp = Top;
            while (temp != null)
            {
                cont++;
                temp = temp.Next;
            }
            return cont;
        }

        public void Foreach(Action<T> action)
        {
            Node temp = Top;
            while (temp != null)
            {
                action(temp.Data);
                temp = temp.Next;
            }
        }

        public T this[int index]
        {
            get
            {
                Node temp = Top;
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
                throw new ArgumentNullException("OutOfRange");
            }
            set
            {
                Node temp = Top;
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
    }
}
