using BowlingGame.bowling.model;
using BowlingGame.bowling.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BowlingGame.bowling.DAO
{
    public class BowlingDAO
    {
        // Database commands
        public SqlDataAdapter sda;
        public SqlCommand sqlcmd;
        public DataTable dt;
        public SqlConnection con;

        // static for properties files
        private static string dbConnection;
        private static string dbInitialCatalog;
        private static string dbUserId;
        private static string dbPassword;
        private static string dbDataSource;
        
        // sets the database connection
        public void databaseProperties(string propertiesFile)
        {
            try
            {
                var data = new Dictionary<string, string>();
                foreach (var row in File.ReadAllLines(propertiesFile))
                data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                dbInitialCatalog = data[Constants.DB_INITIAL_CATALOG];
                dbUserId = data[Constants.DB_USER_ID];
                dbPassword = data[Constants.DB_PASSWORD];
                dbDataSource = data[Constants.DB_DATASOURCE];
                dbConnection = "Data source = " + dbDataSource + "; Initial catalog = " + dbInitialCatalog + "; User id = " + dbUserId + "; password = " + dbPassword;
                this.con = new SqlConnection(dbConnection);
            }
           catch(Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public BowlingDAO() { }

        // INSERT queries - START
        public void AddBowler(Bowler newbowler)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("INSERT INTO bowlers(bowler_name) " +
                    "VALUES ('" + newbowler.Name + "')", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
            }
        }

        public void SaveBowlingGame(BowlingGameModel bowlingGame)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("INSERT INTO bowling_games(bowler_name, pins_knocked_down) " +
                    "VALUES ('" + bowlingGame.Name + "','" + bowlingGame.Frame.Pins_knocked_down + "')", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
            }
        }
        // INSERT queries - END

        // SELECT queries - START
        public DataTable LoadBowlingGames()
        {
            try
            {
                this.dt = new DataTable();
                this.con.Open();
                this.sda = new SqlDataAdapter();
                this.sda.SelectCommand = new SqlCommand("SELECT * FROM bowling_games", this.con);
                this.sda.SelectCommand.ExecuteNonQuery();
                this.sda.Fill(this.dt);
                this.con.Close();
                return this.dt;
            }
            catch(Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return this.dt;
            }
            
        }

        public DataTable SearchBowlingGame(string idnum)
        {
            try
            {
                this.dt = new DataTable();
                this.con.Open();
                this.sda.SelectCommand = new SqlCommand("SELECT * FROM bowling WHERE bowling_game_id = '" + idnum + "'", this.con);
                this.sda.SelectCommand.ExecuteNonQuery();
                this.sda.Fill(this.dt);
                this.con.Close();
                return this.dt;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return this.dt;
            }

        }

        public DataTable LoadBowlers()
        {
            try
            {
                this.dt = new DataTable();
                this.con.Open();
                this.sda = new SqlDataAdapter();
                this.sda.SelectCommand = new SqlCommand("SELECT * FROM bowlers", this.con);
                this.sda.SelectCommand.ExecuteNonQuery();
                this.sda.Fill(this.dt);
                this.con.Close();
                return this.dt;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return this.dt;
            }
        }

        public DataTable SearchBowlers(string idnum)
        {
            try
            {
                this.dt = new DataTable();
                this.con.Open();
                this.sda = new SqlDataAdapter();
                this.sda.SelectCommand = new SqlCommand("SELECT * FROM bowlers WHERE bowler_id = " + idnum, this.con);
                this.sda.SelectCommand.ExecuteNonQuery();
                this.sda.Fill(this.dt);
                this.con.Close();
                return this.dt;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return this.dt;
            }
        }
        // SELECT queries - END

        // UPDATE queries - START
        public bool UpdateBowlingGame(BowlingGameModel bowlingGame)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("UPDATE bowling_games SET bowler_name='" + bowlingGame.Name + "', pins_knocked_down='" + bowlingGame.Frame.Pins_knocked_down + "' WHERE bowling_game_id = '" + bowlingGame.Id + "'", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return false;
            }
        }

        public bool UpdateBowler(Bowler bowler)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("UPDATE bowlers SET bowler_name='" + bowler.Name + "' WHERE bowler_id='" + bowler.Id + "'", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return false;
            }
        }
        // UPDATE queries - END

        // DELETE queries- START
        public bool DeleteBowler(Bowler bowler)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("DELETE FROM bowlers WHERE bowler_id='" + bowler.Id + "'", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
                return false;
            }
        }

        public void DeleteBowlingGame(string bowlingGameid)
        {
            try
            {
                this.con.Open();
                this.sqlcmd = new SqlCommand("DELETE FROM bowling_games WHERE bowling_game_id='" + bowlingGameid+"'", this.con);
                this.sqlcmd.ExecuteNonQuery();
                this.con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(Constants.DB_MSG_ERROR, Constants.ERROR_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.con.Close();
            }
        }
        // DELETE queries - END

    }
}
