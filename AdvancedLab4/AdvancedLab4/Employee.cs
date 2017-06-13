/*
 I Daniel Baldesarra student number 003006864 hereby certify that this is my original work which I didnt make available
 * to anyon else without due acknowledgment
 */


//https://codebetter.com/davidhayden/2005/02/27/implementing-icomparable-for-sorting-custom-objects/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab4
{
    class Employee : IComparable
    {

        public Employee(String name, int number, decimal rate, double hours)
        {
            this.name = name;
            this.number = number;
            this.rate = rate;
            this.hours = hours;

            decimal tempVal;
            const double hourLimit = 40;
            const decimal timeAndAHalf = 1.5m;
            decimal oT = ((decimal)hours - (decimal)hourLimit);

            if (oT > 0)
            {
                tempVal = ((decimal)hours * rate) + (oT * timeAndAHalf);
            }
            else
            {
                tempVal = (decimal)hours * rate;
            }

            gross = tempVal; 
        }

        public int number { get ; set ; }
        public string name { get ; set ; }
        public decimal rate { get; set ; }
        public double hours { get; set ; }
        public decimal gross { get; set; }
        public enum SortMethod { name = 1, number = 2, rate = 3, hours = 4, gross = 5 };
        public static SortMethod sortOrder;


        /// <summary>
        /// the compare to method which satisfies the Icompareable interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Employee obj)
        {
            Employee e1 = obj;
            switch (sortOrder)
            {
                case SortMethod.rate:
                    return e1.rate.CompareTo(rate);
                case SortMethod.hours:
                    return e1.hours.CompareTo(hours);
                case SortMethod.gross:
                    return e1.gross.CompareTo(gross);
                case SortMethod.number:
                    return number.CompareTo(e1.number);
                case SortMethod.name:
                default:
                    return name.CompareTo(e1.name);
            }
        }

        /// <summary>
        /// Prints all of the data contained within the object properties
        /// </summary>
        public void printEmployee()
        {
            Console.WriteLine(String.Format("{0,-15}", name) +
                " " + String.Format("{0,7}", number) +
                " " + String.Format("{0,11:C}", rate) +
                " " + String.Format("{0,11}", hours) +
                " " + String.Format("{0,12:c}", gross));
        }        
    }
}
