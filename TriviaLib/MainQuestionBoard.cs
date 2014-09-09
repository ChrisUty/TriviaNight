using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace TriviaLib
{
    /// <summary>
    /// A Form that includes one row of five CategoryButtons each with five rows of QuestionButtons beneath them.  
    /// The footerLayoutPanel is empty, its contents are defined in a class derived from QuestionBoardFooter.
    /// </summary>
    public partial class MainQuestionBoard : Form
    {
        // TODO: 2D array
        private QuestionButton[] questions;
        private CategoryButton[] categories;
        private Team[] teams;

        #region Accessors

        /// <summary>
        /// QuestionButton accessor
        /// </summary>
        public QuestionButton[] Questions
        {
            get { return questions; }
        }

        /// <summary>
        /// CategoryButton accessor
        /// </summary>
        public CategoryButton[] Categories
        {
            get { return categories; }
        }

        /// <summary>
        /// Background Color accessor.
        /// </summary>
        /// <returns>The background color used by questionButton1A (and hopefully the rest of the MainQuestionBoard.)</returns>
        public System.Drawing.Color BoardBackColor()
        {
            return questionButton1A.BackColor;
        }

        /// <summary>
        /// Foreground Color accessor.
        /// </summary>
        /// <returns>The foreground color used by questionButton1A (and hopefully the rest of the MainQuestionBoard.)</returns>
        public System.Drawing.Color BoardForeColor()
        {
            return questionButton1A.ForeColor;
        }

        /// <summary>
        /// Font accessor.
        /// </summary>
        /// <returns>The Font used by questionButton1A (and hopefully the rest of the MainQuestionBoard.)</returns>
        public System.Drawing.Font BoardFont()
        {
            return questionButton1A.Font;
        }

        #endregion

        #region Constructor & Initialize
        public MainQuestionBoard(Team[] t, QuestionBoardFooter footer )
        {
            InitializeComponent();
            InitializeButtons();
            teams = t;
            footer.AddToQuestionBoard( footerLayoutPanel );
            footer.ApplyQuestionBoardStyle(questionButton1A.Font, questionButton1A.BackColor, questionButton1A.ForeColor);      // All QuestionButtons should have the same font & colors
        }

        public void InitializeButtons()
        {
            categories = new CategoryButton[] { categoryButton1, categoryButton2, categoryButton3, categoryButton4, categoryButton5 };
            questions = new QuestionButton[] { questionButton1A, questionButton1B, questionButton1C, questionButton1D, questionButton1E,
                                             questionButton2A, questionButton2B, questionButton2C, questionButton2D, questionButton2E,
                                             questionButton3A, questionButton3B, questionButton3C, questionButton3D, questionButton3E,
                                             questionButton4A, questionButton4B, questionButton4C, questionButton4D, questionButton4E,
                                             questionButton5A, questionButton5B, questionButton5C, questionButton5D, questionButton5E };

            try
            {
                XmlReader input = XmlReader.Create("config.xml");

                // 5 categories and 5 questions in each category, 30 buttons total
                for (int category = 0; category < 5; category++)
                {
                    while (!input.IsStartElement("name")) { input.Read(); }
                    categories[category].Text = input.ReadString();

                    for (int question = 0; question < 5; question++)
                    {
                        int index = (category * 5) + question;

                        while (!input.IsStartElement("name")) { input.Read(); }
                        questions[index].Question = input.ReadString();

                        while (!input.IsStartElement("answer")) { input.Read(); }
                        questions[index].Answer = input.ReadString();

                        questions[index].Points = (question + 1) * 10;
                    }
                }

                input.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not open config.xml: " + e.ToString());
                Environment.Exit(0);
            }
        }

        #endregion

        #region Button Press Events

        /// <summary>
        /// Signals player has pushed a QuestionButton
        /// </summary>
        public event EventHandler<QuestionButtonEventArgs> QuestionSelected;

        /// <summary>
        /// Signals player has pushed a CategoryButton
        /// </summary>
        public event EventHandler<CategoryEventArgs> CategorySelected;

        /// <summary>
        /// Fire QuestionSelected event
        /// </summary>
        /// <param name="qb">QuestionButton selected</param>
        private void SelectQuestion(QuestionButton qb)
        {
            EventHandler<QuestionButtonEventArgs> handler = QuestionSelected;
            if (handler != null)
            {
                handler(null, new QuestionButtonEventArgs(qb));
            }
        }

        /// <summary>
        /// Fire CategorySelected event
        /// </summary>
        /// <param name="b">CategoryButton selected</param>
        private void SelectCategory(CategoryButton b)
        {
            EventHandler<CategoryEventArgs> handler = CategorySelected;
            if (handler != null)
            {
                handler(null, new CategoryEventArgs(b));
            }
        }

        private void questionButton1A_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton1A);
        }

        private void questionButton1B_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton1B);
        }

        private void questionButton1C_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton1C);
        }

        private void questionButton1D_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton1D);
        }

        private void questionButton1E_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton1E);
        }

        private void questionButton2A_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton2A);
        }

        private void questionButton2B_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton2B);
        }

        private void questionButton2C_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton2C);
        }

        private void questionButton2D_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton2D);
        }

        private void questionButton2E_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton2E);
        }

        private void questionButton3A_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton3A);
        }

        private void questionButton3B_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton3B);
        }

        private void questionButton3C_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton3C);
        }

        private void questionButton3D_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton3D);
        }

        private void questionButton3E_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton3E);
        }

        private void questionButton4A_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton4A);
        }

        private void questionButton4B_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton4B);
        }

        private void questionButton4C_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton4C);
        }

        private void questionButton4D_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton4D);
        }

        private void questionButton4E_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton4E);
        }

        private void questionButton5A_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton5A);
        }

        private void questionButton5B_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton5B);
        }

        private void questionButton5C_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton5C);
        }

        private void questionButton5D_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton5D);
        }

        private void questionButton5E_Click(object sender, EventArgs e)
        {
            SelectQuestion(questionButton5E);
        }

        private void category1Button_Click(object sender, EventArgs e)
        {
            SelectCategory(categoryButton1);
        }

        private void category2Button_Click(object sender, EventArgs e)
        {
            SelectCategory(categoryButton2);
        }

        private void category3Button_Click(object sender, EventArgs e)
        {
            SelectCategory(categoryButton3);
        }

        private void category4Button_Click(object sender, EventArgs e)
        {
            SelectCategory(categoryButton4);
        }

        private void category5Button_Click(object sender, EventArgs e)
        {
            SelectCategory(categoryButton5);
        }

        #endregion
    }
}
