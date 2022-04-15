using BowlingGame.bowling.DAO;
using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using System;
using System.Windows.Forms;

namespace BowlingGame.bowling.view
{
    public partial class BowlerInfo : Form
    {

        private Bowler bowler;
        private BowlingDAO bowlingDAO;
        private Label lblWelcome;

        public BowlerInfo(Bowler bowler, BowlingDAO bowlingDAO, Label lblWelcome)
        {
            InitializeComponent();
            this.bowlingDAO = bowlingDAO;
            this.bowler = bowler;
            this.lblWelcome = lblWelcome;
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            if (!this.txtBowlerName.Text.Equals(string.Empty))
            {
                this.bowler.Id = Constants.ONE;
                this.bowler.Name = this.txtBowlerName.Text;
                this.bowlingDAO.AddBowler(this.bowler);
                this.dgvPlayers.DataSource = this.bowlingDAO.LoadBowlers();
                this.lblWelcome.Text = Constants.WELCOME_MESSAGE + this.bowler.Name + Constants.EXCLAMATION;
            }
            else
            {
                MessageBox.Show(Constants.PLEASE_INPUT_NAME_MESSAGE, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditBowler_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in this.dgvPlayers.Rows)
            {
                int rowIndex = rw.Index;
                if (dgvPlayers.Rows[rowIndex].Selected == true)
                {
                    this.bowler.Id = rw.Cells[0].Value.ToString() ?? String.Empty;
                    this.bowler.Name = rw.Cells[1].Value.ToString() ?? String.Empty;
                }
            }
            new EditBowlerInfo(this.bowler, this.bowlingDAO, this.dgvPlayers).ShowDialog();
        }

        private void txtSearchBowler_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchedItem = this.txtSearchBowler.Text;
                foreach (DataGridViewRow dgvrSearched in this.dgvPlayers.Rows)
                {
                    if (!dgvrSearched.Cells[1].Value.ToString().Contains(searchedItem))
                    {
                        if (!dgvrSearched.Selected)
                        {
                            CurrencyManager cm = (CurrencyManager)BindingContext[dgvPlayers.DataSource];
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
            catch (Exception)
            {
                // Do Nothing
            }
        }

        private void BowlerInfo_Load(object sender, EventArgs e)
        {
            this.LoadList();
        }

        private void LoadList()
        {
            this.dgvPlayers.DataSource = this.bowlingDAO.LoadBowlers();
            this.dgvPlayers.Columns[0].HeaderText = Constants.BOWLER_ID;
            this.dgvPlayers.Columns[1].HeaderText = Constants.BOWLER;
        }

        private void btnDeleteBowler_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow rw in this.dgvPlayers.Rows)
            {
                int rowIndex = rw.Index;
                if (dgvPlayers.Rows[rowIndex].Selected == true)
                {
                    this.bowler.Id = rw.Cells[0].Value.ToString() ?? String.Empty;
                    this.bowler.Name = rw.Cells[1].Value.ToString() ?? String.Empty;
                }
            }
            this.bowlingDAO.DeleteBowler(this.bowler);
            this.LoadList();
        }

        private void dgvPlayers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow rw in this.dgvPlayers.Rows)
            {
                int rowIndex = rw.Index;
                if (dgvPlayers.Rows[rowIndex].Selected == true)
                {
                    this.bowler.Name = rw.Cells[1].Value.ToString() ?? String.Empty;
                }
            }
            this.lblWelcome.Text = Constants.WELCOME_MESSAGE + this.bowler.Name + Constants.EXCLAMATION;
        }
    }
}
