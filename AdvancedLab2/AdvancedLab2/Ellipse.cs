using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Ellipse : _2parameters
    {

       public Ellipse():base() {
           Type = "Ellipse";
       }

        /// <summary>
        /// Calculates area or circle
        /// </summary>
        /// <returns></returns>
       override public double CalculateArea(){
          
            double area = PI * value * value2;
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
            base.valueName = " radius major";
            base.value2Name = " radius minor";
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
