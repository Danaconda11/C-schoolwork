using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Square : _1parameter
    {

        /// <summary>
        /// area for a square
        /// </summary>
        /// <returns></returns>
        override public double CalculateArea()
        {
            double area = value * value;
            return area;
        }

        public Square()
            : base()
        {
            Type = "Square";
        }
        /// <summary>
        /// prompts user for input data
        /// </summary>
         public override void SetData()
        {
            base.valueName = " length";
            base.SetData();
        }
        /// <summary>
        /// outputs object data into a formatted string
        /// </summary>
        /// <returns></returns>
         public override string ToString()
         {
             return base.ToString();
         }
    }
}
