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
using System.Windows.Shapes;

namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for add_payment.xaml
    /// </summary>
    public partial class add_payment : Window
    {
        bool t = false;
        reservation re;
        payment payment;
        bool upd = false;
        public add_payment()
        {
            InitializeComponent();
            DataContext = new ViewModel.AddpaymentModel();
            pay_time.IsEnabled = false;
            pay_time.Text = "Time is chosen automaticaly";
            pay_time.Value = DateTime.Now;
        }
        public add_payment(reservation r)
        {
            t = true;
            re = r;
            DataContext = new ViewModel.AddpaymentModel();
            InitializeComponent();
            t1.SelectedValue = r;
         
            pay_time.IsEnabled = false;
            pay_time.Text = "Time is chosen automaticaly";
            pay_time.Value = DateTime.Now;
        }
        public add_payment(payment pay)
        {
            upd = true;
            InitializeComponent();
            DataContext = new ViewModel.AddpaymentModel();
            t1.SelectedValue = pay.reservation;
            payment = pay;
            pay_time.IsEnabled = false;
            t2.Text = Convert.ToString(pay.payment_sum);
            t3.SelectedValue = pay.payment_type;
            pay_time.Value = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!upd)
            {
                pay_time.Value = DateTime.Now;
                payment p = new payment();
                p.reservation_id = ((reservation)t1.SelectedValue).reservation_id;
                p.payment_date = DateTime.Now;
                p.payment_sum = Convert.ToDecimal(t2.Text);
                p.payment_type_id = ((payment_type)t3.SelectedValue).payment_type_id;
                GL.db.payment.Add(p);
            }
            else
            {
                payment p = GL.db.payment.Where(i => i.payment_id == payment.payment_id).FirstOrDefault();
                p.reservation_id = ((reservation)t1.SelectedValue).reservation_id;
                p.payment_date = DateTime.Now;
                p.payment_sum = Convert.ToDecimal(t2.Text);
                p.payment_type_id = ((payment_type)t3.SelectedValue).payment_type_id;
                GL.db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            GL.db.SaveChanges();
            if (t) { GL.main.DataContext = new ViewModel.currPaymentModel(re); }
            else
            {
                GL.main.MenuItem_Click_91(sender, e);
            }
            this.Close();

        }
    }
}
