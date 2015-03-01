using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TriviaLib;

namespace Trivia
{
    static class Program
    {
        static MainQuestionBoard questionBoard;
        static Scoreboard scoreBoard;
        static QuestionForm questionForm;
        static QuestionButton lastQuestionButtonSelected;
        static Team[] teams;
        static TeamReassignmentMenu reassignmentMenu;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            teams = new Team[] 
            {
                new Team(System.Drawing.Color.FromName("Blue"), 1),
                new Team(System.Drawing.Color.FromName("Green"), 2),
                new Team(System.Drawing.Color.FromName("Purple"), 3),
                new Team(System.Drawing.Color.FromName("DarkOrange"), 4)
            };

            scoreBoard = new Scoreboard();
            scoreBoard.SetTeams(teams);

            questionBoard = new MainQuestionBoard(teams, scoreBoard);
            questionBoard.QuestionSelected += new EventHandler<QuestionButtonEventArgs>(LaunchQuestion);

            questionForm = new QuestionForm( teams, questionBoard.BoardFont(), questionBoard.BoardBackColor(), questionBoard.BoardForeColor() );
            questionForm.QuestionAnswered += new EventHandler<QuestionAnsweredEventArgs>(QuestionAnswered);

            reassignmentMenu = new TeamReassignmentMenu( teams );
            reassignmentMenu.QuestionReassigned += new EventHandler<ReassignedQuestionButtonEventArgs>(QuestionReassigned);

            Application.Run(questionBoard);
        }

        #region EventHandlers

        // A QuestionButton has been pushed.  If it hasn't been answered yet, launch
        // questionForm.  If it has been answered, show reassignmentMenu.
        private static void LaunchQuestion(object sender, QuestionButtonEventArgs qb)
        {
            if (qb.Button.Answered == false)
            {
                questionBoard.Hide();
                lastQuestionButtonSelected = qb.Button;
                questionForm.Show(qb.Button.Question, qb.Button.Answer);
            }
            else
            {
                reassignmentMenu.Show(qb.Button, Cursor.Position);
            }
        }

        // A QuestionButton has been answered in questionForm.  Update the QuestionButton's
        // winning Team.  Check to see if the game has been won.
        private static void QuestionAnswered(object sender, QuestionAnsweredEventArgs e)
        {
            questionForm.Hide();
            questionBoard.Show();
            UpdateBoards(e.WinningTeam);

            lastQuestionButtonSelected.WinningTeam = e.WinningTeam;
            lastQuestionButtonSelected.Answered = true;
            lastQuestionButtonSelected = null;

            if (NeedTieBreaker() > 0)
            {
                MessageBox.Show("Tiebreaker Question!");
                questionBoard.Hide();
                lastQuestionButtonSelected = questionBoard.TieBreaker;
                questionForm.Show(questionBoard.TieBreaker.Question, questionBoard.TieBreaker.Answer);
            }
            else if (GameOver())
            {
                SetGameResult();
            }
        }

        // Update the QuestionButton's winning Team.  Update the score of the winning Team and
        // the Team that previously held this QuestionButton, if there is one.  
        private static void QuestionReassigned(object sender, ReassignedQuestionButtonEventArgs e)
        {
            Team newTeam = e.NewTeam;
            Team oldTeam = e.Button.WinningTeam;

            if (newTeam == oldTeam)
            {
                return;
            }

            if (newTeam != null)  // If the question is not being set to "no team"
            {
                newTeam.Score += e.Button.Points;
                e.Button.WinningTeam = newTeam;
                scoreBoard.UpdateScore(newTeam.Number, newTeam.Score);
                questionForm.UpdateScore(newTeam.Number, newTeam.Score);
                e.Button.BackColor = newTeam.Color;
            }
            else
            {
                e.Button.BackColor = System.Drawing.Color.Black;
            }

            if (oldTeam != null) // If the qustion was not previously set to "no team"
            {
                oldTeam.Score -= e.Button.Points;
                scoreBoard.UpdateScore(oldTeam.Number, oldTeam.Score);
                scoreBoard.UpdateScore(oldTeam.Number, oldTeam.Score);
            }
        }

        #endregion

        // Return true if all QuestionButtons have been answered.  Otherwise return false.
        private static bool GameOver()
        {
            QuestionButton[] questions = questionBoard.Questions;
            for (int counter = 0; counter < questions.Length; counter++)
            {
                if (questions[counter].Answered == false)
                {
                    return false;
                }
            }

            return true;
        }

        // Return 0 if GameOver() is false or if there is a winner.  Otherwise, return the number of teams 
        // that are tied for first place.
        private static int NeedTieBreaker()
        {
            if (GameOver() == false)
            {
                return 0;
            }

            int[] scores = scoreBoard.GetScores();
            Array.Sort(scores);
            Array.Reverse(scores);

            // Team 0 is the winner, no tie breaker needed.
            if (scores[0] > scores[1])
            {
                return 0;
            }

            // Teams 0 and 1 are tied for 1st.
            if (scores[0] > scores[2])
            {
                return 2;
            }

            // Teams 0, 1, and 2 are tied for first.
            if (scores[0] > scores[3])
            {
                return 3;
            }

            // Four way tie.
            return 4;
        }

        // Update the background Color of all QuestionButtons to the Color of the winning Team.
        private static void SetGameResult()
        {
            Team[] sortedByScore = teams;
            Array.Sort(sortedByScore);
            QuestionButton[] questions = questionBoard.Questions;
            for (int counter = 0; counter < questions.Length; counter++)
            {
                questions[counter].BackColor = sortedByScore[0].Color;
            }

            
        }

        // Update the score of the winning team.  If there wasn't a winning team, set the
        // QuestionButton's background Color to black.
        private static void UpdateBoards( Team winningTeam )
        {
            if( winningTeam != null )
            {
                UpdateScore( winningTeam );
            }
            else    // no winning team
            {
                lastQuestionButtonSelected.BackColor = System.Drawing.Color.Black;
            }
        }

        // Update the score of a Team.
        // TODO: This and UpdateBoards seem redundant
        private static void UpdateScore(Team winningTeam)
        {
            winningTeam.Score += lastQuestionButtonSelected.Points;
            lastQuestionButtonSelected.BackColor = winningTeam.Color;
            scoreBoard.UpdateScore(winningTeam.Number, winningTeam.Score);
            questionForm.UpdateScore(winningTeam.Number, winningTeam.Score);
        }
    }
}
