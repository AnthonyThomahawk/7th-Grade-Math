using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Learning
{
    public class Countdown
    {
        Label output;

        int Min;
        int Sec;

        Boolean minuteElapsed = false;

        public Countdown(int Min_, int Sec_, Label L)
        {
            Min = Min_;
            Sec = Sec_;
            output = L;
        }

        public bool doCountdown()
        {
            string mid = ":";
            if (Sec > 0)
            {
                Sec = Sec - 1;
                minuteElapsed = false;
            }
            else if (Sec == 0)
            {
                Sec = 59;
                minuteElapsed = true;
            }
            if (minuteElapsed == true)
            {
                Min = Min - 1;
            }
            if (Min == 0 && Sec == 0)
            {
                output.Text = "Time's Up!";
                return true;
            }

            if (Sec < 10)
                mid = mid + "0";
            if (Min < 10)
                mid = "0" + mid;

            output.Text = Min + mid + Sec;
            return false;
        }
    }
}
