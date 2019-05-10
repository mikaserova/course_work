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
    /// Interaction logic for clients.xaml
    /// </summary>
    public partial class clients : UserControl
    {
        public clients()
        {
            InitializeComponent();
            cont.DataContext = null;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GL.db.client.Remove((client)ent_table.SelectedValue);
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_6(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            update_client w = new update_client((client)ent_table.SelectedValue);
            w.ShowDialog();
            GL.main.MenuItem_Click_6(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_client w = new add_client();
            w.ShowDialog();
            GL.main.MenuItem_Click_6(sender, e);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GL.main.client_t(sender, e);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = new course_app.ViewModel.ClientDataModel((client)ent_table.SelectedValue);
            stack.Visibility = Visibility.Hidden;
            cont.Visibility = Visibility.Visible;
            if (((client)ent_table.SelectedValue) != null)
            {
                cont.DataContext = new course_app.ViewModel.ClientDataModel((client)ent_table.SelectedValue);
                client c = (client)ent_table.SelectedValue;
                f_n.Text = c.client_first_name;
                m_n.Text = c.client_middle_name;
                l_n.Text = c.client_last_name;
                ph_n.Text = c.client_phone_number;
                pas_n.Text = c.client_passport_serial_number;
                e_n.Text = c.client_email;
                pos_n.SelectedValue = c.client_type;
                note.Text = c.client_notes;
            }
            else
            {
                MessageBox.Show("Choose the row!");
            }
            
        }

        private void Button_Click_close(object sender, RoutedEventArgs e)
        {
            cont.Visibility = Visibility.Hidden;
        }

        private void What_search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((string)what_search.SelectedValue=="Type")
            {
                
                text_search.Visibility = Visibility.Collapsed;
                box_search.Visibility = Visibility.Visible;
            }
            else
            {
                text_search.Visibility = Visibility.Visible;
                box_search.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            List<client> clients = new List<client>();
            if ((string)what_search.SelectedValue == "Type")
            { client_type t = (client_type)box_search.SelectedValue;
                clients = GL.db.client.Where(i => i.client_type_id == t.client_type_id).ToList();
            }else if ((string)what_search.SelectedValue == "First name")
            {
                clients = GL.db.client.Where(i =>i.client_first_name==text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Middle name")
            {
                clients = GL.db.client.Where(i => i.client_middle_name == text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Last name")
            {
                clients = GL.db.client.Where(i => i.client_last_name == text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Phone")
            {
                clients = GL.db.client.Where(i => i.client_phone_number== text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Email")
            {
                clients = GL.db.client.Where(i => i.client_email == text_search.Text).ToList();
            }
            else if ((string)what_search.SelectedValue == "Passport")
            {
                clients = GL.db.client.Where(i => i.client_passport_serial_number == text_search.Text).ToList();
            }
            search_list.ItemsSource = clients;
            stack.Visibility = Visibility.Visible;
            if (clients.Count == 0) { MessageBox.Show("No item found!"); }
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            stack.Visibility = Visibility.Hidden;
            what_search.SelectedValue = null;
            text_search.Visibility= Visibility.Hidden;
            box_search.Visibility= Visibility.Hidden;
        }

        private void MenuItem_Click1(object sender, RoutedEventArgs e)
        {
            stack.Visibility = Visibility.Hidden;
            cont.Visibility = Visibility.Visible;
            if (((client)search_list.SelectedValue) != null)
            {
                cont.DataContext = new course_app.ViewModel.ClientDataModel((client)search_list.SelectedValue);
                client c = (client)search_list.SelectedValue;
                f_n.Text = c.client_first_name;
                m_n.Text = c.client_middle_name;
                l_n.Text = c.client_last_name;
                ph_n.Text = c.client_phone_number;
                pas_n.Text = c.client_passport_serial_number;
                e_n.Text = c.client_email;
                pos_n.SelectedValue = c.client_type;
                note.Text = c.client_notes;
            }
            else
            {
                MessageBox.Show("Choose the row!");
            }
        }
    }
}
