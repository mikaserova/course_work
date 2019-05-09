using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : UserControl
    {
        public class C1
        {
            public string Name { get; set; }
            public double Money { get; set; }


        }
        public List<C1> l1;

     
        public Statistics()
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
                    x += (double)s.additional_service.service_cost * s.amount;
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
             Name = "Amortisation",
             Money = x
         };
            C1 d = new C1
            {
                Name = "Recources",
                Money = x / 2 + 20
            };


            l1.Add(a);
         l1.Add(b);
         l1.Add(c);
            l1.Add(d);

            InitializeComponent();
            double total = a.Money + b.Money + c.Money + d.Money;
            t1.Content = "Costs for salaries:     \t" + a.Money.ToString("000000.00 \t") + (a.Money/total*100).ToString("00.00 ")+"%";
            t2.Content = "Costs for services:     \t" + b.Money.ToString("000000.00 \t") + (b.Money / total * 100).ToString("00.00 ") + "%";
            t3.Content = "Costs for amortisation: \t" + c.Money.ToString("000000.00 \t") + (c.Money / total * 100).ToString("00.00 ") + "%";
            t4.Content = "Costs for resources:    \t" + d.Money.ToString("000000.00 \t") + (d.Money / total * 100).ToString("00.00 ") + "%";
            t5.Content = "Total:    \t" + (total).ToString("00.00 ") ;
            this.DataContext = l1;
        }
    }
}
