using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel model) 
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = (int)Math.Pow(2,rounds) - randomizedTeams.Count;
            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            CreateOtherRounds(model, rounds);
        }
        private static void CreateOtherRounds(TournamentModel model, int rounds) 
        {
            int currRound = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currentRound = new();
            MatchupModel currMatchup = new();

            while (currRound <= rounds)
            {
                foreach (MatchupModel matchup in previousRound) 
                {
                    currMatchup.Enteries.Add(new MatchupEntryModel { ParentMatchup = matchup });

                    if (currMatchup.Enteries.Count > 1) 
                    {
                        currMatchup.MatchupRound = rounds;
                        currentRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }
                model.Rounds.Add(currentRound);
                previousRound = currentRound;
                currentRound = new();
                currRound++;
            }
            
        }
        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams) 
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel currentModel = new();

            foreach (TeamModel team in teams)
            {
                currentModel.Enteries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (byes > 0 || currentModel.Enteries.Count > 1) 
                {
                    currentModel.MatchupRound = 1;
                    output.Add(currentModel);
                    currentModel = new();
                    byes -= byes != 0 ?  1: 0;
                }

            }
            return output;
        }
        
        private static int FindNumberOfRounds(int teamCount)
        { 
            int output = 1;
            int val = 2;
            while (val < teamCount)
            {
                output += 1;
                val *= 2;
            }
            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams) 
        {
            return teams.OrderBy(a=>Guid.NewGuid()).ToList();
        }

    }
}
