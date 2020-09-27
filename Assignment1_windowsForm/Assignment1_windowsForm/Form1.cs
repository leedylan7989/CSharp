using HeonLee_Assignment1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeonLee_Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtKnightMoves.Visible = true;
            Chessboard.Visible = true;
            int runs = Convert.ToInt32(txtRuns.Text);
            string results = "";
            bool intelligent = radioIntelligent.Checked;
            Random rand = new Random();
            for (int j = 0; j < runs; j++)
            {
                Knight k;
                if (intelligent)
                {
                    k = new IntelligentKnight();
                }
                else
                {
                    k = new Knight();
                }
                ChessBoard cb = new ChessBoard(intelligent);
                //Assigning values using automatic properties
                k.cb = cb;
                k.X = rand.Next(0, 7);
                k.Y = rand.Next(0, 7);
                int i = 0;
                while (k.move())
                {
                    i += 1;
                    cb.setValue(k.X, k.Y, i);
                }
                if(j == 0)
                {
                    printChessBoard(k.cb);
                }
                
                results = results + "Trial " +(j+1) + ": The knight was able to successfully touch " + i + " squares.\n" ;
            }
            outputFile(intelligent, results);
            txtKnightMoves.Text = results;
        }
        private void printChessBoard(ChessBoard cb)
        {
            string chessboard = "";
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    chessboard += cb.getValue(i, j) + "      ";
                }
                chessboard += "\n";
            }
            Chessboard.Text = chessboard;
        }

        private void outputFile(bool intelligence, string str)
        {
            if (intelligence)
            {
                System.IO.File.WriteAllText("HeonLeeHeuristicsMethod.txt", str);
            } else
            {
                System.IO.File.WriteAllText("HeonLeeNonIntelligentMethod.txt", str);
            }
        }
    }
}
