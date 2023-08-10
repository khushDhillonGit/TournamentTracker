using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequester, ITeamRequester
    {
        List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        List<TeamModel> selectedTeams = new List<TeamModel>();
        List<PrizeModel> selectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            InitializeLists();
        }

        private void InitializeLists()
        {
            selectTeamDropDown.DataSource = null;
            selectTeamDropDown.Items.Clear();
            selectTeamDropDown.DataSource = availableTeams;
            selectTeamDropDown.DisplayMember = "TeamName";

            tournamentPlayersListBox.DataSource = null;
            tournamentPlayersListBox.Items.Clear();
            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.Items.Clear();
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel team = (TeamModel)selectTeamDropDown.SelectedItem;
            if (team != null)
            {
                availableTeams.Remove(team);
                selectedTeams.Add(team);
                InitializeLists();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm form = new CreatePrizeForm(this);
            form.Show();
        }

        public void PrizeComplete(PrizeModel model)
        {
            selectedPrizes.Add(model);
            InitializeLists();
        }

        public void TeamComplete(TeamModel model)
        {
            selectedTeams.Add(model);
            InitializeLists();
        }

        private void createTeamLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm form = new CreateTeamForm(this);
            form.Show();
        }

        private void deleteSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            PrizeModel prize = (PrizeModel)prizesListBox.SelectedItem;

            if (prize != null)
            {
                selectedPrizes.Remove(prize);
                InitializeLists();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {

            bool feeAcceptable = decimal.TryParse(entryFeeValue.Text, out decimal fee);

            if (!feeAcceptable) 
            {
                MessageBox.Show("You need to enter a valid entry fee.", 
                    "Invalid Fess",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            TournamentModel tournament = new();
            tournament.TournamentName = tournamentNameValue.Text;
            tournament.EntryFee = fee;
            tournament.Prizes = selectedPrizes;
            tournament.EnteredTeams = selectedTeams;

            //Create matchups

            GlobalConfig.Connection.CreateTournament(tournament);  

        }
    }
}
