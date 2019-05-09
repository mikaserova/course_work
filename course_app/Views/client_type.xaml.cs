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
    /// Interaction logic for client_type.xaml
    /// </summary>
    public partial class client_types : UserControl
    {
        bool isAdd { get; set; }
        client_type t { get; set; }
        public client_types()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                t = new client_type();
                t.client_type_name = t1.Text;
               
                t.discount = Convert.ToInt32(t5.Text);
                GL.db.client_type.Add(t);

            }
            else
            {
                t.client_type_name = t1.Text;

                t.discount = Convert.ToInt32(t5.Text);
                GL.db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            }
            GL.db.SaveChanges();
            panel.Visibility = Visibility.Hidden;
            GL.main.MenuItem_Click_6(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Visible;
            isAdd = true;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Visible;
            isAdd = false;
            client_type p = ((client_type)table.SelectedValue);
            t = GL.db.client_type.Where(i => i.client_type_id == p.client_type_id).FirstOrDefault();
            t1.Text = t.client_type_name;
            t5.Text = Convert.ToString(t.discount);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GL.db.client_type.Remove((client_type)table.SelectedValue);
            GL.db.SaveChanges();
        }
    }
}
