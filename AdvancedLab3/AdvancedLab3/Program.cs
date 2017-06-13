/*
 I, Daniel Baldesarra, student 000306864, certify that this is my original work which I did not make available to anyone else.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedLab3
{
    class Program
    {
        static void Main(string[] args)
        {
           Media[] mainMediaArray = readData();
           mainMenu(ref mainMediaArray);
          
        }

        /// <summary>
        /// this function returns a media object array
        /// </summary>
        /// <returns>Media object array</returns>
        static Media[] readData()
        {
            Media[] mediaArray = new Media[99];
            int counter = 0;
            string path = "Lab3Data.txt";
            //opens file
            try
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    //reads the opened file
                    StreamReader data = new StreamReader(fs);
                   
                      /*Rather than use a while loop to go through all of the content in the .txt file, i read the entire thing into one string.
                      * Once i have the entire thing into one string, i parse it on the '-----' pattern, to get all of the data for a single media
                      * item.
                      * */
                   string readerHolder = data.ReadToEnd();          
        
                    //this replaces the while loop; the next iteration begins by parsing what i asked it to.
                    foreach(String parsed in readerHolder.Split(new string[]{"-----"},StringSplitOptions.RemoveEmptyEntries)){ //RemoveEmptyEntries clear all of the blank values in the array
                        String[] IndiviualMediaParams = parsed.Split(new Char[] { '|', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);  
                            switch (IndiviualMediaParams[0])
                                {
                                    case "BOOK":
                                        Book book = new Book(
                                            IndiviualMediaParams[1],                        //title
                                            Convert.ToInt32(IndiviualMediaParams[2]),       //year
                                            IndiviualMediaParams[3],                        //author
                                            IndiviualMediaParams[4]                         //summary
                                            );                                        
                                        mediaArray[counter] = book; //add to media array
                                    break;
                                    case "MOVIE":
                                        Movie movie = new Movie(
                                             IndiviualMediaParams[1],                       //title
                                             Convert.ToInt32(IndiviualMediaParams[2]),      //year
                                             IndiviualMediaParams[3],                       //director
                                             IndiviualMediaParams[4]                        //summary
                                             );                                 
                                        mediaArray[counter] = movie; //add to media array
                                    break;
                                    case "SONG":
                                        Song song = new Song(
                                             IndiviualMediaParams[1],                       //title
                                             Convert.ToInt32(IndiviualMediaParams[2]),      //year
                                             IndiviualMediaParams[3],                       //album
                                             IndiviualMediaParams[4]                        //artist
                                             );                                       
                                        mediaArray[counter] = song; //add to media array
                                    break;                            
                                }
                        counter++;
                    }

                    }
                }
            
            catch{}
            //makes the array the length of the number of objects that it's holding.
            return mediaArray;
        }

        /// <summary>
        /// selects which media items to display (class type) based on user input
        /// </summary>
        /// <param name="mainMediaArray"></param>
        static void mainMenu(ref Media[] mainMediaArray)
        {
            Console.WriteLine();
            Console.WriteLine("1 - List all Books");
            Console.WriteLine("2 - List all Movies");
            Console.WriteLine("3 - List all Songs");
            Console.WriteLine("4 - List all Media");
            Console.WriteLine("5 - Search all media by title");
            Console.WriteLine("6 - Exit");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("Select an option: ");
            switch(Console.ReadLine()){
                    
                case "1"://show book objects
                    Console.WriteLine();
                    Console.WriteLine("*BOOKS*");
                    Console.WriteLine("---------------------------------------------------------------");
                    foreach(Media M in mainMediaArray){
                        if (M is Book)
                        {
                            //once I confirm that the object im pointing at has a subclass of BOOK, then i reference like a BOOK
                            Book subclassSpecificPointer = M as Book;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Author);
                        }
                    }
                    //back to main menu
                    mainMenu(ref mainMediaArray);
                    break;
                case "2": //show movie objects
                    Console.WriteLine();
                    Console.WriteLine("*MOVIES*");
                    Console.WriteLine("---------------------------------------------------------------");
                    foreach(Media M in mainMediaArray){
                        if (M is Movie)
                        {
                            Movie subclassSpecificPointer = M as Movie;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Director);
                        }
                    }
                    mainMenu(ref mainMediaArray);
                    break;
                case "3": //show song objects
                    Console.WriteLine();
                    Console.WriteLine("*SONGS*");
                    Console.WriteLine("---------------------------------------------------------------");
                    foreach(Media M in mainMediaArray){
                        if (M is Song)
                        {
                            Song subclassSpecificPointer = M as Song;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Artist + " | " + subclassSpecificPointer.Album);
                        }
                    }
                    mainMenu(ref mainMediaArray);
                    break;
                case "4": //show all media objects
                    Console.WriteLine();
                    Console.WriteLine("*ALL MEDIA*");
                    Console.WriteLine("---------------------------------------------------------------");
                    foreach (Media M in mainMediaArray)
                    {
                        if (M is Song)
                        {
                            Song subclassSpecificPointer = M as Song;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Artist + " | " + subclassSpecificPointer.Album);
                        }
                        else if (M is Book)
                        {
                            Book subclassSpecificPointer = M as Book;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Author);
                        }else if (M is Movie)
                        {
                            Movie subclassSpecificPointer = M as Movie;
                            Console.WriteLine(subclassSpecificPointer.Title + " | " + subclassSpecificPointer.Year + " | " + subclassSpecificPointer.Director);
                        }
                    }
                    mainMenu(ref mainMediaArray);
                    break;
                case "5":
                    Console.WriteLine("Input the name of the title: ");
                    string searchQuery = Console.ReadLine().Trim().ToLower();

                    foreach (Media M in mainMediaArray){

                        try
                        {
                            if(M.Search(searchQuery)){
                            if (M is Book)
                                {
                                    Book subclassSpecificPointer = M as Book;
                                    Console.WriteLine("Title: " + subclassSpecificPointer.Title);
                                    Console.WriteLine("Year: " + subclassSpecificPointer.Year); 
                                    Console.WriteLine("Author: " + subclassSpecificPointer.Author);
                                    Console.WriteLine("Summary: " + subclassSpecificPointer.Decrypt());
                                    mainMenu(ref mainMediaArray);
                                    break;                                    
                                }
                                if (M is Movie)
                                {
                                    Movie subclassSpecificPointer = M as Movie;
                                    Console.WriteLine("Title: " + subclassSpecificPointer.Title);
                                    Console.WriteLine("Year: " + subclassSpecificPointer.Year);
                                    Console.WriteLine("Directory: " + subclassSpecificPointer.Director);
                                    Console.WriteLine("Summary: " + subclassSpecificPointer.Decrypt());
                                    mainMenu(ref mainMediaArray);
                                    break;                                   
                                }
                                if (M is Song)
                                {
                                    Song subclassSpecificPointer = M as Song;
                                    Console.WriteLine("Title: " + subclassSpecificPointer.Title);
                                    Console.WriteLine("Year: " + subclassSpecificPointer.Year);
                                    Console.WriteLine("Album: " + subclassSpecificPointer.Album);
                                    Console.WriteLine("Artist: " + subclassSpecificPointer.Artist);
                                    mainMenu(ref mainMediaArray);
                                    break;
                                }
                             }
                        }
                        catch
                        {
                             Console.WriteLine("\n");
                             Console.WriteLine("Media was not found");
                             mainMenu(ref mainMediaArray);
                             break;
                        }              
                    }

                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    mainMenu(ref mainMediaArray);
                break;
            }
            
        }

    }
}
