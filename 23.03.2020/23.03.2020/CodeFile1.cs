using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Movement
{
    class Move
    {
        private double xSpd;
        private double ySpd;
        private double angle;
        private double m = 1;
        private const double g = 9.8;
        private List<List<double>> cXYT = new List<List<double>>();
        private List<double> wind = new List<double>();

        public Move(double s, double a)
        {
            this.angle = Math.PI * a / 180.0;
            xSpd = s * Math.Cos(angle);
            ySpd = s * Math.Sin(angle);
        }
        public void InitList()
        {
            this.cXYT.Add(new List<double>());
            this.cXYT.Add(new List<double>());
            this.cXYT.Add(new List<double>());
        }
        public void Calculate(double s)
        {
            double x = 0, y = 0;
            StreamWriter f = new StreamWriter("test123.txt");
            for (double i = s; true; i += s)
            {
                InitList();
                xSpd = xSpd - xSpd * WindX(i) * i / m;
                ySpd = ySpd + (-ySpd * WindY(i) / m - g) * i;
                x = x + xSpd * i;
                y = y + ySpd * i;
                if (y < 0)
                    break;
                cXYT[0].Add(x);
                cXYT[1].Add(y);
                cXYT[2].Add(i);

                f.WriteLine("{0} {1} {2}", cXYT[0].Last(), cXYT[1].Last(), cXYT[2].Last());
                Console.WriteLine("{0} {1} {2}", cXYT[0].Last(), cXYT[1].Last(), cXYT[2].Last());
                if (y < 0)
                {

                    cXYT[0].Add(x);
                    cXYT[1].Add(0);
                    cXYT[2].Add(i);
                    for (int j = 0; j < 3; j++)
                    {
                        f.WriteLine(cXYT[j].Last());
                    }
                    f.Close();
                    break;
                }
            }
            Console.WriteLine("Полёт окончен по плану. Время полёта: {0} секунд. Дистанция: {1} метров", cXYT[2].Last(), cXYT[0].Last());
            f.Close();
        }
        public double WindX(double arg)
        {

            return Math.Sin(arg) * 0.1;
        }
        public double WindY(double arg)
        {
            return Math.Cos(arg) * 0.1;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            double sp, ang, step, m;
            sp = Convert.ToDouble(Console.ReadLine());
            ang = Convert.ToDouble(Console.ReadLine());
            step = Convert.ToDouble(Console.ReadLine());
            Move n1 = new Move(sp, ang);
            n1.Calculate(step);
        }
    }
}