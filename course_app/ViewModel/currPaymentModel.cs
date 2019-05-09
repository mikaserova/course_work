using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class currPaymentModel
    {
        public List<payment> payments { get; set; }
        public double sum {get;set;}
        public double paid { get; set; }
        public double left { get; set; }
        public reservation res { get; set; }
        public currPaymentModel(reservation r)
        {
            res = r;
            payments = r.payment.ToList();
            double s = 0;
            List<service_request> sr = r.service_request.ToList();
            foreach( service_request i in sr)
            {
                s += (double)i.additional_service.service_price * i.amount;
            }
            TimeSpan x = r.check_out_date - r.check_in_date;
            s += (double)r.room.room_price * x.Days;
            List<parking_spot> ps= r.parking_spot.ToList();
            foreach( parking_spot i in ps)
            {
                s+=(double)i.parking_type.price_per_day* x.Days;
            }
            s *= (1 - r.client.client_type.discount / 100.0);
            sum = s;
            paid = 0;
            foreach(payment i in payments)
            {
                paid += (double)i.payment_sum;
            }
            left = sum - paid;
        }
    }
}
