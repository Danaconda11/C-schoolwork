/*
 I Daniel Baldesarra hereby certify that this is my original work which I did not make available to anyone else without due acknowledgment
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedLab4b
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of an HTML file");
            readHTML();
        }

        /// <summary>
        /// this method reads in the text file into one string.
        /// the one string is then parsed into what we know as individual html nodes, by use of regular expressions.
        /// the nodes then have the attributes stripped from them.
        /// the list of stripped-down nodes is the passed onto another private method
        /// </summary>
        public static void readHTML()
        { 
            Stack<String> parsed = new Stack<String>();
            string readerHolder;
            //http://stackoverflow.com/questions/787932/using-c-sharp-regular-expressions-to-remove-html-tags
            //@"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>"
            string nodeRegex = @"(?></?\w+)(?>(?:[^>'""]+|'[^']*'|""[^""]*"")*)>";
            string[] ignored = {"<br>","<hr>","<img"};

            string path = Console.ReadLine().ToLower().Trim();
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader data = new StreamReader(fs);
                    readerHolder = data.ReadToEnd();

                    foreach (Match m in Regex.Matches(readerHolder, nodeRegex))
                    {
                        if (!ignored.Contains(m.ToString()))
                        {
                            if (m.ToString().Contains(" ") && m.ToString().Contains("\""))
                            {
                                string toRemove = @"\s.+?=[""'].+?[""']";
                                string newString = Regex.Replace(m.ToString(), toRemove, string.Empty);
                                parsed.Push(newString.ToLower());
                            }
                            else
                            {
                                parsed.Push(m.ToString().ToLower());
                            }                           
                        }
                        Console.WriteLine("HTML node: " + parsed.Peek());                                      
                    } 
                }

                //start the next method
                nodeMatcher(parsed);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

        }


        /// <summary>
        /// this method receives the list from the readHTML method.
        /// the list is sorted and reversed so that the opening tags appear consecutively; half way down the list, the closing tags begin.
        /// I check the list for a value of the 0th index, with a "/" inserted into the string.
        /// if the list has a count of 0, the while loop which deletes the matches, is escaped.
        /// </summary>
        /// <param name="ss"></param>
        private static void nodeMatcher(Stack<String> ss)
        {
            List<string> collect = ss.Cast<string>().ToList();
            collect.Sort();
            collect.Reverse();

            //pesky image tag
            if (collect.Any(s => s.Contains("<img>")))
            { collect.RemoveAt(collect.IndexOf("<img>")); }

            bool flag = false;
            while(flag==false)
            {                
                //check if the list even exists
                if (collect.Count == 0)
                {
                    flag = true;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("HTML is well formed");
                    Console.ResetColor();
                    Console.ReadLine();
                }

                //once the list exists, begin manipulation.
                //I take the current value and then insert a "/" into it's copy, and then search the list for this new value.
                string closingNode = collect[0].Insert(collect[0].IndexOf("<") + 1, "/");

                //if there is an item in the list that qualifes as a closing node for the current value
                if (collect.Any(s => s.Contains(closingNode)))
                {
                    //return the index of where the opening node is found in the list
                    int tempOpeningNodeKey = collect.IndexOf(collect[0].ToString());
                    //return the index in the list where closing node is found
                    int tempClosingNodeKey = collect.IndexOf(closingNode) - 1;
                    //delete the indexes so we can keep searching for new values
                    collect.RemoveAt(tempOpeningNodeKey);
                    collect.RemoveAt(tempClosingNodeKey);
                }
                else
                {
                    flag = true;
                }
            }

            //if the array has any unmatched items
            if(collect.Count > 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("HTML is not well formed");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
