using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Sphere : _1parameter
    {
       
       public Sphere(): base()
       {
           Type = "Sphere";
       }

        /// <summary>
        /// Calculates area of sphere
        /// </summary>
        /// <returns></returns>
       override public double CalculateArea()
       {
            double area = 4 * PI * Math.Pow(value,2);
            return area;
       }

        /// <summary>
        /// volume of sphere
        /// </summary>
        /// <returns></returns>
       override public double CalculateVolume()
       {
           double volume = 1.3333333 * PI * Math.Pow(value,3);
           return volume;
       } 
        /// <summary>
        ///prompts user for input data
        /// </summary>
        override public void SetData(){
            base.valueName = " radius";
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
