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
    /// Interaction logic for update_parking_spot.xaml
    /// </summary>
    public partial class update_parking_spot : Window
    { parking_spot s { get; set; }

        public update_parking_spot(parking_spot p )
        {
            InitializeComponent();
            DataContext = new course_app.ViewModel.ParkingSpotsModel();
            t1.Text = p.number;
            t2.SelectedValue = p.parking_type;
            t3.SelectedValue = p.reservation;

            s = p;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            parking_spot temp = GL.db.parking_spot.Where(t => t.parking_spot_id == s.parking_spot_id).FirstOrDefault();
            
                temp.number = t1.Text;
                temp.type_id = ((parking_type)t2.SelectedValue).parking_type_id;
                temp.reservation_id = ((reservation)t3.SelectedValue).reservation_id;
                GL.db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                GL.db.SaveChanges();
            
            GL.main.MenuItem_Click_4(sender, e);
            this.Close();
        }
    }
}
