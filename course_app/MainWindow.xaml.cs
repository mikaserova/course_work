using course_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
            GL.cred_id = id;
            
            GL.permission_level = SetPLevel();
            InitializeComponent();
            if (GL.permission_level < 3)
            {
                HR.Visibility = Visibility.Collapsed;
                Reservation.Visibility= Visibility.Collapsed;
                Resources.Visibility= Visibility.Collapsed;
                Statistics.Visibility = Visibility.Collapsed;
                if (GL.permission_level == 2)
                {
                    Cleaning.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Parking.Visibility = Visibility.Collapsed;
                }
            }else if(GL.permission_level==3)
            {
                HR.Visibility = Visibility.Collapsed;
                Cleaning.Visibility = Visibility.Collapsed;
                Parking.Visibility = Visibility.Collapsed;
                Statistics.Visibility = Visibility.Collapsed;
            }
            else if (GL.permission_level == 4)
            {
                HR.Visibility = Visibility.Collapsed;
                Cleaning.Visibility = Visibility.Collapsed;
            }
            else if (GL.permission_level == 5)
            {
                Resources.Visibility = Visibility.Collapsed;
                Parking.Visibility = Visibility.Collapsed;
                Reservation.Visibility = Visibility.Collapsed;
                Statistics.Visibility= Visibility.Collapsed;

            }
               
           

        }
        public void MWClosing(object sender, RoutedEventArgs e)
        {
            GL.login_Window.Close();
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
        public void Schedule_Click(object sender, RoutedEventArgs e)
        {
           
            var emp = GL.db.credential.Where(c => c.credential_id == GL.cred_id).FirstOrDefault();
            var shifts = GL.db.working_schedule.Where(w => w.employee_id == emp.employee_id).OrderBy(w => w.shift_start_time).ToList();
            
            DataContext = new ScheduleModel(shifts);
        }

        public void General_schedule_Click(object sender, RoutedEventArgs e)
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

        public void Ent_log_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EntranceTable();
        }

        public void Emp_add_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new EmployeeModel();
        }
        public void BTN_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new RoomTypeModel();
        }

        public void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PositionModel();
        }

        public void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new ProfileModel();
        }

        public void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DataContext = new RoomModel();
        }

        public void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            DataContext = new ServicesModel();
        }

        public void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            DataContext = new ParkingSpotsModel();
        }

        public void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            DataContext = new CleaningModel();
        }

        public void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientModel();
        }
        public void client_t(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientTypeModel();
        }
        public void parking_t(object sender, RoutedEventArgs e)
        {
            DataContext = new ParkingTypeModel();
        }

        public void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            DataContext = new EntranceTable();
        }

        public void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            DataContext = new ReservationModel();
        }

        public void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            course_app.Views.add_reservation w = new Views.add_reservation();
            w.Show();
        }

        public void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            DataContext = new CostStatModel();
        }

        public void MenuItem_Click_91(object sender, RoutedEventArgs e)
        {
            DataContext = new PaymentMOdel();
        }

        private void About_Handler(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            DataContext = new IncomeModel();
        }
    }
}
