using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class PaymentMOdel
    { public List<payment> payments { get; set; }
        public PaymentMOdel()
        {
            payments = GL.db.payment.ToList();
        }
    }
}
