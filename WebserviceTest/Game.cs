using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceTest
{
    class Game
    {
        private String _team1;
        private String _team2;
        private String _result;

        public string Team1
        {
            get
            {
                return _team1;
            }

            set
            {
                _team1 = value;
            }
        }

        public string Team2
        {
            get
            {
                return _team2;
            }

            set
            {
                _team2 = value;
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }
    }
}
