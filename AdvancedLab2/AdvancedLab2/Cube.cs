using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab2
{
    class Cube : _1parameter
    {
       
        /// <summary>
        /// surface area for a cube
        /// </summary>
        /// <returns></returns>
        override public double CalculateArea()
        {
            double area = 6 * Math.Pow(value, 2);
            return area;
        }
        /// <summary>
        /// get volume for a cube
        /// </summary>
        /// <returns></returns>
        override public double CalculateVolume()
        {
            double volume = Math.Pow(value, 3);
            return volume;
        }

        public Cube()
            : base()
        {
            Type = "Cube";
        }

        /// <summary>
        /// prompts user for input data
        /// </summary>
        public override void SetData()
        {
            base.valueName = " radius";
            base.SetData();
        }
        /// <summary>
        /// outputs object data in formatted string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
           return base.ToString();
        }
    }
}
