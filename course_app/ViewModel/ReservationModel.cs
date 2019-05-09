using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ReservationModel
    { public List<string> list_fields { get; set; }
        public List<reservation> reservations { get; set; }
        public ReservationModel()
        {
            list_fields = new List<string>();
            list_fields.Add("Check in date");
            list_fields.Add("Check out date");
            list_fields.Add("Check in date and time");
            list_fields.Add("Check out date and time");
            list_fields.Add("Check in and check out dates");
            list_fields.Add("Reservation number");
            list_fields.Add("Client");
            list_fields.Add("Room");
            list_fields.Add("Employee");
            reservations = GL.db.reservation.ToList();
            

        }
    }
}
