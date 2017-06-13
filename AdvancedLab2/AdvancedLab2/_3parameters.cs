using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class _3parameters : _2parameters
    {
        protected string value3Name;
        protected double value3;
        protected string v3;

        /// <summary>
        /// prompts the user for input data
        /// </summary>
        public override void SetData()
        {
            base.SetData();

            Console.Write("Enter the" + value3Name + ": ");
            v3 = Console.ReadLine();

            try
            {
                value3 = Convert.ToDouble(v3);
            }
            catch
            {

            }
        }
        /// <summary>
        /// outputs object data into a formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0,-15} {1,-13:0.00} {2,-14:0.00} {3,-17:0.00}", Type, CalculateArea(), CalculateVolume() + " ", value + "->" + valueName + " " + value2 + "->" + value2Name + " " + value3 + "->" + value3Name);
        } 
    }
}
