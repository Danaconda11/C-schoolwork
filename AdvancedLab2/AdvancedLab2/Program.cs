/*
 * I, Daniel Baldesarra, student number 000306864m, hereby certify that this is my original work which I did
 * not make available to anyone else without due acknowledgement. 
 * 
 * Jachery Jerome and I collaborated on this one, with regard to the 2nd level of abstraction which follows the premise of classes based on the number of parameters required as the shape's input data.
 * 
 * Good times.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AdvancedLab2
{
    class Program
    {
       static int counter = 0;

        static void Main(string[] args)
        {
            //holds muh shapes!
            Shape[] ShapeArray = new Shape[99];
            buildShape(ref ShapeArray);            
        }

        /// <summary>
        /// Prints the main menu options
        /// </summary>
        static void printMenu()
        {
            Console.Clear();

            Console.WriteLine("Select a shape to build");
            Console.WriteLine("__________________________________________");
            Console.Write(String.Format("{0,-15}", "1 - Rectangle"));
            Console.Write(String.Format("{0,-15}", "2 - Square"));
            Console.Write(String.Format("{0,-15}", "3 - Box"));
            Console.WriteLine("");
            Console.Write(String.Format("{0,-15}", "4 - Cube"));
            Console.Write(String.Format("{0,-15}", "5 - Ellipse"));
            Console.Write(String.Format("{0,-15}", "6 - Circle"));
            Console.WriteLine("");
            Console.Write(String.Format("{0,-15}", "7 - Cylinder"));
            Console.Write(String.Format("{0,-15}", "8 - Sphere"));
            Console.Write(String.Format("{0,-15}", "9 - Triangle"));
            Console.WriteLine("");
            Console.Write(String.Format("{0,-15}", "10 - Tetrahedron"));
            Console.Write(String.Format("{0,-15}", "        0 - Display then Exit       "));

            //shows the count of all of the shape object in the project
            Console.WriteLine("(" + Shape.GetCount() + " shapes in existance)");

            Console.WriteLine("");
            Console.WriteLine("");
        }

        /// <summary>
        /// outputs the requested data
        /// </summary>
        /// <param name="ShapeArray"></param>
        static void printShapes(ref Shape[] ShapeArray)
        {
            Console.Clear();
            Array.Resize(ref ShapeArray, counter);
            Console.WriteLine("Shape            Area          Volume                Details");
            Console.WriteLine("________________________________________________________________________________");
            foreach (Shape s in ShapeArray)
            {
               Console.WriteLine( s.ToString());
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        
        /// <summary>
        /// creates a shape object and puts it into ana array
        /// </summary>
        /// <param name="ShapeArray"></param>
        static void buildShape(ref Shape[] ShapeArray)
        {
            printMenu();

            Console.WriteLine("Please pick a listed option");
            switch (Console.ReadLine())
            {
                case "0":
                    printShapes(ref ShapeArray);
                    Environment.Exit(0);
                    break;
                case "1":
                    Rectangle Rec = new Rectangle();
                    Rec.SetData();
                    ShapeArray[counter++] = Rec;
                    buildShape(ref ShapeArray);
                    break;
                case "2":
                    Square Sq = new Square();
                    Sq.SetData();
                    ShapeArray[counter++] = Sq;
                    buildShape(ref ShapeArray);
                    break;
                case "3":
                    Box Bawx = new Box();
                    Bawx.SetData();
                    ShapeArray[counter++] = Bawx;
                    buildShape(ref ShapeArray);
                    break;
                case "4":
                    Cube Qoob = new Cube();
                    Qoob.SetData();
                    ShapeArray[counter++] = Qoob;
                    buildShape(ref ShapeArray);
                    break;
                case "5":
                    Ellipse E_lips = new Ellipse();
                    E_lips.SetData();
                    ShapeArray[counter++] = E_lips;
                    buildShape(ref ShapeArray);
                    break;
                case "6":
                    Circle Sircle = new Circle();
                    Sircle.SetData();
                    ShapeArray[counter++] = Sircle;
                    buildShape(ref ShapeArray);
                    break;
                case "7":
                    Cylinder Sillinder = new Cylinder();
                    Sillinder.SetData();
                    ShapeArray[counter++] = Sillinder;
                    buildShape(ref ShapeArray);
                    break;
                case "8":
                    Sphere Sfeer = new Sphere();
                    Sfeer.SetData();
                    ShapeArray[counter++] = Sfeer;
                    buildShape(ref ShapeArray);
                    break;
                case "9":
                    Triangle TryAngle = new Triangle();
                    TryAngle.SetData();
                    ShapeArray[counter++] = TryAngle;
                    buildShape(ref ShapeArray);
                    break;
                case "10":
                    Tetrahedron TH = new Tetrahedron();
                    TH.SetData();
                    ShapeArray[counter++] = TH;
                    buildShape(ref ShapeArray);
                    break;
                default:
                    buildShape(ref ShapeArray);
                    break;
            }
        }

    }
}
