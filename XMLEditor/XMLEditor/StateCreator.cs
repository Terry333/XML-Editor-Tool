using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XMLEditor
{
    class StateCreator : Window
    {
        XMLImporter Importer;
        string[] XMLData;
        TextBox string1, string2, string3, int1, int2;

        public StateCreator()
        {
            Width = 600;
            Height = 450;

            Importer = new XMLImporter();
            XMLData = Importer.ImportXMLData(System.IO.Path.GetFullPath(System.IO.Path.Combine(@AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\")) + "Data\\Templates.txt");
            Importer.AddString(XMLData[0]);

            Button create = new Button();
            create.Content = "Create State.";
            create.Click += ButtonPress;

            Button finish = new Button();
            finish.Content = "Finish.";
            finish.Click += Finish;

            string1 = new TextBox();
            string1.Text = "State name.";

            string2 = new TextBox();
            string2.Text = "State capitol.";

            string3 = new TextBox();
            string3.Text = "Governor name.";

            int1 = new TextBox();
            int1.Text = "Population.";

            int2 = new TextBox();
            int2.Text = "Governor ideology.";

            Grid grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(string1, 0);
            Grid.SetRow(string2, 1);
            Grid.SetRow(string3, 2);
            Grid.SetRow(int1, 3);
            Grid.SetRow(int2, 4);
            Grid.SetRow(create, 5);
            Grid.SetRow(finish, 6);

            grid.Children.Add(string1);
            grid.Children.Add(string2);
            grid.Children.Add(string3);
            grid.Children.Add(int1);
            grid.Children.Add(int2);
            grid.Children.Add(create);
            grid.Children.Add(finish);

            AddChild(grid);

        }

        public void ButtonPress(object sender, RoutedEventArgs e)
        {
            string str = Importer.FormatText(XMLData[2], "string", "1", string1.Text);
            str = Importer.FormatText(str, "string", "2", string2.Text);
            str = Importer.FormatText(str, "string", "3", string3.Text);
            str = Importer.FormatText(str, "int", "1", int1.Text);
            str = Importer.FormatText(str, "int", "2", int2.Text);
            Importer.AddString(str);
        }

        public void Finish(object sender, RoutedEventArgs e)
        {
            Importer.AddString(XMLData[1]);
            Importer.WriteToFile();
            Close();
        }
    }
}
