using BowlingGame.bowling.DAO;
using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using BowlingGame.bowling.view;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BowlingGame
{
    public partial class Bowling : Form
    {
        private Bowler bowler;
        private BowlingGameModel bowlingGame;
        private BowlingDAO bowlingDAO;
        private int interval;

        public Bowling()
        {
            InitializeComponent();
        }

        private void Bowling_Load(object sender, EventArgs e)
        {
            this.bowler = new Bowler();
            this.bowlingGame = new BowlingGameModel();
            this.bowlingGame.Frame = new Frame();
            this.bowlingDAO = new BowlingDAO();
            this.bowlingDAO.databaseProperties(Constants.DB_PROPERTIES);

            this.timerAnimateBowling.Start();
            foreach (DataRow bowlerName in this.bowlingDAO.SearchBowlers(Constants.ONE).Rows)
            {
                this.bowler.Name = bowlerName[Constants.BOWLER_NAME].ToString();
            }

            if(null == this.bowler.Name)
            {
                // Do nothing
            }
            else
            {
                this.lblWelcome.Text = Constants.WELCOME_MESSAGE + this.bowler.Name + Constants.EXCLAMATION;
            }

            MessageBox.Show(Constants.GAME_START_MESSAGE, Constants.ATTENTION_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        // Scoring Methods - START

        private void OpenFrameFirstBall(bool firstframe, Label previouslblScoreFrame, Label lblScoreFrame, TextBox txtFrame, Button btnFrame)
        {
            if (firstframe)
            {
                this.lblScoreFrame1.Text = this.txtFrame1Ball1st.Text;
                this.btnFrame1FirstBall.Enabled = false;
                this.txtFrame1Ball1st.Enabled = false;
                this.btnFrame1FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
            }

            else
            {
                int addedScore = int.Parse(previouslblScoreFrame.Text) + int.Parse(txtFrame.Text);
                lblScoreFrame.Text = addedScore.ToString();
                btnFrame.Enabled = false;
                btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
                txtFrame.Enabled = false;
            }
        }

        private void StrikeFirstBall(bool firstframe, Label previouslblScoreFrame, Label lblScoreFrame, TextBox txtFrame, Button btnFrame)
        {
            if (firstframe)
            {
                this.lblScoreFrame1.Text = Constants.STRIKE_VALUE.ToString();
                this.txtFrame1Ball1st.Enabled = false;
                this.btnFrame1FirstBall.Enabled = false;
                this.btnFrame1FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
            }
            else
            {
                int striked = Constants.STRIKE_VALUE + int.Parse(previouslblScoreFrame.Text);
                lblScoreFrame.Text = striked.ToString();
                txtFrame.Enabled = false;
                btnFrame.Enabled = false;
                btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
            }

        }

        private void SecondBallScore(bool firstframe, Label lblScoreFrame, TextBox txtPreviousFrame, TextBox txtFrame, TextBox txtFrameSpare, Button btnFrame)
        {
            // first frame second shot - START
            if (firstframe)
            {
                // Strike/Spare - START
                if (txtFrame.Text.Equals(Constants.SPARE) || txtPreviousFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                {
                    // Strike Second Shot - START
                    if (txtFrameSpare.Enabled == false && txtPreviousFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                    {
                        txtFrameSpare.Enabled = true;
                        // Spare Score
                        int frame1sparescore = 0;
                        if (txtFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                        {
                            frame1sparescore = 20;
                        }
                        else
                        {
                            frame1sparescore = Constants.STRIKE_VALUE + int.Parse(txtFrame.Text);
                        }
                        
                        lblScoreFrame.Text = frame1sparescore.ToString();
                    }
                    // Strike Second Shot - END

                    // Spare Shot - START
                    else if (txtFrameSpare.Enabled == false)
                    {
                        txtFrameSpare.Enabled = true;
                        int allpinsdown = Constants.STRIKE_VALUE - int.Parse(lblScoreFrame.Text);
                        int frame1sparescore = allpinsdown + int.Parse(lblScoreFrame.Text);
                        lblScoreFrame.Text = frame1sparescore.ToString();
                    }
                    else
                    {
                        if(txtFrameSpare.Text.Equals(Constants.ZERO) ||
                            txtFrameSpare.Text.Equals(Constants.ONE) ||
                            txtFrameSpare.Text.Equals(Constants.TWO) ||
                            txtFrameSpare.Text.Equals(Constants.THREE) ||
                            txtFrameSpare.Text.Equals(Constants.FOUR) ||
                            txtFrameSpare.Text.Equals(Constants.FIVE) ||
                            txtFrameSpare.Text.Equals(Constants.SIX) ||
                            txtFrameSpare.Text.Equals(Constants.SEVEN) ||
                            txtFrameSpare.Text.Equals(Constants.EIGHT) ||
                            txtFrameSpare.Text.Equals(Constants.NINE) ||
                            txtFrameSpare.Text.Equals(Constants.SPARE) ||
                            txtFrameSpare.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                        {
                            int frame1sparescore = 0;
                            if (txtFrameSpare.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase) ||
                                txtFrameSpare.Text.Equals(Constants.SPARE))
                            {
                                frame1sparescore = Constants.STRIKE_VALUE + int.Parse(lblScoreFrame.Text);
                               
                            }
                            else
                            {
                                frame1sparescore = int.Parse(txtFrameSpare.Text) + int.Parse(lblScoreFrame.Text);
                            }
                            
                            lblScoreFrame.Text = frame1sparescore.ToString();
                            btnFrame.Enabled = false;
                            txtFrame.Enabled = false;
                            txtFrameSpare.Enabled = false;
                            btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
                        }
                        
                        else
                        {
                            MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    // Spare Shot - END

                }
                // Strike/Spare - END

                else
                { 
                    int frame1score = int.Parse(lblScoreFrame.Text);
                    int frame1totalscore = frame1score + int.Parse(txtFrame.Text);
                    lblScoreFrame.Text = frame1totalscore.ToString();
                    btnFrame.Enabled = false;
                    btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
                    txtFrame.Enabled = false;
                }
            }
            // first frame second shot - END
            
            else
            {
                // Strike/Spare - START (2nd-10th frame)
                if (txtFrame.Text.Equals(Constants.SPARE) || txtPreviousFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                {
                    if (txtFrameSpare.Enabled == false && txtPreviousFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                    {
                        txtFrameSpare.Enabled = true;
                        int frame1strikescore = 0;
                        if (txtFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase) ||
                            txtFrame.Text.Equals(Constants.SPARE))
                        {
                            frame1strikescore = int.Parse(lblScoreFrame.Text) + Constants.STRIKE_VALUE;
                        }
                        else
                        {
                            frame1strikescore = int.Parse(lblScoreFrame.Text) + int.Parse(txtFrame.Text);
                        }

                        lblScoreFrame.Text = frame1strikescore.ToString();
                    }
                    else if (txtFrameSpare.Enabled == false)
                    {
                        txtFrameSpare.Enabled = true;
                        int frame1sparescore = int.Parse(lblScoreFrame.Text) + (Constants.STRIKE_VALUE - int.Parse(txtPreviousFrame.Text));
                        lblScoreFrame.Text = frame1sparescore.ToString();
                    }
                    else
                    {
                        if (txtFrameSpare.Text.Equals(Constants.ZERO) ||
                           txtFrameSpare.Text.Equals(Constants.ONE) ||
                           txtFrameSpare.Text.Equals(Constants.TWO) ||
                           txtFrameSpare.Text.Equals(Constants.THREE) ||
                           txtFrameSpare.Text.Equals(Constants.FOUR) ||
                           txtFrameSpare.Text.Equals(Constants.FIVE) ||
                           txtFrameSpare.Text.Equals(Constants.SIX) ||
                           txtFrameSpare.Text.Equals(Constants.SEVEN) ||
                           txtFrameSpare.Text.Equals(Constants.EIGHT) ||
                           txtFrameSpare.Text.Equals(Constants.NINE) ||
                           txtFrameSpare.Text.Equals(Constants.SPARE) ||
                           txtFrameSpare.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                        {
                            int frame1sparescore = 0;
                            if (txtFrameSpare.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase) )
                            {
                                frame1sparescore = Constants.STRIKE_VALUE + int.Parse(lblScoreFrame.Text);
                            }
                            else if (txtFrameSpare.Text.Equals(Constants.SPARE))
                            {
                                frame1sparescore = int.Parse(lblScoreFrame.Text) + (Constants.STRIKE_VALUE - int.Parse(txtFrame.Text));
                            }
                            else
                            {
                                frame1sparescore = int.Parse(txtFrameSpare.Text) + int.Parse(lblScoreFrame.Text);
                            }
                            lblScoreFrame.Text = frame1sparescore.ToString();
                            btnFrame.Enabled = false;
                            txtFrame.Enabled = false;
                            txtFrameSpare.Enabled = false;
                            btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
                        }
                        else
                        {
                            MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                }
                // Strike/Spare - END (2nd-10th frame)

                // Open Frame - START
                else
                {
                    int frame1score = int.Parse(lblScoreFrame.Text);
                    int frame1totalscore = 0;
                    if (txtFrame.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(Constants.STRIKE_UNAVAILABLE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        frame1totalscore = frame1score + int.Parse(txtFrame.Text);
                        lblScoreFrame.Text = frame1totalscore.ToString();
                        btnFrame.Enabled = false;
                        btnFrame.BackgroundImage = ((System.Drawing.Image)(Properties.Resources._checked));
                        txtFrame.Enabled = false;
                    }
                 // Open Frame - END

                }
            }
        }
        // Scoring Methods - END

        // Play Button Methods - START
        private void NewGame()
        {
            MessageBox.Show(Constants.GAME_START_MESSAGE, Constants.ATTENTION_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.txtFrame1Ball1st.Clear();
            this.txtFrame2Ball1st.Clear();
            this.txtFrame3Ball1st.Clear();
            this.txtFrame4Ball1st.Clear();
            this.txtFrame5Ball1st.Clear();
            this.txtFrame6Ball1st.Clear();
            this.txtFrame7Ball1st.Clear();
            this.txtFrame8Ball1st.Clear();
            this.txtFrame9Ball1st.Clear();
            this.txtFrame10Ball1st.Clear();
            this.txtFrame1Ball2nd.Clear();
            this.txtFrame2Ball2nd.Clear();
            this.txtFrame3Ball2nd.Clear();
            this.txtFrame4Ball2nd.Clear();
            this.txtFrame5Ball2nd.Clear();
            this.txtFrame6Ball2nd.Clear();
            this.txtFrame7Ball2nd.Clear();
            this.txtFrame8Ball2nd.Clear();
            this.txtFrame9Ball2nd.Clear();
            this.txtFrame10Ball2nd.Clear();

            this.txtFrame1Ball1st.Enabled = true;
            this.txtFrame2Ball1st.Enabled = true;
            this.txtFrame3Ball1st.Enabled = true;
            this.txtFrame4Ball1st.Enabled = true;
            this.txtFrame5Ball1st.Enabled = true;
            this.txtFrame6Ball1st.Enabled = true;
            this.txtFrame7Ball1st.Enabled = true;
            this.txtFrame8Ball1st.Enabled = true;
            this.txtFrame9Ball1st.Enabled = true;
            this.txtFrame10Ball1st.Enabled = true;
            this.txtFrame1Ball2nd.Enabled = true;
            this.txtFrame2Ball2nd.Enabled = true;
            this.txtFrame3Ball2nd.Enabled = true;
            this.txtFrame4Ball2nd.Enabled = true;
            this.txtFrame5Ball2nd.Enabled = true;
            this.txtFrame6Ball2nd.Enabled = true;
            this.txtFrame7Ball2nd.Enabled = true;
            this.txtFrame8Ball2nd.Enabled = true;
            this.txtFrame9Ball2nd.Enabled = true;
            this.txtFrame10Ball2nd.Enabled = true;

            this.txtFrame1Spare.Clear();
            this.txtFrame2Spare.Clear();
            this.txtFrame3Spare.Clear();
            this.txtFrame4Spare.Clear();
            this.txtFrame5Spare.Clear();
            this.txtFrame6Spare.Clear();
            this.txtFrame7Spare.Clear();
            this.txtFrame8Spare.Clear();
            this.txtFrame9Spare.Clear();
            this.txtFrame10Spare.Clear();

            this.txtFrame1Spare.Enabled = false;
            this.txtFrame2Spare.Enabled = false;
            this.txtFrame3Spare.Enabled = false;
            this.txtFrame4Spare.Enabled = false;
            this.txtFrame5Spare.Enabled = false;
            this.txtFrame6Spare.Enabled = false;
            this.txtFrame7Spare.Enabled = false;
            this.txtFrame8Spare.Enabled = false;
            this.txtFrame9Spare.Enabled = false;
            this.txtFrame10Spare.Enabled = false;

            this.btnFrame1FirstBall.Enabled = true;
            this.btnFrame1FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame2FirstBall.Enabled = true;
            this.btnFrame2FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame3FirstBall.Enabled = true;
            this.btnFrame3FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame4FirstBall.Enabled = true;
            this.btnFrame4FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame5FirstBall.Enabled = true;
            this.btnFrame5FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame6FirstBall.Enabled = true;
            this.btnFrame6FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame7FirstBall.Enabled = true;
            this.btnFrame7FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame8FirstBall.Enabled = true;
            this.btnFrame8FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame9FirstBall.Enabled = true;
            this.btnFrame9FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame10FirstBall.Enabled = true;
            this.btnFrame10FirstBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));

            this.btnFrame1SecondBall.Enabled = true;
            this.btnFrame1SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame2SecondBall.Enabled = true;
            this.btnFrame2SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame3SecondBall.Enabled = true;
            this.btnFrame3SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame4SecondBall.Enabled = true;
            this.btnFrame4SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame5SecondBall.Enabled = true;
            this.btnFrame5SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame6SecondBall.Enabled = true;
            this.btnFrame6SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame7SecondBall.Enabled = true;
            this.btnFrame7SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame8SecondBall.Enabled = true;
            this.btnFrame8SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame9SecondBall.Enabled = true;
            this.btnFrame9SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));
            this.btnFrame10SecondBall.Enabled = true;
            this.btnFrame10SecondBall.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Bowling));

            this.lblScoreFrame1.Text = Constants.HYPHEN;
            this.lblScoreFrame2.Text = Constants.HYPHEN;
            this.lblScoreFrame3.Text = Constants.HYPHEN;
            this.lblScoreFrame4.Text = Constants.HYPHEN;
            this.lblScoreFrame5.Text = Constants.HYPHEN;
            this.lblScoreFrame6.Text = Constants.HYPHEN;
            this.lblScoreFrame7.Text = Constants.HYPHEN;
            this.lblScoreFrame8.Text = Constants.HYPHEN;
            this.lblScoreFrame9.Text = Constants.HYPHEN;
            this.lblScoreFrame10.Text = Constants.HYPHEN;
        }
        
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Constants.NEW_GAME_CONFIRMATION, Constants.CONFIRMATION_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Yes))
            {
                this.NewGame();
            }
            else
            {
                // Do Nothing
            }
        }


        private void btnFrame1FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame1Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(true, this.lblScoreFrame1, this.lblScoreFrame1, this.txtFrame1Ball1st, this.btnFrame1FirstBall);
            }
            else if (this.txtFrame1Ball1st.Text.Equals(Constants.ZERO) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.ONE) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.TWO) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.THREE) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.FOUR) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.FIVE) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.SIX) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.SEVEN) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.EIGHT) ||
                this.txtFrame1Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(true, this.lblScoreFrame1, this.lblScoreFrame1, this.txtFrame1Ball1st, this.btnFrame1FirstBall);
            }
            
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame1SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame1Ball2nd.Text.Equals(Constants.ZERO) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.ONE) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.TWO) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.THREE) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.FOUR) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.FIVE) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.SIX) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.SEVEN) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.EIGHT) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.NINE) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.SPARE) ||
              this.txtFrame1Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))

            {
                this.SecondBallScore(true, this.lblScoreFrame1, this.txtFrame1Ball1st, this.txtFrame1Ball2nd, this.txtFrame1Spare, this.btnFrame1SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnFrame2FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame2Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame1, this.lblScoreFrame2, this.txtFrame2Ball1st, this.btnFrame2FirstBall);
            }

            else if (this.txtFrame2Ball1st.Text.Equals(Constants.ZERO) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame2Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame1, this.lblScoreFrame2, this.txtFrame2Ball1st, this.btnFrame2FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame2SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame2Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame2Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame2, this.txtFrame2Ball1st, this.txtFrame2Ball2nd, this.txtFrame2Spare, this.btnFrame2SecondBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame3FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame3Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame2, this.lblScoreFrame3, this.txtFrame3Ball1st, this.btnFrame3FirstBall);
            }

            else if (this.txtFrame3Ball1st.Text.Equals(Constants.ZERO) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame3Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame2, this.lblScoreFrame3, this.txtFrame3Ball1st, this.btnFrame3FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnFrame3SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame3Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame3Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame3, this.txtFrame3Ball1st, this.txtFrame3Ball2nd, this.txtFrame3Spare, this.btnFrame3SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame4FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame4Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame3, this.lblScoreFrame4, this.txtFrame4Ball1st, this.btnFrame4FirstBall);
            }

            else if (this.txtFrame4Ball1st.Text.Equals(Constants.ZERO) ||
                this.txtFrame4Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame4Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame3, this.lblScoreFrame4, this.txtFrame4Ball1st, this.btnFrame4FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame4SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame4Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame4Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame4, this.txtFrame4Ball1st, this.txtFrame4Ball2nd, this.txtFrame4Spare, this.btnFrame4SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame5FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame5Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame4, this.lblScoreFrame5, this.txtFrame5Ball1st, this.btnFrame5FirstBall);
            }

            else if (this.txtFrame5Ball1st.Text.Equals(Constants.ZERO) ||
                this.txtFrame5Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame5Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame4, this.lblScoreFrame5, this.txtFrame5Ball1st, this.btnFrame5FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame5SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame5Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame5Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame5, this.txtFrame5Ball1st, this.txtFrame5Ball2nd, this.txtFrame5Spare, this.btnFrame5SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame6FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame6Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame5, this.lblScoreFrame6, this.txtFrame6Ball1st, this.btnFrame6FirstBall);
            }

            else if (this.txtFrame6Ball1st.Text.Equals(Constants.ZERO) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame6Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame5, this.lblScoreFrame6, this.txtFrame6Ball1st, this.btnFrame6FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame6SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame6Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame6Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame6, this.txtFrame6Ball1st, this.txtFrame6Ball2nd, this.txtFrame6Spare, this.btnFrame6SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame7FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame7Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame6, this.lblScoreFrame7, this.txtFrame7Ball1st, this.btnFrame7FirstBall);
            }

            else if (this.txtFrame7Ball1st.Text.Equals(Constants.ZERO) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame7Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame6, this.lblScoreFrame7, this.txtFrame7Ball1st, this.btnFrame7FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame7SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame7Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase) ||
             this.txtFrame7Ball2nd.Text.Equals(Constants.SPARE))
            {
                this.SecondBallScore(false, this.lblScoreFrame7, this.txtFrame7Ball1st, this.txtFrame7Ball2nd, this.txtFrame7Spare, this.btnFrame7SecondBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame8FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame8Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame7, this.lblScoreFrame8, this.txtFrame8Ball1st, this.btnFrame8FirstBall);
            }

            else if (this.txtFrame8Ball1st.Text.Equals(Constants.ZERO) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame8Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame7, this.lblScoreFrame8, this.txtFrame8Ball1st, this.btnFrame8FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame8SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame8Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame8Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame8, this.txtFrame8Ball1st, this.txtFrame8Ball2nd, this.txtFrame8Spare, this.btnFrame8SecondBall);
            }
            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame9FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame9Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame8, this.lblScoreFrame9, this.txtFrame9Ball1st, this.btnFrame9FirstBall);
            }

            else if (this.txtFrame9Ball1st.Text.Equals(Constants.ZERO) ||
                this.txtFrame9Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame9Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame8, this.lblScoreFrame9, this.txtFrame9Ball1st, this.btnFrame9FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame9SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame9Ball2nd.Text.Equals(Constants.ZERO) ||
                this.txtFrame9Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame9Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame9, this.txtFrame9Ball1st, this.txtFrame9Ball2nd, this.txtFrame9Spare, this.btnFrame9SecondBall);
            }
            else
            {
               MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame10FirstBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame10Ball1st.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.StrikeFirstBall(false, this.lblScoreFrame9, this.lblScoreFrame10, this.txtFrame10Ball1st, this.btnFrame10FirstBall);
            }

            else if (this.txtFrame10Ball1st.Text.Equals(Constants.ZERO) ||
                this.txtFrame10Ball1st.Text.Equals(Constants.ONE) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.TWO) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.THREE) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.FOUR) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.FIVE) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.SIX) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.SEVEN) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.EIGHT) ||
              this.txtFrame10Ball1st.Text.Equals(Constants.NINE))
            {
                this.OpenFrameFirstBall(false, this.lblScoreFrame9, this.lblScoreFrame10, this.txtFrame10Ball1st, this.btnFrame10FirstBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFrame10SecondBall_Click(object sender, EventArgs e)
        {
            if (this.txtFrame10Ball2nd.Text.Equals(Constants.ZERO) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.ONE) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.TWO) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.THREE) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.FOUR) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.FIVE) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.SIX) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.SEVEN) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.EIGHT) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.NINE) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.SPARE) ||
             this.txtFrame10Ball2nd.Text.Equals(Constants.STRIKE, StringComparison.OrdinalIgnoreCase))
            {
                this.SecondBallScore(false, this.lblScoreFrame10, this.txtFrame10Ball1st, this.txtFrame10Ball2nd, this.txtFrame10Spare, this.btnFrame10SecondBall);
            }

            else
            {
                MessageBox.Show(Constants.INPUT_CORRECT_VALUE_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerAnimateBowling_Tick(object sender, EventArgs e)
        {
            interval++;
            if(interval == 1)
            {
                this.picBowlingRoll.Show();
                this.picBowlingRoll2.Hide();
                this.picStrike.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pins));
                this.picStrike.ImageLocation = Constants.STRETCH;
            }
            else if (interval == 2)
            {
                this.picBowlingRoll.Hide();
                this.picBowlingRoll2.Show();
            }
            else if (interval == 3)
            {
                this.picBowlingRoll.Hide();
                this.picBowlingRoll2.Hide();
                this.picStrike.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Striked));
                this.picStrike.ImageLocation = Constants.STRETCH;
                interval = 0;
            }

        }

        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            this.SaveGame();
        }

        private void SaveGame()
        {
            // Sets game data - START
            this.bowlingGame.Frame.Frame_id = Constants.ONE;
            this.bowlingGame.Id = Constants.ONE;
            List<int> getHighestFrameScore = new List<int>();
            try
            {
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame1.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame2.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame3.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame4.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame5.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame6.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame7.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame8.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame9.Text));
                getHighestFrameScore.Add(int.Parse(this.lblScoreFrame10.Text));
            }
            catch (Exception)
            {
                // Do Nothing
            }

            this.bowlingGame.Frame.Pins_knocked_down = getHighestFrameScore[getHighestFrameScore.Count - 1];
            this.bowlingGame.Name = this.bowler.Name;
            // Sets game data - END

            // Saves the game - START
            this.bowlingDAO.SaveBowlingGame(this.bowlingGame);
            // Saves the game - END
        }

        // Play Button Methods - END

        // Menu Strips - START
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show(Constants.NEW_GAME_CONFIRMATION, Constants.CONFIRMATION_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr.Equals(DialogResult.Yes))
            {
                this.NewGame();
            }
            else
            {
                // Do Nothing
            }
        }

        private void playerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new BowlerInfo(this.bowler, this.bowlingDAO, this.lblWelcome).ShowDialog();
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Records(this.bowlingDAO, this.bowlingGame).ShowDialog();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Menu Strips - END
    }
}
