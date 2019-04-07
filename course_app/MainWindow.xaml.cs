using course_app.ViewModel;
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

namespace course_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        hotel_newEntities db = new hotel_newEntities();
        int cred_id;
        public MainWindow(int id)
        {
            InitializeComponent();
            cred_id = id;
          
        }

        private void Schedule_Click(object sender, RoutedEventArgs e)
        {
           
            var emp = db.credential.Where(c => c.credential_id == cred_id).FirstOrDefault();
            var shifts = db.working_schedule.Where(w => w.employee_id == emp.employee_id).OrderBy(w => w.shift_start_time).ToList();
            
            DataContext = new ScheduleModel(shifts);
        }

        private void General_schedule_Click(object sender, RoutedEventArgs e)
        {
            var s = db.working_schedule.ToList();
            DataContext = new GeneralSchedule(s);
        }
    }
}
