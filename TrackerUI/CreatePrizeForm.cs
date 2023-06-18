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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text,
                    placeNumberValue.Text,
                    priceAmountValue.Text,
                    prizePercentageValue.Text);

                IDataConection db = GlobalConfig.Connection;
                db.CreatePrize(model);
                
                placeNameValue.Text = "";
                placeNumberValue.Text = "";
                priceAmountValue.Text = "0";
                prizePercentageValue.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid Information. Please check and try again.");
            }
        }

        private bool ValidateForm()
        {
            bool result = true;
            int placeNumber = 0;
            bool placeNumberValidNumber = int.TryParse(placeNumberValue.Text, out placeNumber);

            if (!placeNumberValidNumber || placeNumber < 1)
            {
                result = false;
            }

            if (placeNameValue.Text.Length == 0)
            {
                result = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(placeNumberValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(placeNumberValue.Text, out prizePercentage);

            if (!prizeAmountValid || !prizePercentageValid)
            {
                result = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                result = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                result = false;
            }

            return result;
        }

    }
}
