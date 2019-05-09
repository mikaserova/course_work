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
    /// Interaction logic for room_types.xaml
    /// </summary>
    public partial class room_types : UserControl
    {
        public room_types()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GL.main.MenuItem_Click_2(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add_room_type w = new Add_room_type();
            w.Show();
            GL.main.BTN_Click(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            update_room_type w = new update_room_type((room_type)table.SelectedValue);
            w.Show();
            GL.main.BTN_Click(sender, e);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GL.db.room_type.Remove((room_type)table.SelectedValue);
            GL.db.SaveChanges();
            GL.main.BTN_Click(sender, e);
        }
    }
}
