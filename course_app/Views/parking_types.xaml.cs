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
    /// Interaction logic for parking_types.xaml
    /// </summary>
    public partial class parking_types : UserControl
    {
        bool isAdd { get; set; }
        parking_type t { get; set; }
        public parking_types()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isAdd)
            {
                t = new parking_type();
                t.name = t1.Text;
                t.price_per_day = Convert.ToDecimal(t2.Text);
                t.width = Convert.ToDecimal(t3.Text);
                t.length = Convert.ToDecimal(t4.Text);
                t.weight = Convert.ToDecimal(t5.Text);
                GL.db.parking_type.Add(t);

            }
            else
            {
                t.name = t1.Text;
                t.price_per_day = Convert.ToDecimal(t2.Text);
                t.width = Convert.ToDecimal(t3.Text);
                t.length = Convert.ToDecimal(t4.Text);
                t.weight = Convert.ToDecimal(t5.Text);
                GL.db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            }
            GL.db.SaveChanges();
            panel.Visibility = Visibility.Hidden;
            GL.main.parking_t(sender, e);
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
            t = GL.db.parking_type.Where(i => i.parking_type_id == ((parking_type)table.SelectedValue).parking_type_id).FirstOrDefault();
            t1.Text = t.name;
            t2.Text = Convert.ToString(t.price_per_day);
            t3.Text = Convert.ToString(t.width);
            t4.Text = Convert.ToString(t.length);
            t5.Text = Convert.ToString(t.weight);

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GL.db.parking_type.Remove((parking_type)table.SelectedValue);
            GL.db.SaveChanges();
            GL.main.parking_t(sender, e);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            GL.main.MenuItem_Click_4(sender, e);
        }
    }
}
