using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace CamalRace
{
    public partial class Form1 : Form
    {
        readonly Camal[] Camals = new Camal[4]; // camal arry 

        readonly Betting[] Bet = new Betting[3]; // betting arry players

        public Form1()
        {
            InitializeComponent();
            TrackInitialize(); // race track initializing
        }
        private void TrackInitialize()
        {

            Camal.Start = Camal1.Right - RaceTrack.Left;
            Camal.Racetrack = RaceTrack.Size.Width - 70; //connect the length of race - upto ending line

            Camals[0] = new Camal() { CamalPictureBox = Camal1 };
            Camals[1] = new Camal() {CamalPictureBox = Camal2 };
            Camals[2] = new Camal() { CamalPictureBox = Camal3 };
            Camals[3] = new Camal() { CamalPictureBox = Camal4 };

            Bet[0] = PlayerFactory.GetBetting("Mohit", MaximumBet, MohitBet); //obtaing  Mohit object from factory class
            Bet[1] = PlayerFactory.GetBetting("Joban", MaximumBet, JobanBet); //obtaing Joban object from factory class
            Bet[2] = PlayerFactory.GetBetting("Love", MaximumBet, LoveBet); //obtaing Love object from factory class

            Debug.WriteLine(Bet[0].Title);

            foreach (Betting bettor in Bet)
            {
                bettor.UpdateLabels();
            }
        }
        private void MaximumLimit(int Cash)
        {
            MaximumBet.Text = string.Format("Maximum Bet: ${0}", Cash);
        }

        private void mohitButton_CheckedChanged(object sender, EventArgs e)
        {
            MaximumLimit(Bet[0].money);
        }
        private void jobanButton_CheckedChanged(object sender, EventArgs e)
        {
            MaximumLimit(Bet[1].money);
        }

        private void loveButton_CheckedChanged(object sender, EventArgs e)
        {
            MaximumLimit(Bet[2].money);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Bets_Click(object sender, EventArgs e) //bet click for place a bet
        {

            int BettorNum = 0;

            if (MohitButton.Checked)
            {
                BettorNum = 0;
            }
            if (JobanButton.Checked)
            {
                BettorNum = 1;
            }
            if (LoveButton.Checked)
            {
                BettorNum = 2;
            }

            Bet[BettorNum].PlaceBet((int)BettingAmount.Value, (int)CamalNumber.Value);
            Bet[BettorNum].UpdateLabels();
        }

        private void race_Click(object sender, EventArgs e)
        {

            bool NoWinner = true;
            int winningCamal;
            race.Enabled = false; //disable start race button

            while (NoWinner)
            { // loop until we have a winner
                Application.DoEvents();
                for (int i = 0; i < Camals.Length; i++)
                {
                    if (Camal.Run(Camals[i]))
                    {
                        winningCamal = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a defeater -  Camal #" + winningCamal);
                        foreach (Betting bettor in Bet)
                        {
                            if (bettor.gamble != null)
                            {
                                bettor.Collect(winningCamal); //give double sum to all who have achieve or conclued betted sum
                                bettor.gamble = null;
                                bettor.UpdateLabels();
                            }
                        }
                        foreach (Camal Camal in Camals)
                        {
                            Camal.StartPosition();
                        }
                        break;
                    }
                }
            }
            if (Bet[0].busted && Bet[1].busted && Bet[2].busted)
            {  //stop bettors from betting if they run out of cash
                string message = "Do you want to play this game once more time?";
                string title = "Game Finished!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    TrackInitialize(); //restart game
                }
                else
                {
                    Close();
                }

            }
            race.Enabled = true; //enable race button 
        }

        private void Camal2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
