using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //DDA line Algorithm.......
        private void button1_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            

            panel1.Controls.Clear();
            if (x1 < 347)
            {
                Point p1 = new Point(x1, y1);
                Point p2 = new Point(x2, y2);


                ddaline(p1, p2);
            }
            else
            {
                Application.Exit();
                Console.WriteLine("X1 can't be more than 347 pixels");
            }

        }


        void ddaline(Point Start, Point End)
        {
            
            int k = 0;
            double xinc, yinc, x, x1, y, y1, steps;

            var aBrush = Brushes.Blue;
            var g = panel1.CreateGraphics();
            double deltax = End.X - Start.X;
            double deltay = End.Y - Start.Y;
            double Angle = Math.Atan2(deltay, deltax) * (180 / Math.PI);

            if (deltax > deltay)
            {
                steps = deltax;

            }
            else
            {
                steps = deltay;
            }

            xinc = deltax / steps;
            yinc = deltay / steps;
            x = x1 = Start.X;
            y = y1 = Start.Y;
            //dataGridView1.Rows.Clear();
            DataTable table = new DataTable();
            table.Columns.Add("X Rounded", typeof(int));
            table.Columns.Add("Y Rounded", typeof(int));
            

            for (k = 1; k <= steps; k++)
            {

                x = x + xinc;
               // x = Math.Round(x, 0);
                y = y + yinc;
              //  y = Math.Round(y, 0);
                table.Rows.Add(Math.Round(x), Math.Round(y));
                dataGridView1.DataSource = table;
                g.FillRectangle(aBrush, (int)(x + 347.5), (int)(323 - y), 2, 2);

            }

        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Panel............
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.Clear(Color.White);
            Pen blackpen = new Pen(aBrush, 2);
            g.DrawLine(blackpen, 347, 0, 347, 646);
            g.DrawLine(blackpen, 0, 323, 695, 323);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // clear ........
        private void button2_Click(object sender, EventArgs e)
        {

            var g = panel1.CreateGraphics();
            g.Clear(Color.White);
            var aBrush = Brushes.Black;
            Pen blackpen = new Pen(aBrush, 2);
            g.DrawLine(blackpen, 347, 0, 347, 646);
            g.DrawLine(blackpen, 0, 323, 695, 323);
        }

       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        // Bresnham Algorithm...........
        private void button5_Click(object sender, EventArgs e)
        {

            int x1 = Convert.ToInt32(textBox12.Text);
            int x2 = Convert.ToInt32(textBox11.Text);
            int y1 = Convert.ToInt32(textBox10.Text);
            int y2 = Convert.ToInt32(textBox9.Text);

            panel1.Controls.Clear();
            if (x1 < 347)
            {
                Point p1 = new Point(x1, y1);
                Point p2 = new Point(x2, y2);


                Bresenham_Line(p1, p2);
            }
            else
            {
                Application.Exit();
                Console.WriteLine("X1 can't be more than 347 pixels");
            }

            void eighth_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.Y - p1.Y);
                int dx = Math.Abs(p2.X - p1.X);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (x <= p2.X)
                {
                    x++;
                    if (pk > 0)
                    {
                        y--;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    k++;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                }
            }

            void seventh_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.X - p1.X);
                int dx = Math.Abs(p2.Y - p1.Y);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (y >= p2.Y)
                {
                    y--;
                    if (pk > 0)
                    {
                        x++;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }

            void sixth_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));
                
                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.X - p1.X);
                int dx = Math.Abs(p2.Y - p1.Y);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (y >= p2.Y)
                {
                    y--;
                    if (pk > 0)
                    {
                        x--;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }

            void fifth_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.Y - p1.Y);
                int dx = Math.Abs(p2.X - p1.X);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (x >= p2.X)
                {
                    x--;
                    if (pk > 0)
                    {
                        y--;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }


            void fourth_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.Y - p1.Y);
                int dx = Math.Abs(p2.X - p1.X);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (x >= p2.X)
                {
                    x--;
                    if (pk > 0)
                    {
                        y++;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }
            void third_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.X - p1.X);
                int dx = Math.Abs(p2.Y - p1.Y);

                int pk = (2 * dy) - dx;

                //Console.WriteLine("dx is " + dx + " dy is " + dy + " pk is " + pk);

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (y <= p2.Y)
                {
                    y++;
                    if (pk > 0)
                    {
                        x--;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                        /* x--;
                         g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                         pk += TwoDeltaYx;
                        */
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                        /*g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                        pk += TwoDeltay;
                          */
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }
            void Second_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = Math.Abs(p2.X - p1.X);
                int dx = Math.Abs(p2.Y - p1.Y);

                int pk = (2 * dy) - dx;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                int k = 0;
                while (y <= p2.Y)
                {
                    y++;
                    if (pk > 0)
                    {
                        x++;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }
            void first_oct(Point p1, Point p2)
            {
                DataTable table = new DataTable();
                table.Columns.Add("K", typeof(int));
                table.Columns.Add("pk", typeof(int));
                table.Columns.Add("X", typeof(double));
                table.Columns.Add("Y", typeof(double));

                var g = panel1.CreateGraphics();
                var color = Brushes.Blue;


                int x = p1.X;
                int y = p1.Y;

                int dy = (p2.Y - p1.Y);
                int dx = (p2.X - p1.X);

                int pk = (2 * dy) - dx;
               // int Po = (2 * dy) - dx, pk;

                int TwoDeltay = (2 * dy);
                int TwoDeltaYx = (2 * dy) - (2 * dx);

                // pk = Po;
               /* if (pk > 0)
                {
                    table.Rows.Add(0, pk, x + 1, y + 1);
                    y++;
                }
                else
                {
                    table.Rows.Add(0, pk, x + 1, y);
                }
                x++;
               */
                int k = 0;
                while (x <= p2.X)
                {
                    x++;
                    if (pk > 0)
                    {
                        y++;
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltaYx;
                    }
                    else
                    {
                        table.Rows.Add(k, pk, x, y);
                        pk += TwoDeltay;
                    }
                    dataGridView1.DataSource = table;
                    g.FillRectangle(color, (panel1.Width / 2) + x, (panel1.Height / 2) - y, 1, 1);
                    k++;
                }
            }
            void Bresenham_Line(Point p1, Point p2)
            {
                //CLEAR();
                // int Po, TwoDeltay, TwoDeltaYx, dx, dy, x, y, pk;
                float m;


                m = ((float)p2.Y - (float)p1.Y) / ((float)p2.X - (float)p1.X);
                if (m > 0 && m < 1)
                {

                    if (p2.Y - p1.Y <= 0 && p2.X - p1.X <= 0)
                    {
                        fifth_oct(p1, p2);
                        MessageBox.Show("Fifth Octant");
                    }
                    if (p2.Y - p1.Y > 0 && p2.X - p1.X > 0)
                    {
                        first_oct(p1, p2);
                        MessageBox.Show("first Octant");
                    }
                }
                else if (m > 1)
                {
                    if (p2.Y - p1.Y <= 0 && p2.X - p1.X <= 0)
                    {
                        sixth_oct(p1, p2);
                        MessageBox.Show("Sixth Octant");
                    }
                    if (p2.Y - p1.Y > 0 && p2.X - p1.X > 0)
                    {
                        Second_oct(p1, p2);
                        MessageBox.Show("Second Octant");
                    }
                }
                else if (m < -1)
                {
                    if (p2.Y - p1.Y > 0)
                    {
                        third_oct(p1, p2);
                        MessageBox.Show("Third Octant");
                    }
                    else
                    {
                        seventh_oct(p1, p2);
                        MessageBox.Show("Seventh Octant");
                    }
                }
                else if (m < 0 && m > -1)
                {
                    if (p2.Y - p1.Y > 0)
                    {
                        fourth_oct(p1, p2);
                        MessageBox.Show("fourth Octant");
                    }
                    else
                    {
                        eighth_oct(p1, p2);
                        MessageBox.Show("eighth Octant");
                    }
                }

            }

            /* void Bresenhamdraw(Point p1, Point p2)
             {
                 double dx, dy;
                 int tempx, tempy;
                 if (p2.X < 0)
                 {
                     if (p2.Y < 0)
                     {
                         tempy = p2.Y;
                         p2.Y = p1.Y;
                         p1.Y = tempy;
                     }
                     tempx = p2.X;
                     p2.X = p1.X;
                     p1.X = tempx;
                 }
                 if (p2.Y < 0)
                 {
                     tempy = p1.Y;
                     p1.Y = p2.Y;
                     p2.Y = tempy;
                 }

                 var aBrush = Brushes.Red;
                 var g = panel1.CreateGraphics();
                 dx = p2.X - p1.X;
                 dy = p2.Y - p1.Y;


                 double p = (2 * dy) - dx;

                 double x = p1.X;
                 double y = p1.Y;
                 double X2 = p2.X;
                 double Y2 = p2.Y;
                 while (x < X2)
                 {
                     if (p < 0)
                     {
                         x++;
                         p = p + 2 * (dy);

                     }
                     else
                     {
                         x++;
                         y++;
                         p = p + (2 * (dy) - 2 * (dx));

                     }
                     g.FillRectangle(aBrush, (int)(x + 347.5), (int)(323 - y), 2, 2);
                 }


             }*/
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        //Circle Algorithm......
        private void button6_Click(object sender, EventArgs e)
        {

            int Xc = Convert.ToInt32(textBox15.Text);
            int Yc = Convert.ToInt32(textBox16.Text);
            int r = Convert.ToInt32(textBox13.Text);
            if (Xc < 347)
            {
                Point center = new Point(Xc, Yc);
                Gen_circle(Xc, Yc, r);


            }
            else
            {
                Application.Exit();
                Console.WriteLine("X Center can't be more than 347 pixels");
            }



        }
        void Draw_cir(int Xc, int Yc, int x, int y)
        {
            var g = panel1.CreateGraphics();
            var aBrush = Brushes.Green;
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc + x, (panel1.Height / 2) - Yc - y, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc - x, (panel1.Height / 2) - Yc - y, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc + x, (panel1.Height / 2) - Yc + y, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc - x, (panel1.Height / 2) - Yc + y, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc + y, (panel1.Height / 2) - Yc - x, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc - y, (panel1.Height / 2) - Yc - x, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc + y, (panel1.Height / 2) - Yc + x, 1, 1);
            g.FillRectangle(aBrush, (panel1.Width / 2) + Xc - y, (panel1.Height / 2) - Yc + x, 1, 1);

        }
        void Gen_circle(int Xc, int Yc, int r)
        {
            DataTable table = new DataTable();
            table.Columns.Add("K", typeof(int));
            table.Columns.Add("P1k", typeof(int));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));
            table.Columns.Add("2Xk+1", typeof(double));
            table.Columns.Add("2Yk+1", typeof(double));
           /* DataTable table = new DataTable();

            table.Columns.Add("X", typeof(int));
            table.Columns.Add("Y", typeof(int));
            table.Columns.Add("P", typeof(int));
           */
            int pk, x, y;

            x = 0;
            y = r;
            pk = 1 - r;
            int k = 0; 
            while (x < y)
            {
              //  table.Rows.Add(x + Xc, y + Yc, pk);

                x++;
                if (pk < 0)
                {
                    table.Rows.Add(k, pk, x, y, x * 2, y * 2);
                    //    table.Rows.Add(y + Xc, x + Yc, pk);

                    pk = (pk + (x * 2)) + 1;
                }
                else
                {
                    
                    y--;
                    table.Rows.Add(k, pk, x, y, x * 2, y * 2);
                    pk = ((pk + (x * 2)) + 1) - (y * 2);
                }
                Draw_cir(Xc, Yc, x, y);
                dataGridView1.DataSource = table;
                k++;
            }
            
        }
        /* void drawcircle(Point Center, double radius)
         {
             var aBrush = Brushes.DarkOliveGreen;

             var g = panel1.CreateGraphics();
             for (int theta = 0; theta <= 360; theta++)
             {
                 double x, y;
                 x = Center.X + radius * Math.Cos(theta);
                 y = Center.Y + radius * Math.Sin(theta);
                 g.FillRectangle(aBrush, (int)(x + 347.5), (int)(323 - y), 2, 2);
             }
         }*/

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        //Elipse Algorithm......
        private void button8_Click(object sender, EventArgs e)
        {
            int Xc = Convert.ToInt32(textBox19.Text);
            int Yc = Convert.ToInt32(textBox18.Text);
            int Rx = Convert.ToInt32(textBox17.Text);
            int Ry = Convert.ToInt32(textBox14.Text);
            Point P = new Point(Xc, Yc);
            Point R = new Point(Rx, Ry);
            Gen_Eli(P,R);

            
        }
        void Draw_eli(int x, int y, Point P)
        {

            var g = panel1.CreateGraphics();
            var color = Brushes.Orange;


            g.FillRectangle(color, (panel1.Width / 2) + P.X + x, (panel1.Height / 2) - P.Y - y, 3, 3);
            g.FillRectangle(color, (panel1.Width / 2) + P.X - x, (panel1.Height / 2) - P.Y - y, 3, 3);
            g.FillRectangle(color, (panel1.Width / 2) + P.X - x, (panel1.Height / 2) - P.Y + y, 3, 3);
            g.FillRectangle(color, (panel1.Width / 2) + P.X + x, (panel1.Height / 2) - P.Y + y, 3, 3);
        }
        void Gen_Eli(Point P, Point R)
        {
           // CLEAR();

            DataTable table = new DataTable();
            table.Columns.Add("K", typeof(int));
            table.Columns.Add("P1k", typeof(int));
            table.Columns.Add("X", typeof(double));
            table.Columns.Add("Y", typeof(double));
            table.Columns.Add("R^2x", typeof(double));
            table.Columns.Add("R^2y", typeof(double));


            int p1, r1, r2, x, y, res1, res2;

            p1 = (R.Y * R.Y) - (R.X * R.X * R.Y) + (R.X * R.X) / 4;
            x = 0;
            y = R.Y;
            res1 = 2 * (R.Y * R.Y);
            res2 = 2 * (R.X * R.X);

            r1 = res1;
            r2 = res2;

            int max, min;

            if (r1 > r2)
            {
                max = r1;
                min = r2;
            }
            else
            {
                max = r2;
                min = r1;
            }

            int k = 0;
            while (max > min)
            {

                x++;
                if (p1 <= 0)
                {
                    min = res1 * x;
                    max = res2 * y;
                    table.Rows.Add(k, p1, x, y, min, max);
                    p1 = p1 + (2 * (R.Y * R.Y) * x) + (R.Y * R.Y);
                }
                else if (p1 > 0)
                {
                    y--;
                    min = res1 * x;
                    max = res2 * y;

                    table.Rows.Add(k, p1, x, y, min, max);
                    p1 = p1 + (2 * (R.Y * R.Y) * x) - (2 * (R.X * R.X * y)) + (R.Y * R.Y);

                }
                dataGridView1.DataSource = table;
                k++;
                Draw_eli(x, y, P);
            }
            int z = y;
            double p2 = (R.Y * R.Y) * (x + 0.5) * (x + 0.5) + (R.X * R.X) * (y - 1) * (y - 1) - (R.X * R.X) * (R.Y * R.Y);
            Console.WriteLine(p2);
            while (z != 0)
            {
                y--;
                if (p2 <= 0)
                {
                    x++;
                    table.Rows.Add(k, p2, x, y, x * r1, y * r2);
                    p2 = p2 + (2 * R.Y * R.Y * x) - (2 * R.X * R.X * y) + (R.X * R.X);
                }
                else if (p2 > 0)
                {
                    table.Rows.Add(k, p2, x, y, x * r1, y * r2);
                    p2 = p2 - (2 * R.X * R.X * y) + (R.X * R.X);
                }
                Draw_eli(x, y, P);
                k++;
                z--;
            }
        }
        /*void drawEllipse(Point Center, Double xradius, double yradius)
         {
             DataTable table = new DataTable();
             table.Columns.Add("K", typeof(int));
            // table.Columns.Add("P1k", typeof(int));
             table.Columns.Add("X", typeof(double));
             table.Columns.Add("Y", typeof(double));

             var aBrush = Brushes.Black;
             var g = panel1.CreateGraphics();

             int k = 0;
             for (int theta = 0; theta <= 360; theta++)
             {
                 double x, y;
                 x = Center.X + xradius * Math.Cos(theta);
                 y = Center.Y + yradius * Math.Sin(theta);
                 table.Rows.Add(k, x, y, x );
                 dataGridView1.DataSource = table;
                 g.FillRectangle(aBrush, (int)(x + 347.5), (int)(323 - y), 2, 2);
             }

         }*/
        private void label20_Click(object sender, EventArgs e)
        {

        }
        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }
    }
}