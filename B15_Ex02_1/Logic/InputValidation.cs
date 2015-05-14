// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputValidation.cs" company="">
//   
// </copyright>
// <summary>
//   The input validation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace B15_Ex02_1.Logic
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The input validation.
    /// </summary>
    public class InputValidation
    {
        /*
          * Validates correct input for player name
          */

        /// <summary>
        /// The validate player name.
        /// </summary>
        /// <param name="io_playerName">
        /// The io_player name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidatePlayerName(string io_playerName)
        {
            const string sPattern = "[A-Za-z0-9]+";

            return Regex.IsMatch(io_playerName, sPattern);
        }
    }
}