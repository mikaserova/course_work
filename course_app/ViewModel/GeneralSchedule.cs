using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace course_app.ViewModel
{
    class GeneralSchedule : INotifyPropertyChanged
    {
        public ObservableCollection<emploee_workSchedule> Shifts { get; set; }
        public List<employee> employees { get; set; }
        //public int del_id { get; set; }
        //private ICommand _deleteCommand;
        //public ICommand DeleteCommand
        //{
        //    get
        //    {
        //        if (_deleteCommand == null)
        //        {
        //            _deleteCommand = new RelayCommand(
        //                param => this.Delete(),
        //                param => this.CanDelete()
        //            );
        //        }
        //        return _deleteCommand;
        //    }
        //}

        //private bool CanDelete()
        //{
        //    return true;
        //}

        //private void Delete()
        //{

        //}

        public GeneralSchedule(ObservableCollection<emploee_workSchedule> sd)
        {
            this.Shifts = sd;
            employees = GL.db.employee.ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
