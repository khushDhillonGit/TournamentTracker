using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// Represents One Team in the Matchup
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Represents score for this team
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Represents the mathcup from where this team came as winner
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

    }
}
