using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.TransformedButtons
{
    public class TransformedButtons : Window
    {
        [STAThread] public static void Main() {
            Application app = new Application();
            app.Run(new TransformedButtons()); }
        public TransformedButtons()
        {
            Title = "Transformed Buttons";             // Создание Canvas как содержимое окна.
                        Canvas canv = new Canvas();
            Content = canv;             // Untransformed кнопка    
            Button btn = new Button();
            btn.Content = "Untransformed";
            canv.Children.Add(btn);
            Canvas.SetLeft(btn, 50);
            Canvas.SetTop(btn, 100);             // Translated кнопка   
            btn = new Button();
            btn.Content = "Translated";
            btn.RenderTransform = new  TranslateTransform(-100, 150);
            canv.Children.Add(btn);
            Canvas.SetLeft(btn, 200);
            Canvas.SetTop(btn, 100);             // Scaled кнопка     
            btn = new Button();
            btn.Content = "Scaled";
            btn.RenderTransform = new  ScaleTransform(1.5, 4);
            canv.Children.Add(btn);             Canvas.SetLeft(btn, 350);
            Canvas.SetTop(btn, 100);             // Skewed кнопка    
            btn = new Button();             btn.Content = "Skewed";
            btn.RenderTransform = new  SkewTransform(0, 20);
            canv.Children.Add(btn);
            Canvas.SetLeft(btn, 500);
            Canvas.SetTop(btn, 100);             // Rotated кнопка        
            btn = new Button();
            btn.Content = "Rotated";
            btn.RenderTransform = new  RotateTransform(-30);
            canv.Children.Add(btn);
            Canvas.SetLeft(btn, 650);
            Canvas.SetTop(btn, 100);         }     } } 
