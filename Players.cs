using System.Windows.Forms;

namespace CamalRace
{
    public class Mohit : Betting // mohit player class 
    {
        public Mohit(Bet MyBet, Label MaximumBet, int Money, Label MyLabel) : base(MyBet, MaximumBet, Money, MyLabel)
        {
            Title = "Mohit";
        }
    }

    public class Joban : Betting // joban player class
    {
        public Joban(Bet bet, Label MaximumBet, int Money, Label label) : base(bet, MaximumBet, Money, label)
        {
            Title = "Joban";
        }
    }

    public class Love : Betting // love player class
    {
        public Love(Bet bet, Label MaximumBet, int Money, Label label) : base(bet, MaximumBet, Money, label)
        {
            Title = "Love";
        }

    }
}
