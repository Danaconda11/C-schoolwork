using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class _1parameter : Shape
    {
        protected string valueName;
        protected double value;
        protected string v;

        /// <summary>
        /// gets the area or surface area of the shape
        /// </summary>
        /// <returns></returns>
        public override double CalculateArea(){
            double area = 0;
            return area;
        }

        /// <summary>
        /// gets the volume of the shape
        /// </summary>
        /// <returns></returns>
        public override double CalculateVolume()
        {
            double volume = 0;
            return volume;
        }

        /// <summary>
        /// prompts user for inpu
        /// </summary>
       public override void SetData(){
           
            Console.Write("Enter the" + valueName + ": ");
            v = Console.ReadLine();

            try
            {
                value = Convert.ToDouble(v);
            }
            catch
            {

            }
            
        }
        /// <summary>
        /// sets the name of the value being entered
        /// </summary>
        /// <param name="s"></param>

       public void valueSetter(String s)
       {
           valueName = s;
       }

        /// <summary>
        /// formats the output
        /// </summary>
        /// <returns></returns>
       public override string ToString() 
       {
           return string.Format("{0,-15} {1,-13:0.00} {2,-14:0.00} {3,-17:0.00}", Type, CalculateArea(), CalculateVolume(), value + "->" + valueName); 
       } 
    }
}
