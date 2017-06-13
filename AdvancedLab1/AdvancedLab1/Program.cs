using AdvancedLab1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//I, Daniel Baldesarra, 306864 certify that this material is my original work. 
//No other person's work has been used without due acknowledgement.

namespace AdvancedLab1
{
    class Program
    {
        static void Main(string[] args)
        {
          Employee[] mainEmpArray = readIntoArray();
          greetingMes(mainEmpArray); 
        }

        /// <summary>
        /// takes csv data, parses into an array of employee objects
        /// </summary>
        static Employee[] readIntoArray()
        {
            string readerHolder;
            Employee[] empObjArray = new Employee[99];
            int counter = 0;
            string path = "empCSV.txt";
            //opens file
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    //reads the opened file
                    StreamReader data = new StreamReader(fs);
                    //this prevents the reader from chopping off the first character from each line
                    while (!data.EndOfStream)
                    {
                        readerHolder = data.ReadLine();
                        string[] temp = readerHolder.Split(',');
                        //not very human readable, I know, but it's succinct!
                        Employee Emp = new Employee(temp[0].ToString(), Convert.ToInt32(temp[1]), Convert.ToDecimal(temp[2]),Convert.ToDouble(temp[3]));                                                    
                        //calculates gross pay
                        Emp.getGross();                        
                        empObjArray[counter] = Emp;
                        counter++;
                    }
                };                
            }
            catch
            {

            }
            //makes the array the length of the number of objects that it's holding.
            Array.Resize(ref empObjArray, counter);
            return empObjArray;
        }
        //END OF READINTOARRAY METHOD

        /// <summary>
        /// outputs the data in a formatted table
        /// </summary>
        /// <param name="o"></param>
        static void displayEmpArray(Object[] o)
        {
            Console.WriteLine("____________________________________________________________\n");
            Console.WriteLine("Employee ------- Number ----- Wage ------ Hours ------ Gross");
            Console.WriteLine("____________________________________________________________");
            foreach (Employee ob in o)
            {
                if (ob != null)
                {
                    ob.printEmployee();
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Show's sort options, accepts input to select sort method
        /// </summary>
        /// <param name="empAr"></param>
        static void greetingMes(Employee[] empAr)
        {
            Console.WriteLine("Please select a sort option with which to view the employees: ");
            Console.WriteLine("1 - Name - ascending");
            Console.WriteLine("2 - Number - ascending");
            Console.WriteLine("3 - Pay rate - descending");
            Console.WriteLine("4 - Hours - descending");
            Console.WriteLine("5 - Gross - descending");
            Console.WriteLine("6 - Exit");

            //accepts user input, and trims it
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    //sort by name
                    Quicksort(ref empAr,0,empAr.Length - 1);
                    displayEmpArray(empAr);
                    greetingMes(empAr);
                    break;
                case "2":
                    //sort by number ascending
                    QuicksortNumAsc(ref empAr,0,empAr.Length - 1);
                    displayEmpArray(empAr);
                    greetingMes(empAr);
                    break;
                case "3":
                    //sort by rate descending
                    QuicksortPayDsc(ref empAr, 0, empAr.Length - 1);
                    displayEmpArray(empAr);
                    greetingMes(empAr);
                    break;
                case "4":
                    //sort by hours descending
                    QuicksortHoursDsc(ref empAr, 0, empAr.Length - 1);
                    displayEmpArray(empAr);
                    greetingMes(empAr);
                    break;
                case "5":
                    //sort gross descending
                    QuicksortGrossDsc(ref empAr, 0, empAr.Length - 1);
                    displayEmpArray(empAr);
                    greetingMes(empAr);
                    break;
                default:
                    greetingMes(empAr);
                    break;
            }
        }

        //http://snipd.net/quicksort-in-c

        /// <summary>
        /// quicksorting name ascending order
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void Quicksort(ref Employee[] elements, int left, int right)
        {
            int i = left, j = right;
            Employee pivot = elements[(left + right) / 2];
 
            while (i <= j)
            {
                while (String.Compare(elements[i].getName(), pivot.getName()) < 0)
                {
                    i++;
                }

                while (String.Compare(elements[j].getName(), pivot.getName()) > 0)
                {
                    j--;
                }
 
                if (i <= j)
                {
                    // Swap
                    Employee tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;
 
                    i++;
                    j--;
                }
            }
 
            // Recursive calls
            if (left < j)
            {
                Quicksort(ref elements, left, j);
            }
 
            if (i < right)
            {
                Quicksort(ref elements, i, right);
            }
        }

        /// <summary>
        /// quicksorting employee number in ascending order
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuicksortNumAsc(ref Employee[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2].getNumber();

            while (i <= j)
            {
                while ( elements[i].getNumber() < pivot)
                {
                    i++;
                }

                while ( elements[j].getNumber() > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Employee tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortNumAsc(ref elements, left, j);
            }

            if (i < right)
            {
                QuicksortNumAsc(ref elements, i, right);
            }
        }

        /// <summary>
        /// quicksorting rate in descending order
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuicksortPayDsc(ref Employee[] elements, int left, int right)
        {
            int i = left, j = right;
            decimal pivot = elements[(left + right) / 2].getRate();

            while (i <= j)
            {
                while ( elements[i].getRate() > pivot)
                {
                    i++;
                }

                while ( elements[j].getRate() < pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Employee tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortPayDsc(ref elements, left, j);
            }

            if (i < right)
            {
                QuicksortPayDsc(ref elements, i, right);
            }
        }

        /// <summary>
        /// quicksorting hours worked descending
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuicksortHoursDsc(ref Employee[] elements, int left, int right)
        {
            int i = left, j = right;
            double pivot = elements[(left + right) / 2].getHours();

            while (i <= j)
            {
                while (elements[i].getHours() > pivot)
                {
                    i++;
                }

                while (elements[j].getHours() < pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Employee tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortHoursDsc(ref elements, left, j);
            }

            if (i < right)
            {
                QuicksortHoursDsc(ref elements, i, right);
            }
        }

        /// <summary>
        /// quicksort gross value descending
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuicksortGrossDsc(ref Employee[] elements, int left, int right)
        {
            int i = left, j = right;
            decimal pivot = elements[(left + right) / 2].retreiveGross();

            while (i <= j)
            {
                while (elements[i].retreiveGross() > pivot)
                {
                    i++;
                }

                while (elements[j].retreiveGross() < pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    Employee tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                QuicksortGrossDsc(ref elements, left, j);
            }

            if (i < right)
            {
                QuicksortGrossDsc(ref elements, i, right);
            }
        }

        
    }

    }


