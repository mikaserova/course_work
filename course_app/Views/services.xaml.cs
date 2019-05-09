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
    /// Interaction logic for services.xaml
    /// </summary>
    public partial class services : UserControl
    { bool isAdd { get; set; }
        additional_service t;
        public services()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Visible;
            isAdd = true;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!isAdd)
                {
                    t.service_name = t1.Text;
                    t.service_price = Convert.ToDecimal(t2.Text);
                    t.service_cost = Convert.ToDecimal(t3.Text);
                    GL.db.Entry(t).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    additional_service t = new additional_service();
                    t.service_name = t1.Text;
                    t.service_price = Convert.ToDecimal(t2.Text);
                    t.service_cost = Convert.ToDecimal(t3.Text);
                    GL.db.additional_service.Add(t);
                }
                GL.db.SaveChanges();
                panel.Visibility = Visibility.Hidden;
                GL.main.MenuItem_Click_3(sender, e);
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            panel.Visibility = Visibility.Visible;
            isAdd = false;
            t = GL.db.additional_service.Where(i => i.additional_service_id == ((additional_service)table.SelectedValue).additional_service_id).FirstOrDefault();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                GL.db.additional_service.Remove((additional_service)table.SelectedValue);
                GL.db.SaveChanges();
                GL.main.MenuItem_Click_3(sender, e);
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
