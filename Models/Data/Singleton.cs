using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_LinealesCS;

namespace Lab1_ED1__backup_.Models.Data
{
    public sealed class Singleton
    {
        public readonly static Singleton _instance = new Singleton();
        public ListCS<Player> PlayerList;
        public readonly static Singleton _instance1 = new Singleton();
        public DoublyList<Player> PlayerDList;
        private Singleton()
        {
            PlayerList = new ListCS<Player>();
            PlayerDList = new DoublyList<Player>();
        }
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
        public static Singleton Instance1
        {
            get
            {
                return _instance1;
            }
        }
    }
}
