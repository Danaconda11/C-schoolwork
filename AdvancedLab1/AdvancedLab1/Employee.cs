using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab1
{
    class Employee
    {
        string name;
        Int32 number;
        decimal rate;
        double hours;
        decimal gross;

        /// <summary>
        /// Constructor 1, accepts no arguments
        /// </summary>
        public Employee()
        {
            name = "";
            number = 0;
            rate = 0;
            hours = 0;
            gross = 0;
        }

        /// <summary>
        /// Constructor 2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="num"></param>
        /// <param name="r"></param>
        /// <param name="h"></param>
        public Employee(string n, Int32 num, decimal r, double h)
        {
            name = n;
            number = num;
            rate = r;
            hours = h;
        }

        /// <summary>
        /// Prints all of the data contained within the object properties
        /// </summary>
        public void printEmployee()
        {
            Console.WriteLine( String.Format("{0,-15}",this.name) + 
                " " + String.Format("{0,7}",this.number) + 
                " " + String.Format("{0,11:C}",this.rate) + 
                " " + String.Format("{0,11}",this.hours) + 
                " " + String.Format("{0,12:c}",this.gross));
        }

        /// <summary>
        /// calculates the gross pay of employee
        /// </summary>
        /// <returns>decimal value</returns>
        public void getGross()
        {
            const double hourLimit = 40;
            const decimal timeAndAHalf = 1.5m;
            decimal oT = ((decimal)this.getHours() - (decimal)hourLimit);

            if (oT > 0)
            {
                this.gross = ((decimal)this.getHours() * this.getRate()) + (oT * timeAndAHalf);
            }
            else
            {
                this.gross = (decimal)this.getHours() * this.getRate();
            }

        }

        public decimal retreiveGross()
        {
            return gross;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string s)
        {
            this.name = s;
        }

        public Int32 getNumber()
        {
            return number;
        }

        public void setNumber(Int32 n)
        {
            this.number = n;
        }

        public decimal getRate()
        {
            return this.rate;
        }

        public void setRate(Int32 n)
        {
            this.number = n;
        }

        public double getHours()
        {
            return this.hours;
        }

        public void setHours(double h)
        {
            this.hours = h;
        }
    }
}
