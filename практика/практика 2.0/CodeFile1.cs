using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace fff
{
    public class EnterTheGrid : Window
    {
        [STAThread]

        public static void Main()
        {
            Application app = new Application();
            app.Run(new EnterTheGrid());
        }
        public EnterTheGrid()
        {
            Title = "Enter the grid";
            MinWidth = 300;
            SizeToContent = SizeToContent.WidthAndHeight;
            StackPanel stack = new StackPanel();
            Content = stack;
            Grid grid1 = new Grid();
            grid1.Margin = new Thickness(5);
            stack.Children.Add(grid1);
            for (int i = 0; i < 4; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid1.RowDefinitions.Add(rowdef);
            }
            ColumnDefinition coldef = new ColumnDefinition();
            coldef.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(coldef);
            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(50, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(coldef);
            string[] strLabels = { "_Initial speed:", "_Angle:"/*, "_Сoordinate X:", "_Сoordinate Y:" */};
            Label lbl = new Label();
            lbl.Content = strLabels[0];
            lbl.VerticalContentAlignment = VerticalAlignment.Center;
            grid1.Children.Add(lbl);
            Grid.SetRow(lbl, 0);
            Grid.SetColumn(lbl, 0);
            TextBox txtbox = new TextBox();
            txtbox.Margin = new Thickness(0);
            grid1.Children.Add(txtbox);
            Grid.SetRow(txtbox, 0);
            Grid.SetColumn(txtbox, 1);

            Label lbl1 = new Label();
            lbl1.Content = strLabels[1];
            lbl1.VerticalContentAlignment = VerticalAlignment.Center;
            grid1.Children.Add(lbl1);
            Grid.SetRow(lbl1, 1);
            Grid.SetColumn(lbl1, 0);
            TextBox txtbox1 = new TextBox();
            txtbox.Margin = new Thickness(0);
            grid1.Children.Add(txtbox1);
            Grid.SetRow(txtbox1, 1);
            Grid.SetColumn(txtbox1, 1);

            Grid grid2 = new Grid();
            grid2.Margin = new Thickness(10);
            stack.Children.Add(grid2);
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            Button btn = new Button();
            btn.Content = "Submit";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsDefault = true;
            btn.Click += delegate
            {
                double step = 1;
                double IS = System.Convert.ToDouble(txtbox.Text);
                double AN = System.Convert.ToDouble(txtbox1.Text);
                Move Bird = new Move(IS, AN);
                Bird.Calculate(step);

                StringBuilder Res = new StringBuilder("", 500);

                Res.Insert(0, Bird.Time);
                Res.Insert(0, "Flight time: ");
                Res.Insert(0, "\n");
                Res.Insert(0, Bird.yMax);
                Res.Insert(0, "Highest point: ");
                Res.Insert(0, "\n");
                Res.Insert(0, Bird.Dis);
                Res.Insert(0, "Distance: ");
                //Result.Show();
                MessageBox.Show(System.Convert.ToString(Res), "Results");
            };
            grid2.Children.Add(btn);
            btn = new Button();
            btn.Content = "Cancel";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            Grid.SetColumn(btn, 1);
            (stack.Children[0] as Panel).Children[1].Focus();
        }

    }
    public class Move : EnterTheGrid
    {
        public double Dis = 0;
        public double Time = 0;
        public double yMax;
        private double xSpd;
        private double ySpd;
        private double angle;
        private double m = 1;
        private const double g = 9.8;
        public Move(double s, double a)
        {
            this.angle = Math.PI * a / 180.0;
            xSpd = s * Math.Cos(angle);
            ySpd = s * Math.Sin(angle);
        }
        public void Calculate(double s)
        {
            double step = 10;

            double x = 0, y = 0;
            for (double i = s; true; i += s)
            {
                xSpd = xSpd - xSpd * WindX(i) * i / m;
                ySpd = ySpd + (-ySpd * WindY(i) / m - g) * i;
                x = x + xSpd * i;
                y = y + ySpd * i;
                Time += step;
                if (y > yMax)
                {
                    yMax = y;
                }
                if (y < 0)
                {
                    Dis = x;
                    break;
                }
            }
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
}