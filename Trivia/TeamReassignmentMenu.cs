using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TriviaLib;

namespace Trivia
{
    /// <summary>
    /// A ContextMenuStrip that appears over a selected QuestionButton if it already has a winning team. 
    /// Used to reassign the winning Team of a QuestionButton.
    /// 
    /// TODO: Buggy behavior observed when reassigning a Button from TeamX to NoTeam back to any team.
    /// </summary>
    class TeamReassignmentMenu
    {
        private ContextMenuStrip reassignmentMenu;
        private ToolStripMenuItem team1ToolStripMenuItem;
        private ToolStripMenuItem team2ToolStripMenuItem;
        private ToolStripMenuItem team3ToolStripMenuItem;
        private ToolStripMenuItem team4ToolStripMenuItem;
        private ToolStripMenuItem noTeamToolStripMenuItem;
        private QuestionButton reassignedButton;
        private Team[] teams;

        /// <summary>
        /// A QuestionButton has been reassigned from one Team to another via the TeamReassignmentMenu.
        /// </summary>
        public event EventHandler<ReassignedQuestionButtonEventArgs> QuestionReassigned;

        #region Constructors 

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamReassignmentMenu() : this( null )
        {
    
        }

        /// <summary>
        /// Constructor
        /// TODO: Variable number of teams
        /// </summary>
        /// <param name="t">Teams playing the game</param>
        public TeamReassignmentMenu( Team[] t )
        {
            reassignmentMenu = new ContextMenuStrip();
            team1ToolStripMenuItem = new ToolStripMenuItem();
            team2ToolStripMenuItem = new ToolStripMenuItem();
            team3ToolStripMenuItem = new ToolStripMenuItem();
            team4ToolStripMenuItem = new ToolStripMenuItem();
            noTeamToolStripMenuItem = new ToolStripMenuItem();
            teams = t;
            reassignedButton = null;

            // 
            // team1ToolStripMenuItem
            // 
            team1ToolStripMenuItem.ForeColor = System.Drawing.Color.Wheat;
            team1ToolStripMenuItem.BackColor = teams != null && teams[0] != null ? teams[0].Color : System.Drawing.Color.Black;
            team1ToolStripMenuItem.Name = "team1ToolStripMenuItem";
            team1ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            team1ToolStripMenuItem.Text = "Team 1";
            team1ToolStripMenuItem.Click += new System.EventHandler(team1ToolStripMenuItem_Click);

            // 
            // team2ToolStripMenuItem
            // 
            team2ToolStripMenuItem.ForeColor = System.Drawing.Color.Wheat;
            team2ToolStripMenuItem.BackColor = teams != null && teams[1] != null ? teams[1].Color : System.Drawing.Color.Black;
            team2ToolStripMenuItem.Name = "team2ToolStripMenuItem";
            team2ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            team2ToolStripMenuItem.Text = "Team 2";
            team2ToolStripMenuItem.Click += new System.EventHandler(team2ToolStripMenuItem_Click);

            // 
            // team3ToolStripMenuItem
            // 
            team3ToolStripMenuItem.ForeColor = System.Drawing.Color.Wheat;
            team3ToolStripMenuItem.BackColor = teams != null && teams[2] != null ? teams[2].Color : System.Drawing.Color.Black;
            team3ToolStripMenuItem.Name = "team3ToolStripMenuItem";
            team3ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            team3ToolStripMenuItem.Text = "Team 3";
            team3ToolStripMenuItem.Click += new System.EventHandler(team3ToolStripMenuItem_Click);

            // 
            // team4ToolStripMenuItem
            // 
            team4ToolStripMenuItem.ForeColor = System.Drawing.Color.Wheat;
            team4ToolStripMenuItem.BackColor = teams != null && teams[3] != null ? teams[3].Color : System.Drawing.Color.Black;
            team4ToolStripMenuItem.Name = "team4ToolStripMenuItem";
            team4ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            team4ToolStripMenuItem.Text = "Team 4";
            team4ToolStripMenuItem.Click += new System.EventHandler(team4ToolStripMenuItem_Click);

            // 
            // noTeamToolStripMenuItem
            // 

            noTeamToolStripMenuItem.ForeColor = System.Drawing.Color.Wheat;
            noTeamToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            noTeamToolStripMenuItem.Name = "noTeamToolStripMenuItem";
            noTeamToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            noTeamToolStripMenuItem.Text = "No Team";
            noTeamToolStripMenuItem.Click += new System.EventHandler(this.noTeamToolStripMenuItem_Click);

            // 
            // teamReassignmentMenu
            // 
            reassignmentMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                team1ToolStripMenuItem,
                team2ToolStripMenuItem,
                team3ToolStripMenuItem,
                team4ToolStripMenuItem,
                noTeamToolStripMenuItem});
            reassignmentMenu.Name = "Team Reassignment Menu";
            reassignmentMenu.Size = new System.Drawing.Size(124, 114);
        }
        #endregion

        #region Events
        private void team1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionReassigned( this, new ReassignedQuestionButtonEventArgs( reassignedButton, teams[0] ));
        }

        private void team2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionReassigned( this, new ReassignedQuestionButtonEventArgs( reassignedButton, teams[1] ));
        }

        private void team3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionReassigned( this, new ReassignedQuestionButtonEventArgs( reassignedButton, teams[2] ));
        }

        private void team4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionReassigned( this, new ReassignedQuestionButtonEventArgs( reassignedButton, teams[3] ));
        }

        private void noTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuestionReassigned( this, new ReassignedQuestionButtonEventArgs( reassignedButton, null ));
        }

        // Throw a QuestionReassigned event
        private void ReassignQuestion(QuestionButton qb, Team newTeam)
        {
            EventHandler<ReassignedQuestionButtonEventArgs> handler = QuestionReassigned;
            if (handler != null)
            {
                handler(null, new ReassignedQuestionButtonEventArgs(qb, newTeam));
            }
        }

        #endregion

        /// <summary>
        /// Show the TeamReassignmentMenu
        /// </summary>
        /// <param name="qb">QuestionButton that was pushed</param>
        /// <param name="location">Mouse location</param>
        public void Show(QuestionButton qb, System.Drawing.Point location)
        {
            reassignedButton = qb;
            reassignmentMenu.Show(location);
        }
    }

    #region ReassignedQuestionButtonEventArgs

    /// <summary>
    /// A child of EventArgs that contains a QuestionButton and a Team.  The event handler
    /// should reassign QuestionButton's team to newTeam.
    /// </summary>
    public class ReassignedQuestionButtonEventArgs : EventArgs
    {
        private QuestionButton qb;
        private Team newTeam;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="button">QuestionButton being reassigned</param>
        /// <param name="t">New winning Team</param>
        public ReassignedQuestionButtonEventArgs(QuestionButton button, Team t)
        {
            qb = button;
            newTeam = t;
        }

        /// <summary>
        /// QuestionButton accessor
        /// </summary>
        public QuestionButton Button
        {
            get { return qb; }
        }

        /// <summary>
        /// Team accessor
        /// </summary>
        public Team NewTeam
        {
            get { return newTeam; }
        }
    }

    #endregion
}
