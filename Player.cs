using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialYt
{
    public class Player
    {
        string name;

        public Player() {
            name = "Player1";
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
