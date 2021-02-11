using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamalRace
{
    public abstract class Betting // abstract class 
    {
        public string Title;
        public Bet gamble;
        public int money;
        public bool busted;
        public Label statusLabel, MaximumBet;


        public Betting(Bet bet, Label MaximumBet, int Cash, Label statusLabel)
        {
            this.gamble = bet;
            this.money = Cash;
            this.MaximumBet = MaximumBet;
            this.statusLabel = statusLabel;
            if (this.statusLabel != null)
                this.statusLabel.ForeColor = System.Drawing.Color.Black;

        }
        public void Collect(int Winner)
        {
            money += gamble.Pay(Winner);
        }
        public void UpdateLabels() // update information
        {
            if (gamble == null)
            {
                statusLabel.Text = String.Format("{0} hasn't placed any bets", Title);
            }

            else
            {
                statusLabel.Text = gamble.GetDescription();
            }
            if (money == 0)
            {
                busted = true;
                statusLabel.Text = String.Format("BUSTED!");
                statusLabel.ForeColor = System.Drawing.Color.Red;

            }
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", money);
        }


        public void ClearBet()
        {
            gamble.Amount = 0;
        }

        public bool PlaceBet(int Amount, int Camal)
        {
            if (Amount <= money)
            {
                gamble = new Bet(Amount, Camal, this);
                return true;
            }
            return false;
        }

    }

}

