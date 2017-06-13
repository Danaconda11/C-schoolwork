using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class _2parameters : _1parameter
    {
        protected string value2Name;
        protected double value2;
        protected string v2;

        /// <summary>
        /// prompts the user for input data
        /// </summary>
        public override void SetData()
        {
            base.SetData();

            Console.Write("Enter the" +value2Name + ": ");
            v2 = Console.ReadLine();

            try
            {
                value2= Convert.ToDouble(v2);
            }
            catch
            {

            }
        }
        /// <summary>
        /// outputs the object data into a formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,-15} {1,-13:0.00} {2,-14:0.00} {3,-17:0.00}", Type, CalculateArea(), CalculateVolume(), value + "->" + valueName + " " + value2 + "->" + value2Name);
        } 

    }
}
