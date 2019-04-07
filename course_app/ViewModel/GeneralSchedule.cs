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
    class GeneralSchedule : INotifyPropertyChanged
    {
        public List<working_schedule> Shifts { get; set; }

        public GeneralSchedule(List<working_schedule> s)
        {
            this.Shifts = s;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
