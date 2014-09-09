namespace Trivia
{
    partial class QuestionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.questionLabel = new System.Windows.Forms.Label();
            this.Team1Button = new System.Windows.Forms.Button();
            this.Team2Button = new System.Windows.Forms.Button();
            this.Team3Button = new System.Windows.Forms.Button();
            this.Team4Button = new System.Windows.Forms.Button();
            this.NoTeamButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.questionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Team1Button, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Team2Button, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Team3Button, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Team4Button, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.NoTeamButton, 4, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1575, 689);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // questionLabel
            // 
            this.questionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.questionLabel.BackColor = System.Drawing.Color.DodgerBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.questionLabel, 5);
            this.questionLabel.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.questionLabel.Location = new System.Drawing.Point(3, 0);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(1569, 637);
            this.questionLabel.TabIndex = 1;
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Team1Button
            // 
            this.Team1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Team1Button.AutoSize = true;
            this.Team1Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Team1Button.BackColor = System.Drawing.Color.Black;
            this.Team1Button.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.Team1Button.Location = new System.Drawing.Point(3, 640);
            this.Team1Button.Name = "Team1Button";
            this.Team1Button.Size = new System.Drawing.Size(309, 46);
            this.Team1Button.TabIndex = 0;
            this.Team1Button.Text = "0";
            this.Team1Button.UseVisualStyleBackColor = false;
            this.Team1Button.Click += new System.EventHandler(this.Team1Button_Click);
            // 
            // Team2Button
            // 
            this.Team2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Team2Button.AutoSize = true;
            this.Team2Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Team2Button.BackColor = System.Drawing.Color.Black;
            this.Team2Button.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.Team2Button.Location = new System.Drawing.Point(318, 640);
            this.Team2Button.Name = "Team2Button";
            this.Team2Button.Size = new System.Drawing.Size(309, 46);
            this.Team2Button.TabIndex = 0;
            this.Team2Button.Text = "0";
            this.Team2Button.UseVisualStyleBackColor = false;
            this.Team2Button.Click += new System.EventHandler(this.Team2Button_Click);
            // 
            // Team3Button
            // 
            this.Team3Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Team3Button.AutoSize = true;
            this.Team3Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Team3Button.BackColor = System.Drawing.Color.Black;
            this.Team3Button.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.Team3Button.Location = new System.Drawing.Point(633, 640);
            this.Team3Button.Name = "Team3Button";
            this.Team3Button.Size = new System.Drawing.Size(309, 46);
            this.Team3Button.TabIndex = 0;
            this.Team3Button.Text = "0";
            this.Team3Button.UseVisualStyleBackColor = false;
            this.Team3Button.Click += new System.EventHandler(this.Team3Button_Click);
            // 
            // Team4Button
            // 
            this.Team4Button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Team4Button.AutoSize = true;
            this.Team4Button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Team4Button.BackColor = System.Drawing.Color.Black;
            this.Team4Button.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.Team4Button.Location = new System.Drawing.Point(948, 640);
            this.Team4Button.Name = "Team4Button";
            this.Team4Button.Size = new System.Drawing.Size(309, 46);
            this.Team4Button.TabIndex = 0;
            this.Team4Button.Text = "0";
            this.Team4Button.UseVisualStyleBackColor = false;
            this.Team4Button.Click += new System.EventHandler(this.Team4Button_Click);
            // 
            // NoTeamButton
            // 
            this.NoTeamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoTeamButton.AutoSize = true;
            this.NoTeamButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NoTeamButton.BackColor = System.Drawing.Color.Black;
            this.NoTeamButton.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.NoTeamButton.Location = new System.Drawing.Point(1263, 640);
            this.NoTeamButton.Name = "NoTeamButton";
            this.NoTeamButton.Size = new System.Drawing.Size(309, 46);
            this.NoTeamButton.TabIndex = 0;
            this.NoTeamButton.Text = "Unanswered";
            this.NoTeamButton.UseVisualStyleBackColor = false;
            this.NoTeamButton.Click += new System.EventHandler(this.NoTeamButton_Click);
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1577, 705);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.Wheat;
            this.Name = "QuestionForm";
            this.Text = "CAMP Rehoboth Jeopardy!";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button Team1Button;
        private System.Windows.Forms.Button Team2Button;
        private System.Windows.Forms.Button Team3Button;
        private System.Windows.Forms.Button Team4Button;
        private System.Windows.Forms.Button NoTeamButton;
    }
}