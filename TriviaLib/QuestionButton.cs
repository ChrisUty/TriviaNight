using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TriviaLib
{
    /// <summary>
    /// One of the questions on the MainQuestionBoard.
    /// </summary>
    public partial class QuestionButton : Button
    {
        private string question;
        private string answer;
        private int points;
        private bool answered;
        private Team winningTeam;
        private int column;
        private int row;

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public QuestionButton()
        {
            answered = false;
            points = 0;
            answer = "";
            question = "";
            winningTeam = null;
            column = 0;
            row = 0;

            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="c">Grid Column</param>
        /// <param name="r">Grid Row</param>
        public QuestionButton(int c, int r) : this()
        {
            column = c;
            row = r;
        }

        #endregion


        #region Accessors

        /// <summary>
        /// Question accessor
        /// </summary>
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        /// <summary>
        /// Answer accessor
        /// </summary>
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        /// <summary>
        /// Point value accessor
        /// </summary>
        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Whether this QuestionButton has been answered
        /// </summary>
        public bool Answered
        {
            get { return answered; }
            set { answered = value; }
        }

        /// <summary>
        /// The Team that answered this question
        /// </summary>
        public Team WinningTeam
        {
            get { return winningTeam; }
            set { winningTeam = value; }
        }

        /// <summary>
        /// Grid Column
        /// </summary>
        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        /// <summary>
        /// Grid Row
        /// </summary>
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
    }

    #endregion

    #region QuestionButtonEventArgs

    /// <summary>
    /// EventArgs used MainQuestionBoard's QuestionSelected event
    /// </summary>
    public class QuestionButtonEventArgs : EventArgs
    {
        private QuestionButton qb;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="button">QuestionButton that was selected by player</param>
        public QuestionButtonEventArgs(QuestionButton button)
        {
            qb = button;
        }

        /// <summary>
        /// QuestionButton accessor
        /// </summary>
        public QuestionButton Button
        {
            get { return qb; }
        }
    }

    #endregion
}
