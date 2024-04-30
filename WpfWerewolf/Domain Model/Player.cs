using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Werewolf_Companion.Domain_Model
{
    public class Player
    {
        private int id { get; set; }
        public string name { get; set; }
        public bool isAlive { get; set; }
        public bool isCharmed { get; set; }
        public bool isProtected { get; set; }
        public Role assignedRole { get; set; }



        public Player(string name) {
            this.name = name.ToLower();
            isAlive = true;
            isCharmed = false;
        }
    }
}
