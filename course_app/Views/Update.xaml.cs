using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        employee pew;
        bool cred;
        public class DataObject
        {
            public List<employee_position> positions { get; set; }
            public DataObject()
            {
                positions = GL.db.employee_position.ToList();
            }
        }

        public Update(employee person)
        {
            InitializeComponent();
            cred = false;
            pew = person;
            DataContext = new DataObject();
            f_n.Text = person.employye_first_name;
            m_n.Text = person.employye_middle_name;
            l_n.Text = person.employee_last_name;
            ph_n.Text = person.employee_phone_number;
            pas_n.Text = person.employee_passport_serial_number;
            t_n.Text = person.tax_payer_id;
            w_n.Text = Convert.ToString(person.wage);
            e_n.Text = person.employee_email;
            //to do
            employee_position pos = GL.db.employee_position.Where(t => t.position_id == person.position_id).FirstOrDefault();
            pos_n.SelectedValue = pos;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* GL.db.employee.Remove(pew);
             employee n = new employee();
             n.employee_last_name = l_n.Text;
             n.employee_passport_serial_number = pas_n.Text;
             n.employee_phone_number = ph_n.Text;
            // n.employee_position = (employee_position)pos_n.SelectedValue;
             n.employye_first_name = f_n.Text;
             n.employye_middle_name = m_n.Text;
             n.position_id = ((employee_position)pos_n.SelectedValue).position_id;
             GL.db.employee.Add(n);
             pew = n;
             if (cred)
             {
                 credential del = GL.db.credential.Where(t => t.employee_id == pew.employee_id).FirstOrDefault();
                 if(del!=null)GL.db.credential.Remove(del);
                 credential rep = new credential();
                 rep.employee_id = pew.employee_id;
                 rep.username = login.Text;
                 rep.password = pass_box1.Password;
                 GL.db.credential.Add(rep);
             }
             GL.db.SaveChanges();
             GL.main.Emp_add_Click(GL.main, e);
             this.Close();*/
            try
            {
                var n = GL.db.employee.Where(t => t.employee_id == pew.employee_id).FirstOrDefault();
                n.employee_last_name = l_n.Text;
                n.employee_passport_serial_number = pas_n.Text;
                n.employee_phone_number = ph_n.Text;
                n.employye_first_name = f_n.Text;
                n.tax_payer_id = t_n.Text;
                n.employye_middle_name = m_n.Text;
                n.position_id = ((employee_position)pos_n.SelectedValue).position_id;
                 GL.db.Entry(n).State = System.Data.Entity.EntityState.Modified;
                if (cred)
                {
                    credential del = GL.db.credential.Where(t => t.employee_id == pew.employee_id).FirstOrDefault();
                    if (del == null)
                    {
                        credential rep = new credential();
                        rep.employee_id = pew.employee_id;
                        rep.username = login.Text;
                        rep.password = pass_box1.Password;
                        GL.db.credential.Add(rep);
                    }
                    else
                    {
                        del.password= pass_box1.Password;
                        del.username= login.Text;
                        GL.db.Entry(del).State = System.Data.Entity.EntityState.Modified;
                    }
                }
                GL.db.SaveChanges();
                this.Close();
              
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            credential c = GL.db.credential.Where(t => t.employee_id == pew.employee_id).FirstOrDefault();
            
            if (c==null||current_pass_box.Password == c.password)
            {
                cred = true;
                label_login.Visibility = Visibility.Visible;
                label_p1.Visibility = Visibility.Visible;
                label_p2.Visibility = Visibility.Visible;
                pass_box1.Visibility = Visibility.Visible;
                pass_box2.Visibility = Visibility.Visible;
                login.Visibility = Visibility.Visible;

            }
        }
    }
}
