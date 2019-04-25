using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace course_app
{
    public class emploee_workSchedule : INotifyPropertyChanged
    {
        public DateTime shift_end_time { get; set; }
        public DateTime shift_start_time { get; set; }
        public string employye_first_name { get; set; }
        public string employee_last_name { get; set; }
        public int w_id { get; set; }

        public emploee_workSchedule(DateTime shift_end_time, DateTime shift_start_time, string employye_first_name, string employee_last_name,int id)
        {
            this.shift_end_time = shift_end_time;
            this.shift_start_time = shift_start_time;
            this.employye_first_name = employye_first_name;
            this.employee_last_name = employee_last_name;
            this.w_id = id;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
