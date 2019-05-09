using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class AddProvidedModel
    {public List<reservation> reservations { get; set; }
        public List<employee> employees { get; set; }
        public List<additional_service> services { get; set; }
       
        public AddProvidedModel()
        {
           
            reservations = GL.db.reservation.ToList();
            employees = GL.db.employee.ToList();
            services = GL.db.additional_service.ToList();
        }
    }
}
