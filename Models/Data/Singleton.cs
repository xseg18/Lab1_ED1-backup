using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELineales;

namespace Lab1_ED1__backup_.Models.Data
{
    public sealed class Singleton
    {
        public readonly static Singleton _instance = new Singleton();
        public System.Collections.Generic.List<Player> PlayerList;
        public readonly static Singleton _instance1 = new Singleton();
        public ELineales.DoublyList<Player> PlayerDList;
        public readonly static Singleton _instance2 = new Singleton();
        public System.Collections.Generic.List<Player> PlayerSearch;
        public readonly static Singleton _instance3 = new Singleton();
        public ELineales.DoublyList<Player> PlayerDSearch;
        private Singleton()
        {
            PlayerList = new System.Collections.Generic.List<Player>();
            PlayerDList = new ELineales.DoublyList<Player>();
            PlayerSearch = new System.Collections.Generic.List<Player>();
            PlayerDSearch = new ELineales.DoublyList<Player>();
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
        public static Singleton Instance2
        {
            get
            {
                return _instance2;
            }
        }
        public static Singleton Instance3
        {
            get
            {
                return _instance3;
            }
        }
    }
}
