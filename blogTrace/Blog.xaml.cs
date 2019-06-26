using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace blogTrace
{
    /// <summary>
    /// Логика взаимодействия для Blog.xaml
    /// </summary>
    public partial class Blog : Window
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Users));
        public static Users users;
        public static bool admin;
        public Blog()
        {
            InitializeComponent();
            
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.Open(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\BlogTrace.git\data\Users.xml", FileMode.OpenOrCreate))
            {
                users = ((Users)serializer.Deserialize(stream));
            }
            dataGrid.ItemsSource = users.items;
            if (!admin)
                pswdColumn.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\BlogTrace.git\data\Users.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, users);
            }
            
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGrid.SelectedItem != null && admin)
            {
                Edit edit = new Edit();
                Edit.users = users;
                Edit.user = dataGrid.SelectedItem as User;
                Edit.index = dataGrid.SelectedIndex;
                edit.ShowDialog();
                Window_Loaded(sender, new RoutedEventArgs());
            }
        }

        private void BtnNewUser_Click(object sender, RoutedEventArgs e)
        {
            if (admin)
            {
                Edit edit = new Edit();
                Edit.users = users;
                Edit.user = new User("", "", false);
                Edit.index = -1;
                edit.ShowDialog();
                Window_Loaded(sender, new RoutedEventArgs());
            }  
        }
    }
}
