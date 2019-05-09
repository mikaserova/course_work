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
    /// Interaction logic for general_schedule.xaml
    /// </summary>
    public partial class general_schedule : UserControl
    {
        private bool c;
        working_schedule temp = new working_schedule();
        public general_schedule()
        {
            InitializeComponent();
            c = true;
            upd_emp_list.IsEditable = false;
            upd_s_dt.IsEnabled = false;
            upd_e_dt.IsEnabled = false;
        }
        void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Edit_panel.Visibility = Visibility.Visible;
        }

        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                //int loc_ind = Convert.ToInt32(delete_field.Text);
                emploee_workSchedule t = (emploee_workSchedule)shift_table.SelectedValue;
                working_schedule temp = GL.db.working_schedule.Where(w => w.working_schedule_id == t.w_id).FirstOrDefault();
                GL.db.working_schedule.Remove(temp);
                GL.db.SaveChanges();
                // shift_table.Items.Remove(t);
                GL.main.General_schedule_Click(GL.main, e);


            }
            catch (Exception a)
            {
                MessageBox.Show("Wrong number of row"+a.Message);
            }

        }

        private void Add_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                working_schedule temp = new working_schedule();
                temp.shift_start_time = (DateTime)s_dt.Value;
                temp.shift_end_time = (DateTime)e_dt.Value;
                if (temp.shift_end_time <= temp.shift_start_time) throw new ArgumentException("End date and time must be greater than the start one");
                employee t = (employee)emp_list.SelectedValue;
                temp.employee_id = t.employee_id;
                GL.db.working_schedule.Add(temp);
                GL.db.SaveChanges();
                GL.main.General_schedule_Click(GL.main,e);
               // shift_table.Items.Add()
            }
            catch (ArgumentException a)
            {
                MessageBox.Show(a.Message);
            }
            catch(Exception a)
            {
                MessageBox.Show(a.Message);
            }
            
        }

        private void Upd_button_Click(object sender, RoutedEventArgs e)
        {
            
            if (c)
            {
                upd_button.Content = "Update";
                upd_emp_list.IsEnabled = true;
                upd_s_dt.IsEnabled = true;
                upd_e_dt.IsEnabled = true;
                upd_f1.IsEnabled = false;
                c = !c;
                int loc_ind = Convert.ToInt32(upd_f1.Text);
                emploee_workSchedule t = (emploee_workSchedule)shift_table.Items[loc_ind - 1];
                 temp = GL.db.working_schedule.Where(w => w.working_schedule_id == t.w_id).FirstOrDefault();
                employee emp = GL.db.employee.Where(w => w.employee_id == temp.employee_id).FirstOrDefault();
                upd_s_dt.Value = temp.shift_start_time;
                upd_e_dt.Value = temp.shift_end_time;
                int ind=-1;
                for (int i = 0; i < upd_emp_list.Items.Count; i++)
                { if (upd_emp_list.Items[i].Equals(emp)) { ind = i; break; }
                
                }
                upd_emp_list.SelectedValue = emp;


            }
            else
            {
                c = !c;
                upd_button.Content = "Choose item";

                upd_emp_list.IsEnabled = false;
                upd_s_dt.IsEnabled = false;
                upd_e_dt.IsEnabled = false;
                upd_f1.IsEnabled = true;
                working_schedule temp1 = new working_schedule();
                temp1.shift_start_time = (System.DateTime)upd_s_dt.Value;
                temp1.shift_end_time = (System.DateTime)upd_e_dt.Value;
                employee new_emp = (employee)upd_emp_list.SelectedValue;

                temp1.employee_id = new_emp.employee_id;
                GL.db.working_schedule.Add(temp1);
                GL.db.working_schedule.Remove(temp);
                GL.db.SaveChanges();
                GL.main.General_schedule_Click(GL.main, e);
            }

        }
    }
}
