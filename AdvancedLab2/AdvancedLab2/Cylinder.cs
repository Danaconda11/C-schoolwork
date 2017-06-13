using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Cylinder : _2parameters
    {
        public Cylinder()
            : base()
        {
            Type = "Cylinder";
        }

        /// <summary>
        /// Calculates area for Cylinder
        /// </summary>
        /// <returns></returns>
       override public double CalculateArea(){

            double area = (2 * PI * value * value2)  + (2 * PI * Math.Pow(value2,2));
            return area;
       }
        /// <summary>
        /// calculates volume of a cylinder
        /// </summary>
        /// <returns></returns>
       override public double CalculateVolume()
       {
           double volume = PI * Math.Pow(value2,2) * value;
           return volume;
       } 
        /// <summary>
        /// prompts user for input data
        /// </summary>
        override public void SetData(){

            base.valueName = " height";
            base.value2Name = " radius";
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
