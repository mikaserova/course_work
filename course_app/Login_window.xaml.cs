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
using System.Windows.Shapes;

namespace course_app
{
    /// <summary>
    /// Interaction logic for Login_window.xaml
    /// </summary>
    public partial class Login_window : Window
    { hotel_newEntities db;
        public Login_window()
        {
            InitializeComponent();
            try
            {
                db = new hotel_newEntities();
            }
            catch(Exception )
            {
                MessageBox.Show("Can`t connect to database");
            }
            GL.login_Window = this;
        }

        private void Enter_button_Click(object sender, RoutedEventArgs e)
        {
            string log = login_box.Text;
            string pass = password_box.Password;
            var user = db.credential.Where(u => u.username == log).FirstOrDefault();
            if(user!=null&& pass == user.password)
            {
                MainWindow main = new MainWindow(user.credential_id);
                main.WindowState = System.Windows.WindowState.Maximized;
                main.Closed += FooClosed;
                main.Show();
                GL.main = main;

                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong email or password. Please try again");
            }

        }
        public void FooClosed(object sender, System.EventArgs e)
        {
            //This gets fired off
            GL.main = null;
            this.Close();
        }
    }
}
