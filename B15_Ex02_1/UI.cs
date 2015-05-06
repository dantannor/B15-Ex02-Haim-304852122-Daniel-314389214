using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    class UI
    {

        public static void Main()
        {

            Player player1 = new Player("a");
            Player player2 = new Player("b");
            Controller c = new Controller(player1, player2, 8, 2);

            c.GameAgainstPlayer();

        }
    }
}
