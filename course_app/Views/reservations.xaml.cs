﻿using System;
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
            }
            else if ((string)what_search.SelectedValue == "Check out date")
            {
                checkin_date.Visibility = Visibility.Collapsed;
                checkout_date.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<reservation> reserv = new List<reservation>();
            if ((string)what_search.SelectedValue == "Check in date")
            {
                if (checkin_date.SelectedDate == null)
                {
                    MessageBox.Show("Please Select Value");
                    return;
                }
                DateTime t=(DateTime)checkin_date.SelectedDate;
                reserv = GL.db.reservation.Where(i => i.check_in_date.Year == t.Year&& i.check_in_date.Month == t.Month&& i.check_in_date.Day == t.Day).ToList();
            }
            else if ((string)what_search.SelectedValue == "Check out date")
            {
                if (checkout_date.SelectedDate == null)
                {
                    MessageBox.Show("Please Select Value");
                    return;
                }
                DateTime t = (DateTime)checkout_date.SelectedDate;
                reserv = GL.db.reservation.Where(i => i.check_out_date.Year == t.Year && i.check_out_date.Month == t.Month && i.check_out_date.Day == t.Day).ToList();
            }
            res_list.ItemsSource = reserv;
            if (reserv.Count == 0) { MessageBox.Show("No items found!"); }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_reservation w = new add_reservation();
            w.ShowDialog();
            GL.main.MenuItem_Click_8(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if ((reservation)res_list.SelectedValue != null)
            {
                add_reservation w = new add_reservation((reservation)res_list.SelectedValue);
            w.ShowDialog();
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
                w.ShowDialog();
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
            ViewModel.ReservationModel DataContext = new ViewModel.ReservationModel();
            what_search.SelectedIndex = -1;
            checkin_date.SelectedDate = null;
            checkout_date.SelectedDate = null;
            checkin_date.Visibility = Visibility.Collapsed;
            checkout_date.Visibility = Visibility.Collapsed;
            res_list.ItemsSource = DataContext.reservations;
        }

        private void MenuItem_Click2(object sender, RoutedEventArgs e)
        {
            GL.main.DataContext = new ViewModel.ProvidedServices((reservation)res_list.SelectedValue);
            GL.R = (reservation)res_list.SelectedValue;
        }
    }
}
