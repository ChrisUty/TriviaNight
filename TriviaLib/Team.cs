using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriviaLib
{
    /// <summary>
    /// A team playing the game.
    /// </summary>
    public class Team : IComparable
    {
        private System.Drawing.Color color;
        private int score;
        private int number;

        #region Constructors

        /// <summary>
        /// Team constructor.
        /// </summary>
        /// <param name="c">Color</param>
        /// <param name="n">Team Number</param>
        public Team(System.Drawing.Color c, int n)
        {
            color = c;
            number = n;
            score = 0;
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Team Number accessor
        /// </summary>
        public int Number
        {
            get { return number; }
        }

        /// <summary>
        /// Score accessor
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// Color accessor
        /// </summary>
        public System.Drawing.Color Color
        {
            get { return color; }
        }

        #endregion

        /// <summary>
        /// Used by Sort, compares team scores.
        /// </summary>
        /// <param name="obj">Team compared to</param>
        /// <returns>Returns an indication of relative values</returns>
        public int CompareTo(object obj)
        {
            if (obj is Team) { return (obj as Team).Score.CompareTo(this.Score); }
            throw new ArgumentException( "Object is not of type Team" );
        }
    }
}
