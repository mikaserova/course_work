using course_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace course_app
{
    
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static int permission_level;
        //public static hotel_newEntities db = new hotel_newEntities();
        //int cred_id;
        public MainWindow(int id)
        {
            InitializeComponent();
            GL.cred_id = id;

            GL.permission_level = SetPLevel();
            if (GL.permission_level < 3)
            {
                general_schedule.Visibility = Visibility.Collapsed;
            }
          
        }
        private int SetPLevel()
        {
            var emp = GL.db.credential.Where(c => c.credential_id == GL.cred_id).FirstOrDefault();
            var t = GL.db.employee.Where(w => w.employee_id == emp.employee_id).FirstOrDefault();
            int pos_id = t.employee_position.position_id;
            if (pos_id <= 3) return pos_id;// maid-level1//security-level 2//admin-level 3
            else if (pos_id == 4) return 6;//db admin-level 6
            else return pos_id - 1;//manager-level 4// hr-level 5


        }
        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
           
            var emp = GL.db.credential.Where(c => c.credential_id == GL.cred_id).FirstOrDefault();
            var shifts = GL.db.working_schedule.Where(w => w.employee_id == emp.employee_id).OrderBy(w => w.shift_start_time).ToList();
            
            DataContext = new ScheduleModel(shifts);
        }

        private void General_schedule_Click(object sender, RoutedEventArgs e)
        {
            
            var s = GL.db.working_schedule.Join(GL.db.employee, eid => eid.employee_id, wid => wid.employee_id,
                (eid, wid) => new
                {
                    eid.shift_end_time,
                    eid.shift_start_time,
                    wid.employye_first_name,
                    wid.employee_last_name,
                    eid.working_schedule_id
                }).ToList();

            ObservableCollection<emploee_workSchedule> ew = new ObservableCollection<emploee_workSchedule>();
            foreach(var i in s)
            {
                emploee_workSchedule temp = new emploee_workSchedule(i.shift_end_time, i.shift_start_time, i.employye_first_name, i.employee_last_name,i.working_schedule_id);
                ew.Add(temp);
            }

            DataContext = new GeneralSchedule(ew);
        }

        private void Ent_log_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EntranceTable();
        }

        private void Emp_add_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeModel();
        }
    }
}
