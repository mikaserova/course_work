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
    /// Interaction logic for parking_spot_table.xaml
    /// </summary>
    public partial class parking_spot_table : UserControl
    {
        public parking_spot_table()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_parking_spot w = new add_parking_spot();
            w.ShowDialog();
            GL.main.MenuItem_Click_4(sender, e);


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            update_parking_spot w = new update_parking_spot((parking_spot)ent_table.SelectedValue);
            w.ShowDialog();
            GL.main.MenuItem_Click_4(sender, e);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GL.db.parking_spot.Remove((parking_spot)ent_table.SelectedValue);
            GL.main.MenuItem_Click_4(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GL.main.parking_t(sender, e);
        }

        private void What_search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)what_search.SelectedValue == "Type")
            {

                text_search.Visibility = Visibility.Collapsed;
                box_search.Visibility = Visibility.Visible;
                box1_search.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Number")
            {
                text_search.Visibility = Visibility.Visible;
                box_search.Visibility = Visibility.Collapsed;
                box1_search.Visibility = Visibility.Collapsed;
            }
            else
            {
                text_search.Visibility = Visibility.Collapsed;
                box_search.Visibility = Visibility.Collapsed;
                box1_search.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<parking_spot> spots = new List<parking_spot>();
            if ((string)what_search.SelectedValue == "Type")
            {
                parking_type t = (parking_type)box_search.SelectedValue;
                spots = GL.db.parking_spot.Where(i => i.type_id == t.parking_type_id).ToList();
            }
            else if ((string)what_search.SelectedValue == "Number")
            {
                spots = GL.db.parking_spot.Where(i => i.number == text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Reservation")
            {
                reservation r = (reservation)box1_search.SelectedValue;
                spots = GL.db.parking_spot.Where(i => i.reservation_id == r.reservation_id).ToList();
            }
           search_list.ItemsSource = spots;
            
            
            if (spots.Count == 0) { MessageBox.Show("No item found!"); }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            what_search.SelectedValue = null;
            box_search.SelectedValue = null;
            box_search.Visibility = Visibility.Visible;
            search_list.ItemsSource = null;
        }
    }
}
