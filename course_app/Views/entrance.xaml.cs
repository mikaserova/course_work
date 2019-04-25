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
    /// Interaction logic for entrance.xaml
    /// </summary>
    public partial class entrance : UserControl
    {
        public entrance()
        {
            InitializeComponent();
            log_time_in.IsEnabled = false;
            log_time_in.Text = "Time is chosen automaticaly";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            entrance_log temp = new entrance_log();
            log_time_in.Value = DateTime.Now;
            temp.log_time =(DateTime) log_time_in.Value;
            temp.status = (string)stat.SelectedValue;
            parking_spot ps = (parking_spot)spot.SelectedValue;
            temp.parking_spot_id = ps.parking_spot_id;
            GL.db.entrance_log.Add(temp);
            GL.db.SaveChanges();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            entrance_log t=(entrance_log )ent_table.SelectedValue;
            GL.db.entrance_log.Remove(t);
            GL.db.SaveChanges();
        }
    }
}
