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
    /// One of the categories on the MainQuestionBoard.
    /// </summary>
    public partial class CategoryButton : Button
    {
        private int column;

        #region Constructors

        public CategoryButton(int c)
        {
            column = c;
            InitializeComponent();
        }

        public CategoryButton()
            : this(0)
        {

        }

        #endregion

        #region Accessors

        public int Column
        {
            set { column = value; }
            get { return column; }
        }

        #endregion
    }

    #region CategoryEventArgs

    public class CategoryEventArgs : EventArgs
    {
        private CategoryButton cb;

        public CategoryEventArgs(CategoryButton button)
        {
            cb = button;
        }

        public CategoryButton CategoryButton
        {
            get { return cb; }
        }
    }

    #endregion
}
