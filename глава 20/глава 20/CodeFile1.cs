using System;
using System.Windows.Controls;
using System.Windows.Media;
namespace Petzold.XamlCruncher
{
    public class XamlCruncherSettings : Petzold.NotepadClone.NotepadCloneSettings
    {
        public Dock Orientation = Dock.Left; // стандартные настройки предпочтения пользователя.
        public int TabSpaces = 4;
        public string StartupDocument = "<Button xmlns=\"http://schemas .microsoft.com/winfx" + "/2006/xaml/presentation\" \r\n" + " xmlns:x=\"http://schemas .microsoft.com/winfx" + "/2006/xaml\">\r\n" + "Hello, XAML!\r\n" + "</Button>\r\n";


        public XamlCruncherSettings() //конструктор для инициализации настроек в NotepadCloneSettings
        {
            string FontFamily = "Lucida Console";
            double FontSize = 10 / 0.75;
        }
    }
}