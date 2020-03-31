using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.EnterTheGrid
{
    public class EnterTheGrid : Window
    {
        [STAThread] public static void Main() {
            Application app = new Application(); //инициализация объекта
            app.Run(new EnterTheGrid()); }
        public EnterTheGrid() //объявление функции
        {
            Title = "Enter the Grid"; //заголовок
            MinWidth = 300; SizeToContent = SizeToContent.WidthAndHeight;             // Create StackPanel for window content.             
            StackPanel stack = new StackPanel();
            Content = stack;             // Create Grid and add to StackPanel.             
            Grid grid1 = new Grid();  //инициализациянового объекта(таблица)
            grid1.Margin = new Thickness(5); //инициализация новой структуры, поле
            stack.Children.Add(grid1);             // Set row definitions.             
            for (int i = 0; i < 5; i++)             {
                RowDefinition rowdef = new  RowDefinition();  //инициализация нового экзепляра класса(свойства строки)
                rowdef.Height = GridLength.Auto;  //длина и значение строки
                grid1.RowDefinitions.Add(rowdef); }             // Set column definitions.             
            ColumnDefinition coldef = new  ColumnDefinition();  //инициализация нового экзепляра класса(свойства столбца)
            coldef.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(coldef);
            coldef = new ColumnDefinition();  
            coldef.Width = new GridLength(100,  GridUnitType.Star);
            grid1.ColumnDefinitions.Add(coldef);             // Create labels and text boxes.             
            string[] strLabels = { "_First name:",  "_Last name:",  "_Social  security number:", "_Credit card  number:", "_Other  personal stuff:" };
            for (int i = 0; i < strLabels.Length; i++)             {
                Label lbl = new Label();  //инициализация нового экземпляра класса (текст)
                lbl.Content = strLabels[i];
                lbl.VerticalContentAlignment =  VerticalAlignment.Center;   //вертикальное выравнивание
                grid1.Children.Add(lbl);
                Grid.SetRow(lbl, i);
                Grid.SetColumn(lbl, 0);  //тут и выше описание таблицы
                TextBox txtbox = new TextBox();  //инициализация текстового редактора
                txtbox.Margin = new Thickness(5);
                grid1.Children.Add(txtbox);
                Grid.SetRow(txtbox, i);
                Grid.SetColumn(txtbox, 1);             }             // Create second Grid and add to  StackPanel.             
            Grid grid2 = new Grid();  //было выше, аналогично + то, что ниже тоже было
            grid2.Margin = new Thickness(10);
            stack.Children.Add(grid2);             // No row definitions needed for  single row.             // Default column definitions are "star".             
            grid2.ColumnDefinitions.Add(new  ColumnDefinition());
            grid2.ColumnDefinitions.Add(new  ColumnDefinition());             // Create buttons.             
            Button btn = new Button();
            btn.Content = "Submit";
            btn.HorizontalAlignment =  HorizontalAlignment.Center;
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);    // Row &  column are 0.             
            btn = new Button();
            btn.Content = "Cancel";
            btn.HorizontalAlignment =  HorizontalAlignment.Center;
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            Grid.SetColumn(btn, 1);     // Row is 0.             // Set focus to first text box.             
            (stack.Children[0] as Panel) .Children[1].Focus();
        }     } } 
