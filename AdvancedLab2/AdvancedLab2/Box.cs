using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Box : _3parameters
    {
       
        /// <summary>
        /// surface area for a rectangular prism
        /// </summary>
        /// <returns></returns>
        override public double CalculateArea()
        {
            double area = 2 * ((value * value2) + (value3 * value) + (value3 * value2));
            return area;
        }

        public Box() :base(){
            Type = "Box";
        }
        /// <summary>
        /// volume for a rectangular prism
        /// </summary>
        /// <returns></returns>

        override public double CalculateVolume()
        {
            double area = value * value2 * value3;
            return area;
        }

        /// <summary>
        /// prompts user for data
        /// </summary>
        override public void SetData()
        {
            base.valueName = " length";
            base.value2Name = " width";
            base.value3Name = " height";
            base.SetData();

        }

        /// <summary>
        /// prints data in a formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
