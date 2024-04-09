using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace TutorialYt
{
    public class Game
    {
        public static DateTime date_started;
        public static Player game_player;
        public static Word game_word;
        public static int nb_of_lifes;
   
      static Game()
        {
            date_started = DateTime.Now;
            game_player = new Player();
            game_word = new Word();
            nb_of_lifes = 5;
        }
    }//end of class
}
