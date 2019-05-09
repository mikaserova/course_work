using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class CostStatModel
    {public class C1
        {
           public  string Name { get; set; }
            public double Money { get; set; }
       

        }
        public List<C1> l1;
       
        /*public CostStatModel()
        {
            l1 = new List<C1>();
            double x = 0;
            int month = DateTime.Today.Month;
            List<employee> employees = GL.db.employee.ToList();
            foreach (employee me in employees)
            {
                List<working_schedule> shifts = GL.db.working_schedule.Where(t => t.employee_id == me.employee_id && t.shift_start_time.Month == month).ToList();
                double sum = 0;
                foreach (working_schedule w in shifts)
                {
                    TimeSpan dif = w.shift_end_time - w.shift_start_time;
                    sum += dif.TotalHours;
                }
                x += sum * (double)me.wage;
            }
            C1 a = new C1
            {
                Name = "Salaries",
                Money = x
            };
            x = 0;
            List<reservation> res = GL.db.reservation.Where(i => i.check_in_date.Month == month).ToList();
            foreach (reservation ad in res)
            {
                var ad_serv = ad.service_request.ToList();
                foreach(service_request s in ad_serv)
                {
                    x += (double)s.additional_service.service_cost;
                }
            }
            C1 b = new C1
            {
                Name = "Service costs",
                Money = x
            };
            x = 0;
           
            foreach (reservation ad in res)
            {
                x += (double)ad.room.room_price * 0.1;
            }
            C1 c = new C1
            {
                Name = "Room amortisation",
                Money = x
            };

            l1.Add(a);
            l1.Add(b);
            l1.Add(c);
        }
        */
    }
      
    }

