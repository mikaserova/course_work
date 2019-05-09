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

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for add_parking_spot.xaml
    /// </summary>
    public partial class add_parking_spot : Window
    {
        public add_parking_spot()
        {
            InitializeComponent();
            DataContext = new course_app.ViewModel.ParkingSpotsModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parking_spot s = new parking_spot();
            s.number = t1.Text;
            s.type_id = ((parking_type)t2.SelectedValue).parking_type_id;
            if (t3.SelectedIndex != -1) {
                s.reservation_id = ((reservation)t3.SelectedValue).reservation_id;
            }
            GL.db.parking_spot.Add(s);
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_4(sender, e);
            this.Close();
        }
    }
}
