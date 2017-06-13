using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Circle : _1parameter
    {
       public Circle(): base()
       {
           Type = "Circle";
       }

        /// <summary>
        /// Calculates area or circle
        /// </summary>
        /// <returns></returns>
       override public double CalculateArea(){

            double area = PI * Math.Pow(value,2);
            return area;
       }

        /// <summary>
        /// will not be using this class for this object
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
            base.valueName = " radius";
            base.SetData();
        }

        /// <summary>
        /// formats strings to display object data
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
