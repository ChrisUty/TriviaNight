using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TriviaLib
{
    /// <summary>
    /// This is the content that goes on the bottom of the screen within MainQuestionBoard's footerLayoutPanel.  The project using TriviaLib defines a parent class
    /// of QuestionBoardFooter and uses it to construct the MainQuestionBoard.
    /// </summary>
    abstract public class QuestionBoardFooter
    {
        /// <summary>
        /// Add this to MainQuestionBoard
        /// </summary>
        /// <param name="panel">MainQuestionBoard uses this TableLayoutPanel to add the QuestionBoardFooter to itself.</param>
        abstract public void AddToQuestionBoard(TableLayoutPanel panel);

        /// <summary>
        /// Make various QuestionBoardFooter components conform with MainQuestionBoard's look and feel.
        /// </summary>
        /// <param name="font">QuestionButton Font</param>
        /// <param name="backgroundColor">QuestionButton background Color</param>
        /// <param name="foregroundColor">QuestionButton foreground Color</param>
        abstract public void ApplyQuestionBoardStyle(System.Drawing.Font font, System.Drawing.Color backgroundColor, System.Drawing.Color foregroundColor);
    }
}
