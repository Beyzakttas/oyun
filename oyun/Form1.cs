using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oyun
{
    public partial class Form1 : Form
    {
        int boruHizi = 8;
        int gravity = 10;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            BoruAlt.Left -= boruHizi;
            BoruUst.Left -= boruHizi;
            scoreText.Text = "Score:" + score;
            if(BoruAlt.Left<-150)
            {
                BoruAlt.Left = 800;
                score++;
            }
            if(BoruUst.Left<-180)
            {
                BoruUst.Left = 950;
                score++;
            }
            if (Bird.Bounds.IntersectsWith(BoruAlt.Bounds) ||
                Bird.Bounds.IntersectsWith(BoruUst.Bounds) ||
                Bird.Bounds.IntersectsWith(Zemin.Bounds))
            {
                endGame();
            }
            if (score > 5)
            {
                boruHizi = 15;
            }
            if (Bird.Top<-25)
            {
                endGame();
            }
        }

        private void gamekeysdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeysup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            { 
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "GAME OVER!";
        } 
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
