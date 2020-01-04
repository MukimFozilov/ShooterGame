using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShooter
{
    public partial class Form1 : Form
    {
        int bulletcount = 0;
        int score = 0;
        Random ran = new Random();

        public Form1()
        {
            
            InitializeComponent();
            lb_score.Enabled = false;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Enabled = true;
            pictureBox2.Left += 10;
          
             
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox3.Enabled = true;
            pictureBox3.Left += 10;
        }

        private void Random_Plan(int speed)
        {
            Random r = new Random();

            int x1, y1, x2, y2, x3, y3;
            if (pictureBox4.Left >= 0 || pictureBox5.Left >= 0 || pictureBox6.Left >= 0)
            {
                pictureBox4.Left += -speed;
                pictureBox5.Left += -speed;
                pictureBox6.Left += -speed;
             
            }
            else
            {
                x1 = r.Next(0, 900);
                y1 = r.Next(0, 600);
                x2 = r.Next(0, 800);
                y2 = r.Next(0, 500);
                x3 = r.Next(0, 950);
                y3 = r.Next(0, 550);

                pictureBox4.Location = new Point(x1, y1);
                pictureBox5.Location = new Point(x2, y2);
                pictureBox6.Location = new Point(x3, y3);  
                
            }
        }

        private void GameOver()
        {
            if(pictureBox4.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                timer3.Enabled = false;
                label1.Text = "Game over";
            }
        }

        private void Shooter_Plane()
        {
            if (pictureBox4.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                pictureBox4.Location = new Point(ran.Next(100, 800), ran.Next(300, 600));
                score++;
                lb_score.Text = "Score = "+score.ToString();
            }
            
        }

        private void Restart()
        {
            Application.Restart();
        }

     
      
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           if(e.KeyCode == Keys.Down)
           {
               if(pictureBox1.Top <900)
               {
                   pictureBox1.Top += 10;
               }
               
           }
            else if(e.KeyCode == Keys.Up)
           {
                if(pictureBox1.Top > 10)
                {
                    pictureBox1.Top -=10;
                }    
           }
           else if(e.KeyCode == Keys.Space)
           {
               if(bulletcount % 1 == 0)
               {
                   pictureBox2.Location = pictureBox1.Location;
                   bulletcount++;
               }
         
           }
            else if (e.KeyCode == Keys.R)
           {
               Restart();
           }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random_Plan(100);
          
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            Shooter_Plane();
            GameOver();
           
        }

       
    }
}
