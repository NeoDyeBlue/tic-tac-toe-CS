using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjTicTacToe
{
    public partial class Form1 : Form
    {
        private string turn = "P1";
        private bool win;
        private bool draw;
        private int inputCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            foreach (Control cntrl in this.BoxesPanel.Controls)
            {
                if (cntrl is Button)
                {
                    cntrl.Enabled = false;
                }
            }
            TurnMenuPanel.Visible = false;
            ChoiceBtnPanel2.Visible = false;

        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            foreach (Control cntrl in this.BoxesPanel.Controls)
            {
                if (cntrl is Button)
                {
                    cntrl.Text = "";
                    cntrl.Enabled = true;
                }
            }
            turn = "P1";
            TurnLabel.Text = turn + "\'s turn";
        }

        private void box_button_clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Text != "X" && button.Text != "O")
            {
                if (turn == "P1")
                {
                    button.Text = "X";
                    button.ForeColor = System.Drawing.Color.Red;
                    win = winner_check("X");
                    if (win)
                    {
                        TurnLabel.Text = turn + " wins!";
                    }
                    else
                    {
                        turn = "P2";
                        TurnLabel.Text = turn + "\'s turn";
                    }
                }
                else if (turn == "P2")
                {
                    button.Text = "O";
                    button.ForeColor = System.Drawing.Color.Green;
                    win = winner_check("O");
                    if (win)
                    {
                        TurnLabel.Text = turn + " wins!";
                    }
                    else
                    {
                        turn = "P1";
                        TurnLabel.Text = turn + "\'s turn";
                    }
                }

                draw = draw_check();

                if (draw)
                {
                    foreach (Control cntrl in this.BoxesPanel.Controls)
                    {
                        if (cntrl is Button)
                        {
                            cntrl.Enabled = false;
                        }
                    }

                    TurnLabel.Text = "  Draw!";
                }
            }
        }

        private bool winner_check(string text)
        {
            if (box_button_0.Text == text && box_button_1.Text == text && box_button_2.Text == text)
            {
                BoxesButtonDisabler();
                box_button_0.Enabled = true;
                box_button_1.Enabled = true;
                box_button_2.Enabled = true;

                return true;
            }

            else if (box_button_3.Text == text && box_button_4.Text == text && box_button_5.Text == text)
            {
                BoxesButtonDisabler();
                box_button_3.Enabled = true;
                box_button_4.Enabled = true;
                box_button_5.Enabled = true;

                return true;
            }
            else if (box_button_6.Text == text && box_button_7.Text == text && box_button_8.Text == text)
            {
                BoxesButtonDisabler();
                box_button_6.Enabled = true;
                box_button_7.Enabled = true;
                box_button_8.Enabled = true;

                return true;
            }
            else if (box_button_0.Text == text && box_button_4.Text == text && box_button_8.Text == text)
            {
                BoxesButtonDisabler();
                box_button_0.Enabled = true;
                box_button_4.Enabled = true;
                box_button_8.Enabled = true;

                return true;
            }
            else if (box_button_2.Text == text && box_button_4.Text == text && box_button_6.Text == text)
            {
                BoxesButtonDisabler();
                box_button_2.Enabled = true;
                box_button_4.Enabled = true;
                box_button_6.Enabled = true;

                return true;
            }
            else if (box_button_0.Text == text && box_button_3.Text == text && box_button_6.Text == text)
            {
                BoxesButtonDisabler();
                box_button_0.Enabled = true;
                box_button_3.Enabled = true;
                box_button_6.Enabled = true;

                return true;
            }
            else if (box_button_1.Text == text && box_button_4.Text == text && box_button_7.Text == text)
            {
                BoxesButtonDisabler();
                box_button_1.Enabled = true;
                box_button_4.Enabled = true;
                box_button_7.Enabled = true;

                return true;
            }
            else if (box_button_2.Text == text && box_button_5.Text == text && box_button_8.Text == text)
            {
                BoxesButtonDisabler();
                box_button_2.Enabled = true;
                box_button_5.Enabled = true;
                box_button_8.Enabled = true;

                return true;                
            }

            return false;
        }

        private bool draw_check()
        {
            inputCount = 0;

            foreach (Control cntrl in this.BoxesPanel.Controls)
            {
                if (cntrl is Button && cntrl.Text != "" && win != true)
                {
                    inputCount += 1;
                }
            }

            if (inputCount == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
         }

        private void BoxesButtonDisabler()
        {
            foreach (Control cntrl in this.BoxesPanel.Controls)
            {
                if (cntrl is Button)
                {
                    cntrl.Enabled = false;
                }
            }
        }


        private void OnePlyrBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Soon!","One Player");
        }

        private void TwoPlyrsBtn_Click(object sender, EventArgs e)
        {
            foreach (Control cntrl in this.BoxesPanel.Controls)
            {
                if (cntrl is Button)
                {
                    cntrl.Text = "";
                    cntrl.Enabled = true;
                }
            }
            turn = "P1";
            TurnLabel.Text = turn + "\'s turn";
            TurnMenuPanel.Visible = true;
            ChoiceBtnPanel2.Visible = false;
            ExpandBtn.Text = "◀";
            ExpandBtn.Location = new System.Drawing.Point(291, 21);
            TurnLabel.Location = new System.Drawing.Point(91, 21);
        }

        private void ExpandBtn_Click(object sender, EventArgs e)
        {
            if (ChoiceBtnPanel2.Visible == false)
            {
                ChoiceBtnPanel2.Visible = true;
                ExpandBtn.Text = "▶";
                ExpandBtn.Location = new System.Drawing.Point(174, 21);
                TurnLabel.Location = new System.Drawing.Point(21,21);
            }
            else if (ChoiceBtnPanel2.Visible == true)
            {
                ChoiceBtnPanel2.Visible = false;
                ExpandBtn.Text = "◀";
                ExpandBtn.Location = new System.Drawing.Point(291, 21);
                TurnLabel.Location = new System.Drawing.Point(91, 21);
            }
        }
    }
}
