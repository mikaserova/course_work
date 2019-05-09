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
    /// Interaction logic for update_client.xaml
    /// </summary>
    public partial class update_client : Window
    { client c { get; set; }
        public update_client( client c1)
        {
            InitializeComponent();
            c = GL.db.client.Where(i => i.client_id == c1.client_id).FirstOrDefault();
            f_n.Text = c.client_first_name ;
             m_n.Text= c.client_middle_name ;
             l_n.Text= c.client_last_name ;
            e_n.Text = c.client_email;
             pas_n.Text= c.client_passport_serial_number ;
           ph_n.Text = c.client_phone_number ;
            note.Text = c.client_notes ;
            client_type ct = GL.db.client_type.Where(i => i.client_type_id == c.client_type_id).FirstOrDefault();
            pos_n.SelectedValue = ct;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c.client_first_name = f_n.Text;
            c.client_middle_name = m_n.Text;
            c.client_last_name = l_n.Text;
            c.client_email = e_n.Text;
            c.client_passport_serial_number = pas_n.Text;
            c.client_phone_number = ph_n.Text;
            c.client_notes = note.Text;
            c.client_type_id = ((client_type)pos_n.SelectedValue).client_type_id;
            GL.db.Entry(c).State = System.Data.Entity.EntityState.Modified;
            GL.db.SaveChanges();
            this.Close();
        }
    }
}
