using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ShapeAnEllipse {
    class ShapeAnEllipse : Window {[STAThread] //объявляется класс
        public static void Main() { //основная  функция
            Application app = new Application(); // инициализация объекта
            app.Run(new ShapeAnEllipse()); } 
        public ShapeAnEllipse() { Title = "Shape an Ellipse";
            Ellipse elips = new Ellipse();  // инициализация элипса
            elips.Fill = Brushes.AliceBlue;
            elips.StrokeThickness = 24; //1/4  inch       тут и строчкой выше описание элипса      
            elips.Stroke = new LinearGradientBrush(Colors .CadetBlue, Colors.Chocolate, new Point (1, 0), new Point(0, 1)); //выбор цвета
            Content = elips;         }     } } 