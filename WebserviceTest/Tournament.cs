using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceTest
{
    class Tournament
    {
        private String name;
        private List<Game> _games = new List<Game>();

        public String getName()
        {
            return name;
        }
        public void addGame(Game game)
        {
            _games.Add(game);
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public List<Game> getGames()
        {
            return _games;
        }
    }
}
