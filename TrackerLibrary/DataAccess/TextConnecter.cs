using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class TextConnecter : IDataConection
    {
        //TODO - wire up createPrize text files
        public PrizeModel CreatePrize(PrizeModel model)
        {
            return new PrizeModel();
        }
    }
}
