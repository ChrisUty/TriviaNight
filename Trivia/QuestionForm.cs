using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TriviaLib;

namespace Trivia
{
    /// <summary>
    /// A form that shows the QuestionButton's question, selects a winning Team, and then shows the QuestionButton's answer.
    /// </summary>
    public partial class QuestionForm : Form
    {
        private string question;
        private string answer;
        private Team winningTeam;
        private Team[] teams;
        private Color defaultBackColor;

        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="t">Teams playing the game.</param>
        /// <param name="font">Font to display questions and answers with.</param>
        /// <param name="backColor">Background color to use on the form.</param>
        /// <param name="foreColor">Foreground color to use on the form.</param>
        public QuestionForm( Team[] t, Font font, Color backColor, Color foreColor )
        {
            InitializeComponent();

            Team1Button.BackColor = t[0].Color;
            Team2Button.BackColor = t[1].Color;
            Team3Button.BackColor = t[2].Color;
            Team4Button.BackColor = t[3].Color;

            Team1Button.ForeColor = foreColor;
            Team2Button.ForeColor = foreColor;
            Team3Button.ForeColor = foreColor;
            Team4Button.ForeColor = foreColor;

            Team1Button.Font = font;
            Team2Button.Font = font;
            Team3Button.Font = font;
            Team4Button.Font = font;

            questionLabel.BackColor = backColor;
            questionLabel.ForeColor = foreColor;
            questionLabel.Font = font;

            defaultBackColor = backColor;

            teams = t;
        }

        #endregion

        /// <summary>
        /// Show this.
        /// </summary>
        /// <param name="q">Question</param>
        /// <param name="a">Answer</param>
        public void Show(string q, string a)
        {
            question = q;
            answer = a;

            questionLabel.Text = q;
            questionLabel.BackColor = defaultBackColor;
         
            this.Show();
        }

        /// <summary>
        /// Update team scores.
        /// TODO: Show should be given new scores.
        /// </summary>
        /// <param name="team">Team to update</param>
        /// <param name="score">Team's score</param>
        public void UpdateScore( int team, int score )
        {
            switch (team)
            {
                case 1: Team1Button.Text = score.ToString(); break;
                case 2: Team2Button.Text = score.ToString(); break;
                case 3: Team3Button.Text = score.ToString(); break;
                case 4: Team4Button.Text = score.ToString(); break;
                default: break;
            }
        }

        // Return the winning Team's color or Black if no Team could answer it.
        private Color GetWinningTeamColor()
        {
            return winningTeam != null ? winningTeam.Color : Color.Black;
        }

        #region Events

        /// <summary>
        /// A winning Team has been selected for a QuestionButton.
        /// </summary>
        public event EventHandler<QuestionAnsweredEventArgs> QuestionAnswered;

        /// <summary>
        /// Fire a QuestionAnswered event.
        /// </summary>
        private void AnswerQuestion()
        {
            EventHandler<QuestionAnsweredEventArgs> handler = QuestionAnswered;
            if (handler != null)
            {
                handler(null, new QuestionAnsweredEventArgs(winningTeam));
            }
        }

        // Prevent this form from closing.  The form is displayed and hidden by Program.
        private void QuestionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        // When you click a Team's button, it will change the background color of the form to match that team's color.  Click it a second
        // time to confirm the selection.  If a different team is selected, the background color is updated.  Black indicates no team
        // successfully answered the question.
        private void ShowAnswer( Team team )
        {
            winningTeam = team;
            questionLabel.Text = answer;

            if (questionLabel.BackColor == GetWinningTeamColor())    // If the team button has been pressed twice in a row, confirm the selection
            {
                QuestionAnswered(this, new QuestionAnsweredEventArgs(team));
            }
            else
            {
                questionLabel.BackColor = GetWinningTeamColor();
            }
        }

        private void Team1Button_Click(object sender, EventArgs e)
        {
            ShowAnswer( teams[0] );
        }

        private void Team2Button_Click(object sender, EventArgs e)
        {
            ShowAnswer( teams[1] );
        }

        private void Team3Button_Click(object sender, EventArgs e)
        {
            ShowAnswer( teams[2] );
        }

        private void Team4Button_Click(object sender, EventArgs e)
        {
            ShowAnswer( teams[3] );
        }

        private void NoTeamButton_Click(object sender, EventArgs e)
        {
            ShowAnswer( null );
        }

        #endregion
    }

    #region QuestionAnsweredEventArgs

    /// <summary>
    /// A child class of EventArgs that contains a winning Team.
    /// </summary>
    public class QuestionAnsweredEventArgs : EventArgs
    {
        private Team winningTeam;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wT">The Team that answered this question.</param>
        public QuestionAnsweredEventArgs(Team wT)
        {
            winningTeam = wT;
        }

        /// <summary>
        /// Accessor
        /// </summary>
        public Team WinningTeam
        {
            get { return winningTeam; }
        }
    }

    #endregion
}
