namespace BowlingGame.bowling.view
{
    partial class Records
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
            this.txtSearchGameID = new System.Windows.Forms.TextBox();
            this.dgvBowlingGames = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearchById = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBowlingGames)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearchGameID
            // 
            this.txtSearchGameID.Location = new System.Drawing.Point(58, 6);
            this.txtSearchGameID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchGameID.Name = "txtSearchGameID";
            this.txtSearchGameID.Size = new System.Drawing.Size(100, 25);
            this.txtSearchGameID.TabIndex = 0;
            this.txtSearchGameID.TextChanged += new System.EventHandler(this.txtSearchGameID_TextChanged);
            // 
            // dgvBowlingGames
            // 
            this.dgvBowlingGames.AllowUserToAddRows = false;
            this.dgvBowlingGames.AllowUserToDeleteRows = false;
            this.dgvBowlingGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBowlingGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBowlingGames.Location = new System.Drawing.Point(13, 45);
            this.dgvBowlingGames.Name = "dgvBowlingGames";
            this.dgvBowlingGames.ReadOnly = true;
            this.dgvBowlingGames.RowHeadersVisible = false;
            this.dgvBowlingGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBowlingGames.Size = new System.Drawing.Size(303, 94);
            this.dgvBowlingGames.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "By ID:";
            // 
            // btnEdit
            // 
            this.btnEdit.BackgroundImage = global::BowlingGame.Properties.Resources.edit1;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.Location = new System.Drawing.Point(12, 146);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(27, 27);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::BowlingGame.Properties.Resources.eraser;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Location = new System.Drawing.Point(45, 146);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(27, 27);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearchById
            // 
            this.btnSearchById.BackgroundImage = global::BowlingGame.Properties.Resources.search;
            this.btnSearchById.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearchById.Location = new System.Drawing.Point(159, 5);
            this.btnSearchById.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearchById.Name = "btnSearchById";
            this.btnSearchById.Size = new System.Drawing.Size(27, 27);
            this.btnSearchById.TabIndex = 1;
            this.btnSearchById.UseVisualStyleBackColor = true;
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 186);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBowlingGames);
            this.Controls.Add(this.btnSearchById);
            this.Controls.Add(this.txtSearchGameID);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Records";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Records";
            this.Load += new System.EventHandler(this.Records_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBowlingGames)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchGameID;
        private System.Windows.Forms.Button btnSearchById;
        private System.Windows.Forms.DataGridView dgvBowlingGames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}