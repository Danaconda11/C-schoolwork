
/*
 * I Daniel Baldesarra, student 000306864, hereby certify that this is my original work which i did not make
 * available to anyone else, without due acknowledgement. Sahil Gupta and I discussed the logic for some parts of this lab.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedLab5a
{
    public partial class Form1 : Form
    {

        private Graphics grafix;
        private Pen pen;
        private Boolean timer = true;
        private SolidBrush brush;
        private Color colorWhite = Color.White;
        private Color colorBlue = Color.Blue;

        public Form1()
        {
            InitializeComponent();
            //the paint property accumulates new even handlers
            this.Paint += new PaintEventHandler(painter);
        }

        /// <summary>
        /// paints the container which holds the liquid of questionable origins
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        public void painter(object sender, PaintEventArgs e)
        {
            grafix = e.Graphics;
            pen = new Pen(colorWhite);
            brush = new SolidBrush(colorBlue);
            //allows the form to have graphics capabilities
            grafix = this.CreateGraphics();
            //creating the bucket when the program executes
            grafix.DrawLine(pen, 45, 270, 45, 450);     //left
            grafix.DrawLine(pen, 45, 450, 170, 450);    //bottom
            grafix.DrawLine(pen, 170, 450, 170, 290);   //right
        }

        private void btnBail_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// shows a dialog box to pick a color
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e"></param>
        private void btnLiquidColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colorBlue = colorDialog1.Color;
        }

        /// <summary>
        /// sets the speed at which the water pours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            {
                //starts the timer which will dictate the water pouring
                waterTimer.Enabled = true;

                brush = new SolidBrush(colorBlue);
                grafix = this.CreateGraphics();

                //if there is speed to the water flowing then stop the water timer
                if (trackBar1.Value == 0)
                {
                    waterTimer.Stop();
                    timer = true;
                }
                else
                {
                    if (timer)
                    {
                        waterTimer.Start();
                        waterTimer.Tick += new System.EventHandler(filler);
                        timer = false;
                    }

                    //as the value of the track bar increases, so does the rate of change
                    waterTimer.Interval = 400 / trackBar1.Value;
                }
            }

        }

        //the delta by which the water changes
        int i = 3;

        public void filler(object sender, EventArgs e)
        {
            Rectangle stream;

            //if the water has filled up to a certain point
            if (i > 150)
            {
                //stop the timer
                waterTimer.Stop();
                //set the water speed to 0
                trackBar1.Value = 0;
                brush = new SolidBrush(Color.Black);
                stream = new Rectangle(65, 250, 25, 201  - i + 1);
            }
            else
            {
                //the logic for if thw water is falling out of the tap
                stream = new Rectangle(65, 278, 25, 174 - i);

                Rectangle water = new Rectangle(46, 451 - i, 123, 2);
                grafix.FillRectangle(brush, water);
                i += 1;
            }
            grafix.FillRectangle(brush, stream);
        }

    }


}
