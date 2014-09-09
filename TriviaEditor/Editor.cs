using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TriviaLib;

namespace TriviaEditor
{
    /// <summary>
    /// A QuestionBoardFooter that edits the contents of MainQuestionBoard.
    /// </summary>
    class JeopardyEditor : QuestionBoardFooter
    {
        private Label questionLabel;
        private TextBox questionTextBox;
        private TextBox answerTextBox;
        private Label answerLabel;
        private Button saveButton;
        private int editColumn;
        private int editRow;
        private CategoryButton[] categories;
        private QuestionButton[] questions;

        #region Constructor & InitializeComponent

        /// <summary>
        /// Constructor
        /// </summary>
        public JeopardyEditor()
        {
            InitializeComponent();
            DisableEditing();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cb">MainQuestionBoard's CategoryButtons</param>
        /// <param name="qb">MainQuestionBoard's QuestionButtons</param>
        public JeopardyEditor(CategoryButton[] cb, QuestionButton[] qb) : this()
        {
            categories = cb;
            questions = qb;
        }

        public void InitializeComponent()
        {
            questionLabel = new Label();
            questionTextBox = new TextBox();
            answerLabel = new Label();
            answerTextBox = new TextBox();
            saveButton = new Button();

            // 
            // questionLabel
            // 
            this.questionLabel.AutoSize = true;
            this.questionLabel.BackColor = System.Drawing.Color.DodgerBlue;
            this.questionLabel.ForeColor = System.Drawing.Color.White;
            this.questionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.questionLabel.Location = new System.Drawing.Point(3, 600);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(305, 104);
            this.questionLabel.TabIndex = 10;
            this.questionLabel.Text = "Question:";
            this.questionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionTextBox
            // 
            this.questionTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.questionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionTextBox.Location = new System.Drawing.Point(314, 603);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(305, 98);
            this.questionTextBox.TabIndex = 11;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.BackColor = System.Drawing.Color.DodgerBlue;
            this.answerLabel.ForeColor = System.Drawing.Color.White;
            this.answerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.answerLabel.Location = new System.Drawing.Point(625, 600);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(305, 104);
            this.answerLabel.TabIndex = 12;
            this.answerLabel.Text = "Answer:";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // answerTextBox
            // 
            this.answerTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerTextBox.Location = new System.Drawing.Point(936, 603);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(305, 98);
            this.answerTextBox.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Green;
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Location = new System.Drawing.Point(1247, 603);
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(307, 98);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
        }

        #endregion

        #region Abstract Members

        /// <summary>
        /// Add questionLabel, questionTextBox, answerLabel, answerTextBox, and saveButton to MainQuestionBoard.
        /// </summary>
        /// <param name="panel"></param>
        public override void AddToQuestionBoard(TableLayoutPanel panel)
        {
            panel.ColumnCount = 5;
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            panel.Controls.Add(this.questionLabel, 0, 0);
            panel.Controls.Add(this.questionTextBox, 1, 0);
            panel.Controls.Add(this.answerLabel, 2, 0);
            panel.Controls.Add(this.answerTextBox, 3, 0);
            panel.Controls.Add(this.saveButton, 4, 0);
            panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel.Location = new System.Drawing.Point(0, 653);
            panel.Name = "Editor";
            panel.RowCount = 1;
            panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
            panel.Size = new System.Drawing.Size(1561, 72);
            panel.TabIndex = 1;
        }

        /// <summary>
        /// Selectively apply MainQuestionBoard's appearance settings for QuestionButtons to class members
        /// </summary>
        /// <param name="font"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="foregroundColor"></param>
        public override void ApplyQuestionBoardStyle(System.Drawing.Font font, System.Drawing.Color backgroundColor, System.Drawing.Color foregroundColor)
        {
            // Always use font and foregroundColor.  Ignore backgroundColor for the save button.

            questionLabel.Font = font;
            answerLabel.Font = font;
            saveButton.Font = font;

            questionLabel.ForeColor = foregroundColor;
            answerLabel.ForeColor = foregroundColor;
            saveButton.ForeColor = foregroundColor;

            questionLabel.BackColor = backgroundColor;
            answerLabel.BackColor = backgroundColor;
        }

        #endregion

        #region Accessors

        /// <summary>
        /// MainQuestionBoard's QuestionButtons
        /// TODO: Probably not necessary to have this
        /// </summary>
        public QuestionButton[] Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        /// <summary>
        /// MainQuestionBoard's CategoryButtons
        /// TODO: Probably not necessary to have this
        /// </summary>
        public CategoryButton[] Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        #endregion

        #region State Tracking

        /// <summary>
        /// Prepare to edit a CategoryButton
        /// </summary>
        /// <param name="cb">CategoryButton to be edited</param>
        public void EnterCategoryEditMode( CategoryButton cb )
        {
            questionLabel.Text = "Category:";
            questionTextBox.Enabled = true;
            questionTextBox.Text = cb.Text;

            answerTextBox.Enabled = false;
            answerTextBox.Text = "";

            editColumn = cb.Column;
            editRow = 0;
        }

        /// <summary>
        /// Prepare to edit a QuestionButton
        /// </summary>
        /// <param name="qb">QuestionButton to be edited</param>
        public void EnterQuestionEditMode( QuestionButton qb )
        {
            questionLabel.Text = "Question: ";

            questionTextBox.Enabled = true;
            questionTextBox.Text = qb.Question;

            answerTextBox.Enabled = true;
            answerTextBox.Text = qb.Answer;

            editColumn = qb.Column;
            editRow = qb.Row;
        }

        /// <summary>
        /// Prevent editing until a QuestionButton or CategoryButton has been selected.
        /// </summary>
        public void DisableEditing()
        {
            questionTextBox.Text = "";
            questionTextBox.Enabled = false;

            questionLabel.Text = "Question:";

            answerTextBox.Text = "";
            answerTextBox.Enabled = false;

            editColumn = 0;
            editRow = 0;
        }

        #endregion

        #region Save

        /// <summary>
        /// saveButton click event handler.
        /// </summary>
        /// <param name="sender">Object invoking event</param>
        /// <param name="e">Event args</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Save();
            DisableEditing();
        }

        /// <summary>
        /// Save current QuestionButton and CategoryButton content as config.xml
        /// </summary>
        public void Save()
        {
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
                XmlWriter writer = XmlWriter.Create("config.xml", settings);
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("game");

                    for (int category = 1; category < 6; category++)
                    {
                        if (editColumn == category && editRow == 0)
                        {
                            categories[category -1].Text = questionTextBox.Text;
                        }

                        writer.WriteStartElement("category");
                        writer.WriteStartElement("name");
                        writer.WriteString(categories[category-1].Text);
                        writer.WriteEndElement();

                        for (int question = 1; question < 6; question++)
                        { 
                            int index = ((category - 1) * 5) + question - 1;

                            if (editColumn == category && editRow == question)
                            {
                                questions[index].Question = questionTextBox.Text;
                                questions[index].Answer = answerTextBox.Text;
                            }

                            writer.WriteStartElement("question");

                            writer.WriteStartElement("name");
                            writer.WriteString(questions[index].Question);
                            writer.WriteEndElement();

                            writer.WriteStartElement("answer");
                            writer.WriteString(questions[index].Answer);
                            writer.WriteEndElement();

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving config.xml: " + e.Message);
            }
        }

        #endregion
    }
}
