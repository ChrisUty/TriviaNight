using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TriviaLib;
using System.Windows.Forms;

namespace Trivia
{
    /// <summary>
    /// A QuestionBoardFooter that keeps score for four Teams.
    /// TODO: Variable number of teams.
    /// </summary>
    class Scoreboard : QuestionBoardFooter
    {
        Label team1Score;
        Label team2Score;
        Label team3Score;
        Label team4Score;

        #region Constructor & Initialize

        /// <summary>
        /// Constructor.
        /// </summary>
        public Scoreboard()
        {
            InitializeComponent();
        }

        public void InitializeComponent()
        {
            team1Score = new Label();
            team2Score = new Label();
            team3Score = new Label();
            team4Score = new Label();

            // 
            // team1Score
            // 
            this.team1Score.AutoSize = true;
            this.team1Score.BackColor = System.Drawing.Color.Black;
            this.team1Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.team1Score.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.team1Score.ForeColor = System.Drawing.Color.White;
            this.team1Score.Location = new System.Drawing.Point(3, 0);
            this.team1Score.Name = "team1Score";
            this.team1Score.Size = new System.Drawing.Size(384, 72);
            this.team1Score.TabIndex = 0;
            this.team1Score.Text = "0";
            this.team1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // team2Score
            // 
            this.team2Score.AutoSize = true;
            this.team2Score.BackColor = System.Drawing.Color.Black;
            this.team2Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.team2Score.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.team2Score.ForeColor = System.Drawing.Color.White;
            this.team2Score.Location = new System.Drawing.Point(393, 0);
            this.team2Score.Name = "team2Score";
            this.team2Score.Size = new System.Drawing.Size(384, 72);
            this.team2Score.TabIndex = 1;
            this.team2Score.Text = "0";
            this.team2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // team3Score
            // 
            this.team3Score.AutoSize = true;
            this.team3Score.BackColor = System.Drawing.Color.Black;
            this.team3Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.team3Score.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.team3Score.ForeColor = System.Drawing.Color.White;
            this.team3Score.Location = new System.Drawing.Point(783, 0);
            this.team3Score.Name = "team3Score";
            this.team3Score.Size = new System.Drawing.Size(384, 72);
            this.team3Score.TabIndex = 6;
            this.team3Score.Text = "0";
            this.team3Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // team4Score
            // 
            this.team4Score.AutoSize = true;
            this.team4Score.BackColor = System.Drawing.Color.Black;
            this.team4Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.team4Score.Font = new System.Drawing.Font("Lucida Sans", 26.25F, System.Drawing.FontStyle.Bold);
            this.team4Score.ForeColor = System.Drawing.Color.White;
            this.team4Score.Location = new System.Drawing.Point(1173, 0);
            this.team4Score.Name = "team4Score";
            this.team4Score.Size = new System.Drawing.Size(385, 72);
            this.team4Score.TabIndex = 7;
            this.team4Score.Text = "0";
            this.team4Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }

        #endregion

        #region Abstract members

        /// <summary>
        /// Add team1Score, team2Score, team3Score, and team4Score to the MainQuestionBoard.
        /// </summary>
        /// <param name="panel"></param>
        public override void AddToQuestionBoard(TableLayoutPanel panel)
        {
            panel.ColumnCount = 4;
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            panel.Controls.Add(this.team2Score, 1, 0);
            panel.Controls.Add(this.team1Score, 0, 0);
            panel.Controls.Add(this.team3Score, 2, 0);
            panel.Controls.Add(this.team4Score, 3, 0);
            panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel.Location = new System.Drawing.Point(0, 653);
            panel.Name = "Scoreboard";
            panel.RowCount = 1;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            panel.Size = new System.Drawing.Size(1561, 72);
            panel.TabIndex = 1;
        }

        /// <summary>
        /// Selectively apply MainQuestionBoard's appearance settings for QuestionButtons to the Scoreboard.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        public override void ApplyQuestionBoardStyle(System.Drawing.Font font, System.Drawing.Color backgroundColor, System.Drawing.Color foregroundColor)
        {
            // Use the font and foreground color, but ignore the background color.
            
            team1Score.Font = font;
            team2Score.Font = font;
            team3Score.Font = font;
            team4Score.Font = font;

            team1Score.ForeColor = foregroundColor;
            team2Score.ForeColor = foregroundColor;
            team3Score.ForeColor = foregroundColor;
            team4Score.ForeColor = foregroundColor;
        }

        #endregion

        /// <summary>
        /// Set the BackColor of team1Score, team2Score, team3Score, and team4Score to match the values in teams array.
        /// </summary>
        /// <param name="teams">Teams playing the game.</param>
        public void SetTeams(Team[] teams)
        {
            team1Score.BackColor = teams[0].Color;
            team2Score.BackColor = teams[1].Color;
            team3Score.BackColor = teams[2].Color;
            team4Score.BackColor = teams[3].Color;
        }

        /// <summary>
        /// Update the Scoreboard.
        /// </summary>
        /// <param name="team">Team whose score is being updated.</param>
        /// <param name="score">New score.</param>
        public void UpdateScore(int team, int score)
        {
            switch (team)
            {
                case 1: team1Score.Text = score.ToString(); break;
                case 2: team2Score.Text = score.ToString(); break;
                case 3: team3Score.Text = score.ToString(); break;
                case 4: team4Score.Text = score.ToString(); break;
                default: break;
            }
        }

        public int[] GetScores()
        {
            return new int[4] { Convert.ToInt32(team1Score.Text), Convert.ToInt32(team2Score.Text), Convert.ToInt32(team3Score.Text), Convert.ToInt32(team4Score.Text) };
        }
    }
}
