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
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = new();
        private List<PersonModel> selectedTeamMembers = new();


        public CreateTeamForm()
        {
            InitializeComponent();
            CreateSampleData();
            WireUpLists();
        }

        private void CreateSampleData() 
        {
            availableTeamMembers.Add(new PersonModel { FirstName = "Khush", LastName = "Singh" });
            availableTeamMembers.Add(new PersonModel { FirstName = "John", LastName = "Doe" });
            availableTeamMembers.Add(new PersonModel { FirstName = "Doe", LastName = "John" });   
        }

        private void WireUpLists()
        {
            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = "FullName";

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel p = new PersonModel();

                p.FirstName = firstNameValue.Text;
                p.LastName = lastNameValue.Text;
                p.CellPhoneNumber = cellPhoneValue.Text;
                p.EmailAddress = emailValue.Text;

                GlobalConfig.Connection.CreatePerson(p);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                cellPhoneValue.Text = "";

            }
            else
            {
                MessageBox.Show("You Need to fill all fields");
            }
        }

        private bool ValidateForm()
        {
            //TODO - Add Validations to the form
            if (firstNameValue.Text.Length == 0)
            {
                return false;
            }

            if (emailValue.Text.Length == 0)
            {
                return false;
            }

            if (cellPhoneValue.Text.Length == 0)
            {
                return false;
            }

            if (lastNameValue.Text.Length == 0)
            {
                return false;
            }

            return true;
        }
    }
}
