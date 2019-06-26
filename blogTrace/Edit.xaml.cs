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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public static User user;
        public static int index;
        public static Users users;
        XmlSerializer serializer = new XmlSerializer(typeof(Users));
        public Edit()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(index == -1)
            {
                this.Title = "Добавление";
                textTitle.Text = "Добавление";
                saveBtn.Content = "Добавить";
            }
            else
            {
                loginBox.Text = user.Login;
                PswdBox.Text = user.Password;
                adminCB.IsChecked = user.Admin;
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if((loginBox.Text != "Логин") && (PswdBox.Text != "Пароль") && !String.IsNullOrWhiteSpace(loginBox.Text) && !String.IsNullOrWhiteSpace(PswdBox.Text))
            {
                if (index != -1)
                    users.items[index] = new User(loginBox.Text, PswdBox.Text, adminCB.IsChecked.Value);
                else
                    users.items.Add(new User(loginBox.Text, PswdBox.Text, adminCB.IsChecked.Value));
                using (FileStream fileStream = new FileStream(@"D:\ПапкаДляТехникума\ПрактикаWPF\blogTrace\BlogTrace.git\data\Users.xml", FileMode.Create))
                    serializer.Serialize(fileStream, users);
                this.Close();
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }

        private void PswdBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Пароль" || textBox.Text == "Повтор пароля")
                textBox.Text = "";
        }

        private void LoginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (loginBox.Text == "Логин")
                loginBox.Text = "";
        }
    }
    }
