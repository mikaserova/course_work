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
    /// Interaction logic for room_table.xaml
    /// </summary>
    public partial class room_table : UserControl
    {
        public room_table()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_room w = new add_room();
            w.Show();
            GL.main.MenuItem_Click_2(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GL.main.BTN_Click(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            room r = (room)ent_table.SelectedValue;
            update_room w = new update_room(r);
            w.Show();
            GL.main.MenuItem_Click_2(sender, e);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                GL.db.room.Remove((room)ent_table.SelectedValue);
                GL.main.MenuItem_Click_2(sender, e);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
