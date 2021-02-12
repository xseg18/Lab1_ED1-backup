using System;

namespace E_LinealesCS
{
    public class DoublyList<T>
    {
        public class Node
        {
            public T Data;
            public Node Next;
            public Node Prev;
            public Node(T data)
            {
                Data = data;
            }
        }
        Node Top;
        public void Push(T info)
        {
            Node AddNew = new Node(info);
            AddNew.Next = Top;
            AddNew.Prev = null;
            if(Top != null)
            {
                Top.Prev = AddNew;
            }
            Top = AddNew;
        }
        public void Delete(T data)
        {
            if (Top == null || data == null)
            {
                return;
            }
            Node search = new Node(data);
            search = Top;
            while (search.Next != null)
            {
                if (search.Data.Equals(data))
                {
                    break;
                }
                else
                {
                    search = search.Next;
                }
            }
            if (Top.Data.Equals(data))
            {
                Top = Top.Next;
            }
            if (search.Next != null)
            {
                search.Next.Prev = search.Prev;
            }
            if (search.Prev != null)
            {
                search.Prev.Next = search.Next;
            }

            return;
        }

        public int Count()
        {
            int contador = 0;
            Node count = Top;
            while (count != null)
            {
                contador++;
                count = count.Next;
            }
            return contador;
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
        //     public T Pos{
        //get{
        //         Node ^ temp = top;
        //         int cont = 0;
        //         while (temp)
        //         {
        //             if (cont == index)
        //             {
        //                 return temp->Data;
        //             }
        //             else
        //             {
        //                 temp = temp->Next;
        //                 cont++;
        //             }
        //         }
        //         throw gcnew System::ArgumentNullException("OutOfRange");
        //     }
        //     void set(int index, T value)
        //     {
        //         Node ^ temp = top;
        //         int cont = 0;
        //         while (temp)
        //         {
        //             if (cont == index)
        //             {
        //                 temp->Data = value;
        //                 break;
        //             }
        //             else
        //             {
        //                 temp = temp->Next;
        //                 cont++;
        //             }
        //         }
        //     }
    }
}
