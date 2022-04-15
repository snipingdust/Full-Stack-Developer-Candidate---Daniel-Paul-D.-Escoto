using BowlingGame.bowling.DAO;
using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using System;
using System.Windows.Forms;

namespace BowlingGame.bowling.view
{
    public partial class EditBowlerInfo : Form
    {
        private Bowler bowler;
        private BowlingDAO bowlingDAO;
        private DataGridView dgvPlayers;

        public EditBowlerInfo(Bowler bowler, BowlingDAO bowlingDAO, DataGridView dgvPlayers)
        {
            InitializeComponent();
            this.bowler = bowler;
            this.bowlingDAO = bowlingDAO;
            this.dgvPlayers = dgvPlayers;
            this.txtBowlerName.Text = this.bowler.Name;
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!this.txtBowlerName.Text.Equals(string.Empty))
            {
                this.bowler.Name = this.txtBowlerName.Text;
                this.bowlingDAO.UpdateBowler(this.bowler);
                this.dgvPlayers.DataSource = this.bowlingDAO.LoadBowlers();
                this.dgvPlayers.Columns[0].HeaderText = Constants.BOWLER_ID;
                this.dgvPlayers.Columns[1].HeaderText = Constants.BOWLER;
            }
            else
            {
                MessageBox.Show(Constants.PLEASE_INPUT_NAME_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
