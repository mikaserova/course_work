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
    /// Interaction logic for add_client.xaml
    /// </summary>
    public partial class add_client : Window
    {
        public add_client()
        {
            InitializeComponent();
            DataContext = new course_app.ViewModel.CleaningModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            client c = new client();
            c.client_first_name = f_n.Text;
            c.client_middle_name = m_n.Text;
            c.client_last_name = l_n.Text;
            c.client_email = e_n.Text;
            c.client_passport_serial_number = pas_n.Text;
            c.client_phone_number = ph_n.Text;
            c.client_notes = note.Text;
            c.client_type_id = ((client_type)pos_n.SelectedValue).client_type_id;
            GL.db.client.Add(c);
            GL.db.SaveChanges();
            this.Close();
        }
    }
}
