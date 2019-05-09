using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ParkingSpotsModel
    {
        public List<parking_spot> parking_s { get; set; }
        public List<parking_type> types { get; set; }
        public List<reservation> reservations { get; set; }
        public List<string> list_fields { get; set; }
        public ParkingSpotsModel()
        {
            parking_s = GL.db.parking_spot.ToList();
            types = GL.db.parking_type.ToList();
            reservations= GL.db.reservation.ToList();
            list_fields = new List<string>();
            list_fields.Add("Number");
            list_fields.Add("Type");
            list_fields.Add("Reservation");
        }
    }
}
