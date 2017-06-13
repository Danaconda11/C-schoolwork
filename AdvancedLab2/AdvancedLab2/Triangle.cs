using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Triangle : _2parameters
    {
       
        public Triangle() :base()
        {
            Type = "Triangle";
        }

        /// <summary>
        /// Calculates area
        /// </summary>
        /// <returns></returns>
       override public double CalculateArea(){

            double area = (value * value2) / 2;
            return area;
       }
        /// <summary>
        /// this method will not be used for this object
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
        override public void SetData(){

            base.valueName = " base";
            base.value2Name = " height";
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
