using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Rectangle : _2parameters
    {

        public Rectangle()
            : base()
        {
            Type = "Rectangle";
        }

        /// <summary>
        /// Calculates area
        /// </summary>
        /// <returns></returns>
        override public double CalculateArea()
        {
            double area = value * value2;
            return area;
        }
        /// <summary>
        /// this method will not be used
        /// </summary>
        /// <returns></returns>
        override public double CalculateVolume()
        {
            double d = 0;
            return d;
        }
        /// <summary>
        /// prompts user for input data
        /// </summary>
        override public void SetData()
        {
            base.valueName = " length";
            base.value2Name = " width";
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

