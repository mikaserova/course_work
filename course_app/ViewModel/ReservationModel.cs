﻿using System;
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
            reservations = GL.db.reservation.ToList();
            

        }
    }
}
