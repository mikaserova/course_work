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

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile()
        {
            InitializeComponent();
            if (GL.permission_level > 1)
            {
                clean_btn.Visibility = Visibility.Collapsed;
                cl_lab.Visibility = Visibility.Collapsed;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            credential cr = GL.db.credential.Where(t => t.credential_id == GL.cred_id).FirstOrDefault();
             employee me = GL.db.employee.Where(t => t.employee_id == cr.employee_id).FirstOrDefault();
            position_info position = new position_info(me.employee_position);
            position.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GL.main.Schedule_Click(sender, e);
        }

        private void Clean_btn_Click(object sender, RoutedEventArgs e)
        { 
            GL.main.DataContext = new ViewModel.PersCleanModel();
        }
    }
}
