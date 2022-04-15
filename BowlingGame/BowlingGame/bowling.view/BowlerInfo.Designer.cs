namespace BowlingGame.bowling.view
{
    partial class BowlerInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BowlerInfo));
            this.txtBowlerName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditBowler = new System.Windows.Forms.Button();
            this.dgvPlayers = new System.Windows.Forms.DataGridView();
            this.btnAddBowler = new System.Windows.Forms.Button();
            this.btnDeleteBowler = new System.Windows.Forms.Button();
            this.btnSearchById = new System.Windows.Forms.Button();
            this.txtSearchBowler = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBowlerName
            // 
            this.txtBowlerName.Location = new System.Drawing.Point(125, 4);
            this.txtBowlerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBowlerName.Name = "txtBowlerName";
            this.txtBowlerName.Size = new System.Drawing.Size(116, 25);
            this.txtBowlerName.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtBowlerName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(244, 38);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player Name";
            // 
            // btnEditBowler
            // 
            this.btnEditBowler.BackgroundImage = global::BowlingGame.Properties.Resources.edit1;
            this.btnEditBowler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditBowler.Location = new System.Drawing.Point(198, 220);
            this.btnEditBowler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEditBowler.Name = "btnEditBowler";
            this.btnEditBowler.Size = new System.Drawing.Size(27, 27);
            this.btnEditBowler.TabIndex = 3;
            this.btnEditBowler.UseVisualStyleBackColor = true;
            this.btnEditBowler.Click += new System.EventHandler(this.btnEditBowler_Click);
            // 
            // dgvPlayers
            // 
            this.dgvPlayers.AllowUserToAddRows = false;
            this.dgvPlayers.AllowUserToDeleteRows = false;
            this.dgvPlayers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlayers.Location = new System.Drawing.Point(14, 107);
            this.dgvPlayers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPlayers.Name = "dgvPlayers";
            this.dgvPlayers.ReadOnly = true;
            this.dgvPlayers.RowHeadersVisible = false;
            this.dgvPlayers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlayers.Size = new System.Drawing.Size(244, 105);
            this.dgvPlayers.TabIndex = 4;
            this.dgvPlayers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlayers_CellContentClick);
            // 
            // btnAddBowler
            // 
            this.btnAddBowler.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddBowler.BackgroundImage")));
            this.btnAddBowler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddBowler.Location = new System.Drawing.Point(231, 54);
            this.btnAddBowler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddBowler.Name = "btnAddBowler";
            this.btnAddBowler.Size = new System.Drawing.Size(27, 27);
            this.btnAddBowler.TabIndex = 2;
            this.btnAddBowler.UseVisualStyleBackColor = true;
            this.btnAddBowler.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // btnDeleteBowler
            // 
            this.btnDeleteBowler.BackgroundImage = global::BowlingGame.Properties.Resources.eraser;
            this.btnDeleteBowler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeleteBowler.Location = new System.Drawing.Point(231, 220);
            this.btnDeleteBowler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDeleteBowler.Name = "btnDeleteBowler";
            this.btnDeleteBowler.Size = new System.Drawing.Size(27, 27);
            this.btnDeleteBowler.TabIndex = 5;
            this.btnDeleteBowler.UseVisualStyleBackColor = true;
            this.btnDeleteBowler.Click += new System.EventHandler(this.btnDeleteBowler_Click);
            // 
            // btnSearchById
            // 
            this.btnSearchById.BackgroundImage = global::BowlingGame.Properties.Resources.search;
            this.btnSearchById.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchById.Location = new System.Drawing.Point(127, 73);
            this.btnSearchById.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchById.Name = "btnSearchById";
            this.btnSearchById.Size = new System.Drawing.Size(27, 27);
            this.btnSearchById.TabIndex = 7;
            this.btnSearchById.UseVisualStyleBackColor = true;
            // 
            // txtSearchBowler
            // 
            this.txtSearchBowler.Location = new System.Drawing.Point(12, 74);
            this.txtSearchBowler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBowler.Name = "txtSearchBowler";
            this.txtSearchBowler.Size = new System.Drawing.Size(115, 25);
            this.txtSearchBowler.TabIndex = 6;
            this.txtSearchBowler.TextChanged += new System.EventHandler(this.txtSearchBowler_TextChanged);
            // 
            // BowlerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 256);
            this.Controls.Add(this.btnSearchById);
            this.Controls.Add(this.txtSearchBowler);
            this.Controls.Add(this.btnDeleteBowler);
            this.Controls.Add(this.dgvPlayers);
            this.Controls.Add(this.btnEditBowler);
            this.Controls.Add(this.btnAddBowler);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BowlerInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BowlerInfo";
            this.Load += new System.EventHandler(this.BowlerInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBowlerName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBowler;
        private System.Windows.Forms.Button btnEditBowler;
        private System.Windows.Forms.DataGridView dgvPlayers;
        private System.Windows.Forms.Button btnDeleteBowler;
        private System.Windows.Forms.Button btnSearchById;
        private System.Windows.Forms.TextBox txtSearchBowler;
    }
}