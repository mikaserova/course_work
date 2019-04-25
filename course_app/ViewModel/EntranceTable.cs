using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;

namespace course_app.ViewModel
{
    class EntranceTable: INotifyPropertyChanged
    {
        public List<entrance_log> entrances { get; set; }
        public List<string> Status { get; set; }
        public List<parking_spot> spots { get; set; }
        public EntranceTable()
        {
            this.entrances = GL.db.entrance_log.ToList();
            this.spots = GL.db.parking_spot.ToList();
            this.Status = new List<string>();
            this.Status.Add("in");
            this.Status.Add("out");
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
