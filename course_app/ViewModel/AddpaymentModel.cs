using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class AddpaymentModel
    {public List<reservation> reservations { get; set; }
       public  List<payment_type> types { get; set; }
        public AddpaymentModel()
        {
            reservations = GL.db.reservation.ToList();
            types = GL.db.payment_type.ToList();
        }
    }
}
