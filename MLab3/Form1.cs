using BasicInterpolation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            double[] ex = { -1, 3, 5, 7, 10 };
            double[] ey = { 10.2, 2.5, 5.4, 3.8, 8.3 };
            double[] p = { -1, -0.8, 0, 0.65, 1, 1.3, 1.9, 2.6, 3.1, 3.5, 4, 4.5, 5,5.6,6.4,7,8,8.5,9.2,10 };
            CubicSplineInterpolation CS = new CubicSplineInterpolation(ex, ey);
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();
            foreach (double pp in p)
            {
                xs.Add(pp);
                ys.Add(CS.Interpolate(pp).Value);
            }
            formsPlot1.Plot.PlotScatter(
            xs: xs.ToArray(),
            ys: ys.ToArray(),
            color: Color.Blue,
            markerSize: 10,
            label: "Cubic spline interpolation");

            LagrangeInterpolate interpolate = new LagrangeInterpolate();
            interpolate.Add(-1, 10.2);
            interpolate.Add(3, 2.5);
            interpolate.Add(5, 5.4);
            interpolate.Add(7, 3.8);
            interpolate.Add(10, 8.3);
            xs.Clear();
            ys.Clear();
            foreach (double pp in p)
            {
                xs.Add(pp);
                ys.Add(interpolate.InterpolateX(pp));
            }
            formsPlot1.Plot.PlotScatter(
            xs: xs.ToArray(),
            ys: ys.ToArray(),
            color: Color.Red,
            markerSize: 10,
            label: "Lagrange Interpolation");

            formsPlot1.Plot.Legend();
        }
    }
}
