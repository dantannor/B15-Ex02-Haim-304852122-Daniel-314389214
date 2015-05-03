using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    using System.Media;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Scan input
            scanInput();
        }

        /*
         * Scan user input
         */

        private static void scanInput()
        {
            Console.WriteLine("Enter Player1 name");
            string player1Name = Console.ReadLine();
            checkInput(player1Name);

            // If valid string, initialize player1
            Player player1 = new Player(name, player);

            Console.WriteLine(@"Choose your opponent:
                                 1. Player
                                 2. Computer");

            string opponentType = Console.ReadLine();

            if (opponentType)
            {

            }

        }

        /*
         * Checks input and re-requests if it's problematic
         */
        private void checkInput(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);
            while (!isNumber || stringNumber.Length != 8 || number < 0)
            {
                Console.WriteLine("invalid number, try again");
                stringNumber = Console.ReadLine();
                isNumber = int.TryParse(stringNumber, out number);
            }
        }
    }
}

    
