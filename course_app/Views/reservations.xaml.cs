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
    /// Interaction logic for reservation.xaml
    /// </summary>
    public partial class reservations : UserControl
    {
        public reservations()
        {
            InitializeComponent();
        }

        private void What_search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {/*
                 list_fields.Add("Check in date");
            list_fields.Add("Check out date");
            list_fields.Add("Check in date and time");
            list_fields.Add("Check out date and time");
            list_fields.Add("Check in and check out dates");
            list_fields.Add("Reservation number");
            list_fields.Add("Client");
            list_fields.Add("Room");
            list_fields.Add("Employee");
            */
            if((string)what_search.SelectedValue== "Check in date")
            {
                checkin_date.Visibility = Visibility.Visible;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;



            }
            else if ((string)what_search.SelectedValue == "Check out date")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Visible;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Check in date and time")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;

                checkin_datetime.Visibility = Visibility.Visible;

                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Check out date and time")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;

                checkout_datetime.Visibility = Visibility.Visible;

                res_number.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Check in and check out dates")
            {
                checkin_date.Visibility = Visibility.Visible;
                checkout_date.Visibility = Visibility.Visible;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Reservation number")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Visible;
                client.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Client")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;

                client.Visibility = Visibility.Visible;

                employee.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Employee")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Visible;
                client.Visibility = Visibility.Collapsed;
              
                room_number.Visibility = Visibility.Collapsed;
            }
            else if ((string)what_search.SelectedValue == "Room")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Collapsed;
                checkin_datetime.Visibility = Visibility.Collapsed;
                checkout_datetime.Visibility = Visibility.Collapsed;
                res_number.Visibility = Visibility.Collapsed;
                employee.Visibility = Visibility.Collapsed;
                client.Visibility = Visibility.Collapsed;
                room_number.Visibility = Visibility.Visible;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<reservation> reserv = new List<reservation>();
            if ((string)what_search.SelectedValue == "Check in date")
            {
                DateTime t=(DateTime)checkin_date.SelectedDate;
                reserv = GL.db.reservation.Where(i => i.check_in_date.Year == t.Year&& i.check_in_date.Month == t.Month&& i.check_in_date.Day == t.Day).ToList();
            }
            else if ((string)what_search.SelectedValue == "Check out date")
            {
                DateTime t = (DateTime)checkout_date.SelectedDate;
                reserv = GL.db.reservation.Where(i => i.check_out_date.Year == t.Year && i.check_out_date.Month == t.Month && i.check_out_date.Day == t.Day).ToList();
            }
            else if ((string)what_search.SelectedValue == "Check in date and time")
            {
                reserv = GL.db.reservation.Where(i => i.check_in_date == ((DateTime)checkin_datetime.Value)).ToList();
            }
            else if ((string)what_search.SelectedValue == "Check out date and time")
            {
                reserv = GL.db.reservation.Where(i => i.check_out_date == ((DateTime)checkout_datetime.Value)).ToList();
            }
            else if ((string)what_search.SelectedValue == "Check in and check out dates")
            {
                DateTime t = (DateTime)checkin_date.SelectedDate;
                DateTime t1 = (DateTime)checkout_date.SelectedDate;
                reserv = GL.db.reservation.Where(i => i.check_in_date.Year == t.Year && i.check_in_date.Month == t.Month && i.check_in_date.Day == t.Day&& i.check_out_date.Year == t1.Year && i.check_out_date.Month == t1.Month && i.check_out_date.Day == t1.Day).ToList();
            }
            else if ((string)what_search.SelectedValue == "Reservation number")
            {
                reserv = GL.db.reservation.Where(i => i.reservation_number==res_number.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Client")
            {
                reserv = GL.db.reservation.Where(i => i.client==client.SelectedValue).ToList();
            }
            else if ((string)what_search.SelectedValue == "Employee")
            {
                reserv = GL.db.reservation.Where(i => i.employee == employee.SelectedValue).ToList();
            }
            else if ((string)what_search.SelectedValue == "Room")
            {
                reserv = GL.db.reservation.Where(i => i.room == room_number.SelectedValue).ToList();
            }
            res_list.ItemsSource = reserv;
            if (reserv.Count == 0) { MessageBox.Show("No items found!"); }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_reservation w = new add_reservation();
            w.Show();
            GL.main.MenuItem_Click_8(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((reservation)res_list.SelectedValue != null)
            {
                add_reservation w = new add_reservation((reservation)res_list.SelectedValue);
            w.Show();
            GL.main.MenuItem_Click_8(sender, e);
        }
            else
            {
                MessageBox.Show("Please, select the row");
            }
}

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                GL.db.reservation.Remove((reservation)res_list.SelectedValue);
                GL.db.SaveChanges();
                GL.main.MenuItem_Click_8(sender, e);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if ((reservation)res_list.SelectedValue != null)
            {
                add_payment w = new add_payment((reservation)res_list.SelectedValue);
                w.Show();
                GL.main.MenuItem_Click_8(sender, e);
            }
            else
            {
                MessageBox.Show("Please, select the row");
            }
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            GL.main.DataContext = new ViewModel.currPaymentModel((reservation)res_list.SelectedValue);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewModel.ReservationModel();
        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            GL.main.DataContext = new ViewModel.ProvidedServices((reservation)res_list.SelectedValue);
        }
    }
}
