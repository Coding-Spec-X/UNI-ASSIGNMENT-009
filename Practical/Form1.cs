using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical
{
    public partial class Form1 : Form
    {
        //The minimum number of hours to display
        const int MIN_HOURS = 1;
        //The maximum number of hours to display
        const int MAX_HOURS = 24;
        //The number of days to display
        const int NUM_DAYS = 7;

        public Form1()
        {
            InitializeComponent();
        }
        //METHOD TO DRAW SQUARE
        private void DrawSquare(int x, int y, int apptWidth, int apptHeight, Graphics paper, Color bColor, Color pColor)
        {
            SolidBrush br = new SolidBrush(bColor);
            paper.FillRectangle(br, x, y, apptWidth, apptHeight);
            Pen pen1 = new Pen(pColor, 2);
            paper.DrawRectangle(pen1, x, y, apptWidth, apptHeight);
        }
        //METHOD TO DRAW ROW
        private void DrawRow(int y, int sqWidth, int sqHeight, Graphics paper)
        {
            int x = 0;
            for (int day = 0; day <= NUM_DAYS; day++)
            {
                if (day >= 5)
                {
                    DrawSquare(x, y, sqWidth, sqHeight, paper, Color.LightGreen, Color.Black);
                }
                else
                {
                    DrawSquare(x, y, sqWidth, sqHeight, paper, Color.LightBlue, Color.Black);
                }
                x += sqWidth;
            }
        }
        private void drawPlannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //declare variable for textbox
            int hours = int.Parse(numHoursTextBox.Text);
            try
            {
                int xPos = 0;
                int yPos = 0;
                int squareWidth = pictureBoxDisplay.Width / NUM_DAYS;
                int squareHeight = pictureBoxDisplay.Height / hours;
                Graphics canvas = pictureBoxDisplay.CreateGraphics();

                //Display error message for incorrect values
                if (hours < MIN_HOURS || hours > MAX_HOURS)
                {
                    MessageBox.Show("Oops! Looks like you have entered in a wrong amount. Please enter a value between 2 and 24.");
                }
                else
                {
                    //set row and column length then allocate colors to specific columns
                    for (int row = 1; row <= hours; row++)
                    {
                        for (int col = 1; col <= NUM_DAYS; col++)
                        {
                            if (col == 6 && col == 7)
                            {
                                DrawSquare(xPos, yPos, squareWidth, squareHeight, canvas, Color.LightGreen, Color.Black);
                            }
                            else
                            {
                                DrawSquare(xPos, yPos, squareWidth, squareHeight, canvas, Color.LightBlue, Color.Black);
                            }
                            DrawRow(yPos, squareWidth, squareHeight, canvas);
                        }
                        yPos += squareHeight;
                        xPos = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBoxDisplay.Refresh();
        }
    }
}


