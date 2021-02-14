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
        public Lista<Player> PlayerList;
        
        private Singleton()
        {
            PlayerList = new Lista<Player>();
        }
        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
        
    }
}
