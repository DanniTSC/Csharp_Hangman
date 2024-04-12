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
using System.Collections;

namespace TutorialYt
{
    public partial class ScoresForm : Form
    {
        ArrayList scores = new ArrayList();
        public ScoresForm()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ScoresForm_Load(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("D:\\hangman.dat", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                            {
                            scores.Add(s);
                             }
                }
            }
            if(scores.Count > 0 ) 
            {
                foreach (string s in scores) {
                    ListViewItem itm = new ListViewItem(s.Split('|'));
                    listView1.Items.Add(itm);
                        }
            }
        }
    }
}
