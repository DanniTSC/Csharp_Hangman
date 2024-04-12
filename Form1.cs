using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TutorialYt
{
    public partial class Form1 : Form
    {
        public Game game = null;
        public Form1()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           New_game();
        }
        private void New_game()
        {
            game = new Game();
            NameForm nf = new NameForm();
            nf.ShowDialog();
            label2.Text = "";
            foreach (char c in Game.game_word.Text)
            {
                label2.Text += "_ ";
            }
            panel1.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Game.game_word.Text.ToUpper().Contains(textBox1.Text))
            {
                int i = 0;
                string new_label_text = "";
                foreach (char c in Game.game_word.Text)
                {
                    if (label2.Text[i] == '_')
                    {
                        if (c.ToString().ToUpper() == textBox1.Text)
                        {
                            new_label_text += textBox1.Text + " ";
                        }
                        else
                        {
                            new_label_text += "_ ";
                        }
                    }
                    else
                    {
                        new_label_text += label2.Text[i] + " ";
                    }
                    i = i + 2;
                }
                label2.Text = new_label_text;
            }
            else
            {
                Game.nb_of_lifes--;
                //desenez spanzuratul
                panel1.Invalidate(); //refresh panel
            }
            this.textBox1.Text = "";
            if(Game.nb_of_lifes == 0 )
            {
                MessageBox.Show("Game Over!","You lost",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                New_game();
            }
            else if(!label2.Text.Contains('_'))
            {
               DialogResult dr = MessageBox.Show("You Won!\r\nYour score is " + Game.nb_of_lifes + ".\r\n Do you want to start a new game ?", "Congrats", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                using (FileStream fs = new FileStream("D:\\hangman.dat", FileMode.Append))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(Game.game_player.Name + "|" + Game.nb_of_lifes + "|" + Game.date_started);
                    }
                }



               if (dr == DialogResult.Yes)
                {
                    New_game();
                }
                else
                {
                    Application.Exit();
                }
                
            }
        }//end of function

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_game();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hangman Game created by Dani 2nd year of University", "About the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            switch (Game.nb_of_lifes)
            {
                case 5:
                    break;
                case 4: 
                    Rectangle rec = new Rectangle(panel1.Width / 2 - 20, 10, 40, 40);
                    g.DrawEllipse(new Pen(Color.Violet), rec);
                        break;
                case 3:
                    Rectangle rec2 = new Rectangle(panel1.Width / 2 - 20, 10, 40, 40);
                    g.DrawEllipse(new Pen(Color.Violet), rec2);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 50, panel1.Width / 2, 120);
                    break;
                case 2:
                    Rectangle rec3 = new Rectangle(panel1.Width / 2 - 20, 10, 40, 40);
                    g.DrawEllipse(new Pen(Color.Violet), rec3);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 50, panel1.Width / 2, 120);
                    
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 - 30, 90);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 + 30, 90);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 - 30, 140);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 + 30, 140);

                    break;
                case 1:
                    Rectangle rec4 = new Rectangle(panel1.Width / 2 - 20, 10, 40, 40);
                    g.DrawEllipse(new Pen(Color.Violet), rec4);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 50, panel1.Width / 2, 120);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 - 30, 90);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 + 30, 90);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 - 30, 140);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 + 30, 140);

                    g.DrawLine(new Pen(Color.Gray), 120, 5, 120, 180);
                    g.DrawLine(new Pen(Color.Gray), 120, 5, panel1.Width / 2, 5);
                    break;
                case 0:
                    Rectangle rec5 = new Rectangle(panel1.Width / 2 - 20, 10, 40, 40);
                    g.DrawEllipse(new Pen(Color.Violet), rec5);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 50, panel1.Width / 2, 120);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 - 30, 90);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 70, panel1.Width / 2 + 30, 90);

                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 - 30, 140);
                    g.DrawLine(new Pen(Color.Violet), panel1.Width / 2, 120, panel1.Width / 2 + 30, 140);

                    g.DrawLine(new Pen(Color.Gray), 120, 5, 120, 180);
                    g.DrawLine(new Pen(Color.Gray), 120, 5, panel1.Width / 2, 5);

                    g.DrawLine(new Pen(Color.Gray), 120, 5, panel1.Width / 2, 50);
                    g.DrawString("GAME OVER", new Font(FontFamily.GenericSansSerif,20,FontStyle.Bold), Brushes.Red, panel1.Width / 2 - 60, 60);
                    break;
            }
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoresForm sf = new ScoresForm();
            sf.ShowDialog();
        }
    }
}
