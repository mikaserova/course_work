using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    public class ScheduleModel : INotifyPropertyChanged
    {
        //private IOrderedQueryable<working_schedule> shifts;
        public List<working_schedule> shifts { get; set; }

        public ScheduleModel(List<working_schedule> shifts1)
        {
            this.shifts = shifts1;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
