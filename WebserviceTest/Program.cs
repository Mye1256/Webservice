using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebserviceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Webservice.HelloWorldService ws = new Webservice.HelloWorldService();
            Webservice.wsdlObject obj = ws.getWsdlObject();
            List<Tournament> tournaments = new List<Tournament>();
            foreach(Webservice.tournamentDTO tournamentdto in obj.tournaments)
            {
                Tournament tournament = new Tournament();
                tournament.setName(tournamentdto.name);
                foreach(Webservice.gameDTO gamedto in obj.matches)
                {
                    if(gamedto.tournament == tournamentdto.id)
                    {
                        Game game = new Game();
                        String result1 = "";
                        String result2 = "";
                        if(gamedto.resultTeam1 != "" || gamedto.resultTeam1 != null)
                        {
                            result1 = gamedto.resultTeam1;
                        }

                        if(gamedto.resultTeam2 != "" || gamedto.resultTeam2 != null)
                        {
                            result2 = gamedto.resultTeam2;
                        }
                        game.Result = result1 + " : " + result2;
                        String team1 = "";
                        String team2 = "";
                        foreach(Webservice.teamDTO teamdto in obj.teams)
                        {
                            
                            if(teamdto.id == gamedto.internTeam1)
                            {
                                team1 = teamdto.name;
                            } 
                            if(teamdto.id == gamedto.internTeam2)
                            {
                                team2 = teamdto.name;
                            }
                            if (gamedto.externTeam1 != null && gamedto.externTeam1 != "")
                            {
                                team1 = gamedto.externTeam1;
                            }
                            if (gamedto.externTeam2 != null && gamedto.externTeam2 != "") 
                            {
                                team2 = gamedto.externTeam2;
                            } 
                            game.Team1 = team1;
                            game.Team2 = team2;
                        }
                        tournament.addGame(game);
                    }
                }
                tournaments.Add(tournament);
            }
            Console.WriteLine(ws.getServerTimeString());
            foreach(Tournament tournament in tournaments)
            {
                Console.WriteLine("Tournament: " + tournament.getName());
                foreach(Game game in tournament.getGames())
                {
                    Console.WriteLine("Game between " + game.Team1 + " and " + game.Team2);
                    Console.WriteLine("Result: " + game.Result);
                }
                Console.WriteLine("------------------------------------------");
            }
            Console.ReadKey();
        }
    }
}
