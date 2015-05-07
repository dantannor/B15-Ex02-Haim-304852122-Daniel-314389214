using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B15_Ex02_1
{
    class Player
    {
        string m_name;
        int m_points;

        public Player(string io_name)
        {
            this.m_name = io_name;
            this.m_points = 0;
        }

        public int Points
        {
            get { return m_points; }
            set { m_points = value; }
        }
        public string GetPlayerName
        {
            get { return this.m_name; }
        }
    }
}
