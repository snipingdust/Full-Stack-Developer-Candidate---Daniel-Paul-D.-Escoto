using BowlingGame.bowling.DAO;
using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using System;
using System.Windows.Forms;

namespace BowlingGame.bowling.view
{
    public partial class EditRecord : Form
    {
        private BowlingDAO bowlingDAO;
        private BowlingGameModel bowlingGame;
        private DataGridView dgvBowlingGames;

        public EditRecord(BowlingDAO bowlingDAO, BowlingGameModel bowlingGame, DataGridView dgvBowlingGames)
        {
            InitializeComponent();
            this.bowlingDAO = bowlingDAO;
            this.bowlingGame = bowlingGame;
            this.dgvBowlingGames = dgvBowlingGames;
            this.txtBowlersName.Text = this.bowlingGame.Name;
            this.txtKnockedPins.Text = this.bowlingGame.Frame.Pins_knocked_down.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!this.txtBowlersName.Text.Equals(string.Empty) && !this.txtKnockedPins.Text.Equals(string.Empty))
            {
                this.bowlingGame.Name = this.txtBowlersName.Text;
                this.bowlingGame.Frame.Pins_knocked_down = int.Parse(this.txtKnockedPins.Text);
                this.bowlingDAO.UpdateBowlingGame(this.bowlingGame);
                this.dgvBowlingGames.Columns[0].HeaderText = Constants.GAME_ID;
                this.dgvBowlingGames.Columns[1].HeaderText = Constants.BOWLER;
                this.dgvBowlingGames.Columns[2].HeaderText = Constants.SCORE;
            }
            else
            {
                MessageBox.Show(Constants.PLEASE_INPUT_NAME_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
