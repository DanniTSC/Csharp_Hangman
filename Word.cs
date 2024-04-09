using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialYt
{
    public class Word
    {
        string text;
        int difficulty;

        public Word() {
            text = "Spanzuratoarea";
            difficulty = 0;
        }
        public string Text
        {
            get{ return text; }
            set { text = value; }
        }

        public int Difficulty
        { get { return difficulty; } 
            set {  difficulty = value; } }
    }
}
