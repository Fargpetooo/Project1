using System;
using System.IO; 
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;
namespace Petzold.LoadEmbeddedXaml
{
    public class LoadEmbeddedXaml : Window
    {
        [STAThread] 
        public static void Main()
        {
            Application app = new Application(); //инициализация объекта (создание нового приложения) 
            app.Run(new LoadEmbeddedXaml()); //Запускает стандартный цикл обработки сообщений приложения в текущем потоке
        }
        public LoadEmbeddedXaml()
        {
            Title = "Load Embedded Xaml"; //заголовок
            string strXaml = "<Button xmlns='http://schemas .microsoft.com/" + "winfx/2006 /xaml/presentation'" + "Foreground='LightSeaGreen' FontSize='24pt'>" + "Click me!" + "</Button>";
            StringReader strreader = new StringReader(strXaml); //инициализация нового экземпляра класса StringReader, осуществляющий чтение из строки strXaml 
            XmlTextReader xmlreader = new XmlTextReader(strreader);//инифиализация нового экземпляра класса XmlTextReader указанным чтением TextReader
            object obj = XamlReader.Load(xmlreader);//считывание указанных данных XAML в классе XamlReader и возвращение корневого объекта соответсвующего дерева объектов 
            //создание граф объъекта с исп. средства чтения XAML
            Content = obj;//установка содержимого окна 
        }
    }
}