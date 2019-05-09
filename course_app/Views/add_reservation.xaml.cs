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
    /// Interaction logic for add_reservation.xaml
    /// </summary>
    public partial class add_reservation : Window
    {
        public class t1
        {
            public List<room> rooms { get; set; }
        }
        DateTime checkin, checkout;
        bool upd;
        reservation cur;

        public add_reservation()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddREservationModel();
            upd = false;
        }
        public add_reservation(reservation r)
        {
            try
            {
                InitializeComponent();
                DataContext = new ViewModel.AddREservationModel();
                f_n.Text = r.reservation_number;
                m_n.Value = r.check_in_date;
                l_n.Value = r.check_out_date;
                client_n.SelectedValue = r.client;
                room_n.SelectedValue = r.room;
                upd = true;
                cur = r;
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_client w = new add_client();
            w.Show();
            this.DataContext= new ViewModel.AddREservationModel();
            //renew this page
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            r_type.Visibility = Visibility.Visible;
            min_price.Visibility = Visibility.Visible;
            max_price.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Visible;
        }

       

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!upd)
            {
                reservation r = new reservation();
                r.check_in_date = (DateTime)m_n.Value;
                r.check_out_date = (DateTime)l_n.Value;
                r.reservation_number = f_n.Text;
                r.client_id = ((client)client_n.SelectedValue).client_id;
                r.room_id = ((room)room_n.SelectedValue).room_id;
                r.employee_id = (int)(GL.db.credential.Where(i => i.credential_id == GL.cred_id).FirstOrDefault()).employee_id;
                GL.db.reservation.Add(r);
            }
            else
            {
                reservation r = GL.db.reservation.Where(i => i.reservation_id == cur.reservation_id).FirstOrDefault();
                r.check_in_date = (DateTime)m_n.Value;
                r.check_out_date = (DateTime)l_n.Value;
                r.reservation_number = f_n.Text;
                r.client_id = ((client)client_n.SelectedValue).client_id;
                r.room_id = ((room)room_n.SelectedValue).room_id;
                r.employee_id = (int)(GL.db.credential.Where(i => i.credential_id == GL.cred_id).FirstOrDefault()).employee_id;
                GL.db.Entry(r).State = System.Data.Entity.EntityState.Modified;

            }
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_8(sender, e);
            this.Close();

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            r_type.Visibility = Visibility.Collapsed;
            min_price.Visibility = Visibility.Collapsed;
            max_price.Visibility = Visibility.Collapsed;
            search.Visibility = Visibility.Collapsed;
            List<room> all = GL.db.room.ToList();
           room_n.DataContext = new t1 { rooms = all };

        }

        private void Search_room(object sender, RoutedEventArgs e)
        {
            decimal min_p, max_p;
            if (min_price.Value != null)
            {
                 min_p = (decimal)min_price.Value;
            }
            else
            {
                min_p = 0;
            }
            if (max_price.Value != null)
            {
                max_p = (decimal)max_price.Value;
            }
            else
            {
                max_p = 1000000;
            }
            if (r_type.SelectedValue != null)
            { room_type t = (room_type)r_type.SelectedValue;

                List<room> roms = GL.db.room.Where(i => i.room_price >= min_p && i.room_price <= max_p && i.room_type_id == t.room_type_id).ToList();
                room_n.DataContext = new t1 { rooms = roms};
            }
            else
            {
                List<room> roms = GL.db.room.Where(i => i.room_price >= min_p && i.room_price <= max_p ).ToList();
                room_n.DataContext = new t1 { rooms = roms};
            }


        }

        private void M_n_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            checkin = (DateTime)m_n.Value;
            if (checkin != null && checkout > checkin)
            {
                List<reservation> reserved = (GL.db.reservation.Where(i => (i.check_in_date >= checkin && i.check_in_date <= checkout) || (i.check_out_date >= checkin && i.check_out_date <= checkout))).ToList();
                List<room> all = GL.db.room.ToList();
                List<room> r = new List<room>();
                foreach(reservation  re in reserved)
                {
                    r.Add(re.room);
                    
                }
       
               
                    List<room> roms = all.Except(r).ToList();
                room_n.DataContext = new t1 { rooms = roms };

               
                
            }else if(checkout <= checkin)
            {
                room_n.DataContext = null;
            }
        }

        private void L_n_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            checkout = (DateTime)l_n.Value;
            if (checkout != null && checkout > checkin)
            {
                List<reservation> reserved = (GL.db.reservation.Where(i => (i.check_in_date >= checkin && i.check_in_date <= checkout) || (i.check_out_date >= checkin && i.check_out_date <= checkout))).ToList();
                List<room> all = GL.db.room.ToList();
                List<room> r = new List<room>();
                foreach (reservation re in reserved)
                {
                    r.Add(re.room);
                }
                List<room> roms = all.Except(r).ToList();
                room_n.DataContext = new t1 { rooms = roms };


            }
            else if (checkout <= checkin)
            {
                room_n.DataContext = null;
            }
        }
    }
}
