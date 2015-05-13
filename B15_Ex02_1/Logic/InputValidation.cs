using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1.Logic
{
    using System.Text.RegularExpressions;

    public class InputValidation
    {

        /*
          * Validates correct input for player name
          */
        public static bool ValidatePlayerName(string io_playerName)
        {
            const string sPattern = "[A-Za-z0-9]+";

            return Regex.IsMatch(io_playerName, sPattern);
        }
    }
}
