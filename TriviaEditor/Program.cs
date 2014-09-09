using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TriviaLib;

namespace TriviaEditor
{
    static class Program
    {
        static MainQuestionBoard board;
        static JeopardyEditor editor;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            editor = new JeopardyEditor();
            board = new MainQuestionBoard(null, editor);
            editor.Questions = board.Questions;
            editor.Categories = board.Categories;

            board.CategorySelected += new EventHandler<CategoryEventArgs>(CategorySelected);
            board.QuestionSelected += new EventHandler<QuestionButtonEventArgs>(QuestionSelected);
            
            Application.Run(board);
        }

        // Handle a QuestionSelected event by entering question edit mode
        private static void QuestionSelected(object sender, QuestionButtonEventArgs e)
        {
            editor.EnterQuestionEditMode(e.Button);
        }

        // Handle a CategorySelected event by entering category edit mode
        private static void CategorySelected(object sender, CategoryEventArgs e)
        {
            editor.EnterCategoryEditMode(e.CategoryButton);
        }
    }
}
