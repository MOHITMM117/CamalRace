using System;
using System.Windows.Forms;

namespace CamalRace
{
    public static class PlayerFactory
    {
        public static Betting GetBetting(String Name, Label MaximumBet, Label bet)
        {
            Betting b;
            switch (Name)
            {
                case "Mohit":
                    b = new Mohit(null, MaximumBet, 50, bet);
                    break;

                case "Joban":
                    b = new Joban(null, MaximumBet, 50, bet);
                    break;

                case "Love":
                    b = new Love(null, MaximumBet, 50, bet);
                    break;

                default:
                    b = null;
                    break;
            }

            return b;
        }
    }
}
