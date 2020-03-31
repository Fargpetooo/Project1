using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.CommandTheButton
{
    public class CommandTheButton : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); //инициализация
            app.Run(new CommandTheButton());
        }
        public CommandTheButton() //объявление функции
        {
            Title = "Command the Button"; // Create the Button and set as window  content.   название          
            Button btn = new Button(); //инициализация кнопки 
            btn.HorizontalAlignment = HorizontalAlignment.Center; //центрирование и в строчке ниже
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Command = ApplicationCommands.Paste;
            btn.Content = ApplicationCommands.Paste.Text;
            Content = btn;             // связывание команд с обработчиками событий        
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste,PasteOnExecute, PasteCanExecute)); //инициализация
        }
        void PasteOnExecute(object sender, ExecutedRoutedEventArgs args)
        {
            Title = Clipboard.GetText();  //отправляем данные заголовка в буфер обмена
        }
        void PasteCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = Clipboard.ContainsText();
        }
        protected override void OnMouseDown(MouseButtonEventArgs args) // функция для кнопки мыши
        {
            base.OnMouseDown(args);
            Title = "Command the Button";
        }
    }
}