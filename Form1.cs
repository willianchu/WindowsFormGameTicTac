using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormGameTicTac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int player = 2; // even X turn; odd = 0 turn
        public int turns = 0;
        public int s1 = 0;
        public int s2 = 0;
        public int sd = 0;

        private void buttonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text == "")
            {
                if (player % 2 == 0)
                {
                    button.Text = "X";
                    player++;
                    turns++;
                }
                else
                {
                    button.Text = "O";
                    player++;
                    turns++;
                }
                if(CheckDraw() == true)
                {
                    MessageBox.Show("Tie Game!");
                    sd++;
                    NewGame();
                }
                if(CheckWinner()==true)
                {
                    if(button.Text == "X")
                    {
                        MessageBox.Show("X Wins!");
                        s1++;
                    }
                    else
                    {
                        MessageBox.Show("O Wins!");
                        s2++;
                    }
                    NewGame();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XWin.Text = "X: " + s1;
            OWin.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;

        }

        private void EButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        void NewGame()
        {
            player = 2; // even X turn; odd = 0 turn
            turns = 0;
            A00.Text = A01.Text = A02.Text =
            A10.Text = A11.Text = A12.Text =
            A20.Text = A21.Text = A22.Text = "";
            XWin.Text = "X: " + s1;
            OWin.Text = "O: " + s2;
            Draws.Text = "Draws: " + sd;


        }

        private void NGButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
        bool CheckDraw()
        {
            if ((turns == 9) && CheckWinner()==false)
            { return true; }
            else
            { return false; }
        }
        bool CheckWinner()
        {
            //horizontal Checks
            if((A00.Text == A01.Text) && (A01.Text == A02.Text) && (A00.Text !=""))
            { return true; }
            else if((A10.Text == A11.Text) && (A11.Text == A12.Text) && (A10.Text != ""))
            { return true; }
            else if((A20.Text == A21.Text) && (A21.Text == A22.Text) && (A20.Text != ""))
            { return true; }
            //Vertical Checks
            if ((A00.Text == A10.Text) && (A10.Text == A20.Text) && (A00.Text != ""))
            { return true; }
            else if ((A01.Text == A11.Text) && (A11.Text == A21.Text) && (A01.Text != ""))
            { return true; }
            else if ((A02.Text == A12.Text) && (A12.Text == A22.Text) && (A02.Text != ""))
            { return true; }
            // Diagonal Checks
            if((A00.Text == A11.Text) && (A11.Text == A22.Text) && (A00.Text != ""))
            { return true; }
            else if((A02.Text == A11.Text) && (A11.Text == A20.Text) && (A02.Text != ""))
            { return true; }
            else
            { return false; }
        }

        private void RButton_Click(object sender, EventArgs e)
        {
            s1 = s2 = sd = 0;
            NewGame();
        }
    }
}