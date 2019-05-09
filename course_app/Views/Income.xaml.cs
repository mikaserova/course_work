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
    /// Interaction logic for Income.xaml
    /// </summary>
    public partial class Income : UserControl
    {
        public class C1
        {
            public string Name { get; set; }
            public double Money { get; set; }
            public double Possible { get; set; }


        }
        public double t;
        public List<C1> l1;
        public Income()
        {
            InitializeComponent();
            double x = 0;
            double x1 = 0;
            double x2 = 0;
            int month = DateTime.Today.Month;
            List<reservation> res = GL.db.reservation.Where(i => i.check_in_date.Month == month).ToList();
            foreach (reservation ad in res)
            {
                x = 0;
                var ad_serv = ad.service_request.ToList();
                foreach (service_request s in ad_serv)
                {
                    x += (double)s.additional_service.service_price * s.amount;
                    
                }
                x1 += x * (1 - ad.client.client_type.discount / 100.0);
                x2 += x;
            }
            C1 a = new C1
            {
                Name = "Services",
                Money = x1,
                Possible = x2

            };
            x2 = 0;
            x1 = 0;
            foreach (reservation ad in res)
            {
                x = 0;
                TimeSpan dif = ad.check_out_date - ad.check_in_date;
                List<parking_spot> parking = ad.parking_spot.ToList();
                foreach (parking_spot s in parking)
                {
                    x += (double)s.parking_type.price_per_day * dif.Days;

                }
                x1 += x * (1 - ad.client.client_type.discount / 100.0);
                x2 += x;
            }
            C1 b = new C1
            {
                Name = "Parking",
                Money = x1,
                Possible = x2

            };
            x2 = 0;
            x1 = 0;
            foreach (reservation ad in res)
            {
                TimeSpan dif = ad.check_out_date - ad.check_in_date;
              
                
                    x2 += (double)ad.room.room_price* dif.Days;

                
                x1 += (double)ad.room.room_price * dif.Days * (1 - ad.client.client_type.discount / 100.0);
            }
            C1 c = new C1
            {
                Name = "Rooms",
                Money = x1,
                Possible = x2

            };
            l1 = new List<C1>();
            l1.Add(a);
            l1.Add(b);
            l1.Add(c);
            double total = a.Money + b.Money + c.Money ;
            t = total;
            t1.Content = "Profit from services:     \t" + a.Money.ToString("000000.00 \t") + (a.Money / total * 100).ToString("00.00 ") + "%";
            t2.Content = "Profit from parking:     \t" + b.Money.ToString("000000.00 \t") + (b.Money / total * 100).ToString("00.00 ") + "%";
            t3.Content = "Profit from rooms:       \t" + c.Money.ToString("000000.00 \t") + (c.Money / total * 100).ToString("00.00 ") + "%";
           
            t4.Content = "Total:    \t" + (total).ToString("00.00 ");

            double total1 = a.Possible + b.Possible + c.Possible;
            t5.Content = "Without Client discount";
            t6.Content = "Profit from services:     \t" + a.Possible.ToString("000000.00 \t") + (a.Possible / total1 * 100).ToString("00.00 ") + "%";
            t7.Content = "Profit from parking:     \t" + b.Possible.ToString("000000.00 \t") + (b.Possible / total1 * 100).ToString("00.00 ") + "%";
            t8.Content = "Profit from rooms:       \t" + c.Possible.ToString("000000.00 \t") + (c.Possible / total1 * 100).ToString("00.00 ") + "%";

            t9.Content = "Total:    \t" + (total1).ToString("00.00 ");
            t10.Content = "Lost:    \t" + (total1-total).ToString("00.00 ");
            this.DataContext = l1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            t11.Content= "Tax:    \t" + (t*Convert.ToDouble(pers.Text)/100).ToString("00.00 ");
        }
    }
}
