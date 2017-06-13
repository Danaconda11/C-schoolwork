/*
 I Daniel Baldesarra, student 000306864, hereyby certify that this is my original work which I didnt make available
 * to anyone else without due acknowledgement.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLab4
{
    class Program
    {

        static void Main(string[] args)
        {
            //create Employee list
            List<Employee> Emper = readIntoArray();
            greetingMes(Emper);
        }

        /// <summary>
        /// this method returns a list of employees
        /// </summary>
        /// <returns></returns>
        static List<Employee> readIntoArray()
        {
            string readerHolder;
            //list alternative to array
            List<Employee> Emps = new List<Employee>();

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

                        Emps.Add(new Employee(temp[0].ToString(), Convert.ToInt32(temp[1]), Convert.ToDecimal(temp[2]), Convert.ToDouble(temp[3])));
                    }
                };
            }
            catch
            {

            }
            //makes the array the length of the number of objects that it's holding.
            
            return Emps;
        }
        //END OF READINTOARRAY METHOD

        static void displayEmpArray(List<Employee> e)
        {
            Console.WriteLine("____________________________________________________________\n");
            Console.WriteLine("Employee ------- Number ----- Wage ------ Hours ------ Gross");
            Console.WriteLine("____________________________________________________________");
            foreach (Employee ob in e)
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
        /// this method prompts the user for input which will be used to sort data by various properties
        /// </summary>
        /// <param name="empLi"></param>
        static void greetingMes(List<Employee> empLi)
        {
            Console.WriteLine("Please select a sort option with which to view the employees: ");
            Console.WriteLine("1 - Name - ascending");
            Console.WriteLine("2 - Number - ascending");
            Console.WriteLine("3 - Pay rate - descending");
            Console.WriteLine("4 - Hours - descending");
            Console.WriteLine("5 - Gross - descending");
            Console.WriteLine("6 - Exit");

            try
            {
                int choice;
                Int32.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    //sort by name
                    Employee.sortOrder = Employee.SortMethod.name;
                    empLi.Sort();
                    displayEmpArray(empLi);
                    greetingMes(empLi);
                    break;
                case 2:
                    //sort by number ascending
                    Employee.sortOrder = Employee.SortMethod.number;
                    empLi.Sort();
                    displayEmpArray(empLi);
                    greetingMes(empLi);
                    break;
                case 3:
                    //sort by rate descending
                    Employee.sortOrder = Employee.SortMethod.rate;
                    empLi.Sort();
                    displayEmpArray(empLi);
                    greetingMes(empLi);
                    break;
                case 4:
                    //sort by hours descending
                    Employee.sortOrder = Employee.SortMethod.hours;
                    empLi.Sort();
                    displayEmpArray(empLi);
                    greetingMes(empLi);
                    break;
                case 5:
                    //sort gross descending
                    Employee.sortOrder = Employee.SortMethod.gross;
                    empLi.Sort();
                    displayEmpArray(empLi);
                    greetingMes(empLi);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    greetingMes(empLi);
                    break;
            }
            }
            catch
            {

            }


            
        }

    }

}
