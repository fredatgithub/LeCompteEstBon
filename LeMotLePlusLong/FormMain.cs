using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeMotLePlusLong
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            comboBoxNumberOfVoyelles.Items.Clear();
            for (int i = 1; i < 11; i++)
            {
                comboBoxNumberOfVoyelles.Items.Add(i);
            }
            
        }

        private void ButtonGenerateLetters_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = string.Empty;
            // generate 10 letters

        }

        private void ButtonNumbers_Click(object sender, EventArgs e)
        {
            // find a number from 101 to 999 from 6 numbers
            // les nombres de 1 à 10 présents en double exemplaire et les nombres 25, 50, 75 et 100 présents en un seul exemplaire. Sont alors tirées 6 valeurs.
            List<int> availableNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 25, 50, 75, 100 }; 


        }
    }
}
