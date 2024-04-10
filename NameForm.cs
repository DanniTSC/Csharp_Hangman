using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorialYt
{
    public partial class NameForm : Form
    {
        public NameForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void NameForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Game.game_player.Name;

           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Trim().Length > 0) 
            {
                Game.game_player.Name = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a name !", "error", MessageBoxButtons.OK);
            }
        }
    }
}
