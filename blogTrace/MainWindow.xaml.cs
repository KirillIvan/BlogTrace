using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace blogTrace
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
        public static XmlSerializer serializer = new XmlSerializer(typeof(Users));
        public static Users users;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            
            

            foreach (var item in users.items)
            {
                if (item.Login == loginBox.Text && item.Password == PswdBox.Password)
                {
                    Blog blog = new Blog();
                    Blog.admin = item.Admin;
                    blog.Show();
                    this.Close();
                    
                }
            }

            error.Visibility = Visibility.Visible;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            using (FileStream fileStream = new FileStream(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\BlogTrace.git\data\Users.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fileStream, users);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (Stream stream = File.Open(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\BlogTrace.git\data\Users.xml", FileMode.OpenOrCreate))
            {
                 users = ((Users)serializer.Deserialize(stream));
            }


        }

        private void LoginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text == "Логин")
                loginBox.Text = "";
        }

        private void PswdBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PswdBox.Password == "Логин")
                PswdBox.Password = "";
        }
    }
}
