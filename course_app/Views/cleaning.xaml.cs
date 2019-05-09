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
    /// Interaction logic for cleaning.xaml
    /// </summary>
    public partial class cleaning : UserControl
    {
        bool c;
        cleaning_schedule temp;
        public cleaning()
        {
            InitializeComponent();
            c = false;
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            GL.db.cleaning_schedule.Remove((cleaning_schedule)shift_table.SelectedValue);
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_5(sender, e);
        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            cleaning_schedule c = new cleaning_schedule();
            c.cleaning_start_time = Convert.ToDateTime(s_dt.Text);
            c.cleaning_end_time = Convert.ToDateTime(e_dt.Text);
            c.room_id = ((room)room_list.SelectedValue).room_id;
            c.employee_id = ((employee)emp_list.SelectedValue).employee_id;
            GL.db.cleaning_schedule.Add(c);
            GL.db.SaveChanges();
            GL.main.MenuItem_Click_5(sender, e);
        }

        private void Upd_button_Click(object sender, RoutedEventArgs e)
        {
            if (c)
            {
                temp.cleaning_start_time = Convert.ToDateTime(upd_s_dt.Text);
                temp.cleaning_end_time = Convert.ToDateTime(upd_e_dt.Text);
                temp.employee_id = ((employee)upd_emp_list.SelectedValue).employee_id;
                temp.room_id = ((room)upd_room_list.SelectedValue).room_id;
                GL.db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                GL.db.SaveChanges();
                GL.main.MenuItem_Click_5(sender, e);
            }
            else
            {
                temp = GL.db.cleaning_schedule.Where(i => i.cleaning_schedule_id == ((cleaning_schedule)shift_table.SelectedValue).cleaning_schedule_id).FirstOrDefault();
                upd_room_list.SelectedValue = ((cleaning_schedule)shift_table.SelectedValue).room;
                upd_emp_list.SelectedValue = ((cleaning_schedule)shift_table.SelectedValue).employee;
                upd_s_dt.Text = Convert.ToString(((cleaning_schedule)shift_table.SelectedValue).cleaning_start_time);
                upd_e_dt.Text = Convert.ToString(((cleaning_schedule)shift_table.SelectedValue).cleaning_end_time);
                c = !c;
            }
        }
    }
}
