using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace CamalRace
{
   public  class Camal
    {

        public int Location = 0;
        public static Random MyRandom = new Random(); //declared random object as static to avoid same random number

        public static int Start { get; set; }
        public static int Racetrack { get; set; }
        public PictureBox CamalPictureBox { get; set; } = null;

        // generation across all  Camal objects

        public static bool Run(Camal obj)
        {
            int distance = MyRandom.Next(1, 10);
            if (obj.CamalPictureBox != null)
                obj.MoveCamalPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (Racetrack - Start))
            {
                return true;
            }
            return false;
        }

        public void StartPosition()
        {
            MoveCamalPictureBox(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        public void MoveCamalPictureBox(int distance)
        {
            Point p = CamalPictureBox.Location;
            p.X += distance;
            CamalPictureBox.Location = p; //move  Camal in x-axis
        }
    }
}

