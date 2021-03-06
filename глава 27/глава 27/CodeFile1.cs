﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace SineWave {
    public class SineWave : Window {
        [STAThread]
        public static void Main() {
            Application app = new Application(); //инициализация объекта
            app.Run(new SineWave()); }
        public SineWave() {
            Title = "Sine Wave";             // сделать Polyline содержанием окна             
            Polyline poly = new Polyline();
            poly.VerticalAlignment =  VerticalAlignment.Center;  //выравнивание по вертикали
            poly.Stroke = SystemColors .WindowTextBrush;
            poly.StrokeThickness = 2;
            Content = poly;             // определить точки             
            for (int i = 0; i < 2000; i++)
                poly.Points.Add( new Point(i, 96 * (1 - Math .Sin(i * Math.PI / 192))));         }     } } 