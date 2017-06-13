using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Tetrahedron : _1parameter
    {

        public Tetrahedron()
            : base()
        {
            Type = "Tetrahedron";
        }
        /// <summary>
        /// gets surface area of tetrahedron
        /// </summary>
        /// <returns></returns>
        override public double CalculateArea()
        {
            double area = Math.Sqrt(3) * Math.Pow(value, 2);
            return area;
        }
        /// <summary>
        /// gets volume of tetrahedron
        /// </summary>
        /// <returns></returns>
        override public double CalculateVolume()
        {
            double volume = Math.Pow(value,3) / (6 * Math.Sqrt(2));
            return volume;
        }
        /// <summary>
        /// prompts user for input data
        /// </summary>
        override public void SetData()
        {
            base.valueName = " base";
            base.SetData();
        }
        /// <summary>
        /// outputs object data into formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
