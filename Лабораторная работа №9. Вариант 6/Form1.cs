using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Xmin = double.Parse(textBox1.Text);
            double Xmax = double.Parse(textBox2.Text);
            double Step = double.Parse(textBox4.Text);
            double b = double.Parse(textBox3.Text);
            

            int count = (int)Math.Ceiling(Math.Abs((Xmax - Xmin)) / Math.Abs(Step)) +1;

            double[] x=new double[count];

            double[] y1= new double[count];
            double[] y2 = new double[count];
            for (int i = 0; i < count; i++)
            {
                x[i] = Xmin + Step * i;
                y1[i] = x[i] * x[i] + Math.Tan(5 * x[i] + b / x[i]);
                y2[i] = x[i]*x[i]-15*x[i]-37*Math.Cos(3*x[i]) ;

            }
            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;
            
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Math.Abs(Step);
            
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-2,5";
            textBox2.Text = "-1,5";
            textBox3.Text = "-0,8";
            textBox4.Text = "0,5";
        }
    }
}
