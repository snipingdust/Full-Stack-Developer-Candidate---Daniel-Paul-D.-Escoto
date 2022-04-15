using BowlingGame.bowling.DAO;
using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingGame.bowling.view
{
    public partial class Records : Form
    {
        private BowlingDAO bowlingDAO;
        private BowlingGameModel bowlingGame;

        public Records(BowlingDAO bowlingDAO, BowlingGameModel bowlingGame)
        {
            InitializeComponent();
            this.bowlingDAO = bowlingDAO;
            this.bowlingGame = bowlingGame;
        }

        private void Records_Load(object sender, EventArgs e)
        {
            this.LoadRecordsList();
        }

        private void LoadRecordsList()
        {
            this.dgvBowlingGames.DataSource = this.bowlingDAO.LoadBowlingGames();
            this.dgvBowlingGames.Columns[0].HeaderText = Constants.GAME_ID;
            this.dgvBowlingGames.Columns[1].HeaderText = Constants.BOWLER;
            this.dgvBowlingGames.Columns[2].HeaderText = Constants.SCORE;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in this.dgvBowlingGames.Rows)
            {
                int rowIndex = rw.Index;
                if (dgvBowlingGames.Rows[rowIndex].Selected == true)
                {
                    this.bowlingGame.Id = rw.Cells[0].Value.ToString() ?? String.Empty;
                    this.bowlingGame.Name = rw.Cells[1].Value.ToString() ?? String.Empty;
                    this.bowlingGame.Frame.Pins_knocked_down = int.Parse(rw.Cells[2].Value.ToString() ?? String.Empty);
                }
            }
            new EditRecord(this.bowlingDAO, this.bowlingGame, this.dgvBowlingGames).ShowDialog();
            this.LoadRecordsList();
        }

        private void txtSearchGameID_TextChanged(object sender, EventArgs e)
        {
            string searchedItem = this.txtSearchGameID.Text;
            foreach (DataGridViewRow dgvrSearched in this.dgvBowlingGames.Rows)
            {
                if (!dgvrSearched.Cells[0].Value.ToString().Contains(searchedItem))
                {
                    if (!dgvrSearched.Selected)
                    {
                        CurrencyManager cm = (CurrencyManager)BindingContext[dgvBowlingGames.DataSource];
                        cm.SuspendBinding();
                        dgvrSearched.Visible = false;
                        cm.ResumeBinding();
                    }
                }

                else if (dgvrSearched.Cells[0].Value.ToString().Contains(searchedItem))
                {
                    dgvrSearched.Visible = true;
                }

                else if (searchedItem.Equals(string.Empty))
                {
                    dgvrSearched.Visible = true;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in this.dgvBowlingGames.Rows)
            {
                int rowIndex = rw.Index;
                if (dgvBowlingGames.Rows[rowIndex].Selected == true)
                {
                    this.bowlingGame.Id = rw.Cells[0].Value.ToString() ?? String.Empty;
                }
            }
            this.bowlingDAO.DeleteBowlingGame(this.bowlingGame.Id);
            this.LoadRecordsList();
        }
    }
}
