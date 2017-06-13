/*
 * I Daniel Baldesarra, student 000306864, hereby certify that this is my original work which i did not make
 * available to anyone else, without due acknowledgement.
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdvancedLab5b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //the main sha-bang! and by sha-bang i mean array holding media objects
        Media[] mainMediaArray;

        public MainWindow()
        {
            InitializeComponent();
            mainMediaArray = readData();
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
                    foreach (String parsed in readerHolder.Split(new string[] { "-----" }, StringSplitOptions.RemoveEmptyEntries))
                    { //RemoveEmptyEntries clear all of the blank values in the array
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

            catch { }
            //makes the array the length of the number of objects that it's holding.
            return mediaArray;
        }

        /// <summary>
        /// when the search button is clicked, the app looks for a match
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txbSearch.Text.Trim();

            findMedia(searchQuery);
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// when the user selects a listbox item, it displays the summary
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void lbMediaItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbMediaItems.SelectedItems.Count > 0)
            {
                string[] texter = lbMediaItems.SelectedValue.ToString().Split(new Char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] holder = texter[0].Split(new string[] { "Title:" }, StringSplitOptions.RemoveEmptyEntries);

                findSummary(holder[0].ToString().Trim());
            }
        }

        /// <summary>
        /// displays all of the movies
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnMovies_Click(object sender, RoutedEventArgs e)
        {
            lbMediaItems.Items.Clear();

            foreach (Media M in mainMediaArray)
            {
                try
                {
                    if (M is Movie)
                    {
                        Movie subclassSpecificPointer = M as Movie;
                        lbMediaItems.Items.Add(
                        "Title: " + subclassSpecificPointer.Title + "\r" +
                        "Year: " + subclassSpecificPointer.Year + "\r" +
                        "Author: " + subclassSpecificPointer.Director + "\r\n");
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// finds all of the media information.
        /// </summary>
        /// <param name="tempQuery">the search string entered by the user</param>
        public void findMedia(string tempQuery)
        {

            lbMediaItems.Items.Clear();
            txbSummary.Clear();

            foreach (Media M in mainMediaArray)
            {
                try
                {
                    if (M.Search(tempQuery))
                    {
                        if (M is Book)
                        {
                            Book subclassSpecificPointer = M as Book;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Author: " + subclassSpecificPointer.Author + "\r\n");
                             txbSummary.Text = subclassSpecificPointer.Decrypt();
                            
                            break;
                        }
                        if (M is Movie)
                        {
                            Movie subclassSpecificPointer = M as Movie;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Director: " + subclassSpecificPointer.Director + "\r\n");

                                txbSummary.Text = subclassSpecificPointer.Decrypt();
                           
                            break;
                        }
                        if (M is Song)
                        {
                            Song subclassSpecificPointer = M as Song;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Artist: " + subclassSpecificPointer.Artist + "\r\n");
                            break;
                        }
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// finds the summary of whatever item was clicked on in the list view
        /// </summary>
        /// <param name="tempQuery">the title of the selected media object</param>
        public void findSummary(string tempQuery)
        {
            txbSummary.Clear();
            foreach (Media M in mainMediaArray)
            {
                try
                {
                    if (M.Search(tempQuery))
                    {
                        if (M is Book)
                        {
                            Book subclassSpecificPointer = M as Book;
                            txbSummary.Text = subclassSpecificPointer.Decrypt();

                            break;
                        }
                        if (M is Movie)
                        {
                            Movie subclassSpecificPointer = M as Movie;
                            txbSummary.Text = subclassSpecificPointer.Decrypt();
                            break;
                        }
                        if (M is Song)
                        {
                            Song subclassSpecificPointer = M as Song;
                            break;
                        }
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// displays the books
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            lbMediaItems.Items.Clear();
            txbSummary.Clear();
            foreach (Media M in mainMediaArray)
            {
                try
                {
                        if (M is Book)
                        {
                            Book subclassSpecificPointer = M as Book;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Author: " + subclassSpecificPointer.Author + "\r\n");

                            //txbSummary.Text = subclassSpecificPointer.Decrypt();
                        }
                }
                catch { }
            }
        }

        /// <summary>
        /// shows all of the media items
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnListAll_Click(object sender, RoutedEventArgs e)
        {

            lbMediaItems.Items.Clear();
            txbSummary.Clear();

            foreach (Media M in mainMediaArray)
            {
                try
                {
                    
                        if (M is Book)
                        {
                            Book subclassSpecificPointer = M as Book;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Author: " + subclassSpecificPointer.Author + "\r\n");
                        }
                        if (M is Movie)
                        {
                            Movie subclassSpecificPointer = M as Movie;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Director: " + subclassSpecificPointer.Director + "\r\n");
                        }
                        if (M is Song)
                        {
                            Song subclassSpecificPointer = M as Song;
                            lbMediaItems.Items.Add(
                            "Title: " + subclassSpecificPointer.Title + "\r" +
                            "Year: " + subclassSpecificPointer.Year + "\r" +
                            "Artist: " + subclassSpecificPointer.Artist + "\r\n");
                        }
                    }
                
                catch
                {
                    break;
                }
            }
        }

        /// <summary>
        /// shows all of the music media items
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnMusic_Click(object sender, RoutedEventArgs e)
        {
            lbMediaItems.Items.Clear();
            txbSummary.Clear();
            foreach (Media M in mainMediaArray)
            {
                try
                {
                    if (M is Song)
                    {
                        Song subclassSpecificPointer = M as Song;
                        lbMediaItems.Items.Add(
                        "Title: " + subclassSpecificPointer.Title + "\r" +
                        "Year: " + subclassSpecificPointer.Year + "\r" +
                        "Artist: " + subclassSpecificPointer.Artist + "\r\n");
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// clears the summary and list boc field
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbMediaItems.Items.Clear();
            txbSummary.Clear();
        }

        /// <summary>
        /// closes the program
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}