using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamalRace
{
   public class Bet // bet class 
    {

        public int Amount;
        public int CamalNum;
        public Betting Betting;

        public Bet(int Amount, int CamalNum, Betting Bettor)
        {
            this.Amount = Amount;
            this.CamalNum = CamalNum;
            this.Betting = Bettor;
        }
        public string GetDescription()
        {
            string description;
            if (Amount > 0)
            {
                description = string.Format("{0} bets {1} on Camal #{2}",
                    Betting.Title, Amount, CamalNum);
            }
            else
            {
                description = string.Format("{0} hasn't placed any bets",
                    Betting.Title);
            }
            return description;
        }

        public int Pay(int Winner) //  winner
        {
            if (CamalNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
