using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel : IFields
    {
        public int Id { get; set; }
        public string? TeamName { get; set; }

        private List<PersonModel> teamMembers = new List<PersonModel>();
        public List<PersonModel> TeamMembers
        {
            get { return teamMembers; }
            set
            {
                teamMembers = value;
                TeamMembersIds = string.Join('|', teamMembers.Select(x => x.Id.ToString()));
            }
        } 
        public string TeamMembersIds { get; set; } = "";
    }
}
