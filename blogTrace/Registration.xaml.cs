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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace blogTrace
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    /// 
    public partial class Registration : Window
    {
        Users users;
        public Registration()
        {
            InitializeComponent();
        }

        private void Pswd_Change(object sender, RoutedEventArgs e)
        {
            error.Visibility = Visibility.Hidden;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            if (dPswdBox.Text == PswdBox.Text)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Users));
                User user = new User(loginBox.Text, PswdBox.Text, false);
                
                using (Stream stream = File.Open(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\data\Users.xml", FileMode.OpenOrCreate))
                {
                    try
                    {
                        users = ((Users)xmlSerializer.Deserialize(stream));
                    }
                    catch
                    {
                        users = new Users();
                    }
                }
                users.items.Add(user);
                using (FileStream fileStream = new FileStream(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\data\Users.xml", FileMode.Create))
                {
                    xmlSerializer.Serialize(fileStream, users);
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }
    }
}
