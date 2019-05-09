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
using System.Data.SqlClient;


namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public class DataObject
        {
            public List<employee_position> positions { get; set; }
            public DataObject()
            {
                positions = GL.db.employee_position.ToList();
            }
        }
            
        public Add()
        {
            InitializeComponent();
            DataContext = new DataObject();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (login.Text.Length < 4)
                {
                    throw new ArgumentException("Please enter login with the length more than 4 characters!");
                }
                if (pass_box1.Password != pass_box2.Password)
                {
                    throw new ArgumentException("Passwords in 1st and 2nd line are different!");
                }
                int does_exist = GL.db.credential.Where(i => i.username == login.Text).Count();
                if (does_exist != 0)
                {
                    throw new ArgumentException("User with such login already exists");
                }

                employee p = new employee
                {
                    employye_first_name = f_n.Text,
                    employye_middle_name = m_n.Text,
                    employee_last_name = l_n.Text,
                    employee_phone_number = ph_n.Text,
                    employee_passport_serial_number = pas_n.Text,
                    employee_email = e_n.Text,
                    position_id = ((employee_position)pos_n.SelectedValue).position_id,
                    tax_payer_id = t_n.Text,
                    wage = (decimal)Convert.ToDouble(w_n.Text)
                };

                credential cr = new credential
                {
                    employee_id = p.employee_id,
                    username = login.Text,
                    password = pass_box2.Password
                };

                try {
                    GL.db.employee.Add(p);
                    GL.db.SaveChanges();
                    GL.db.credential.Add(cr);
                    GL.main.Emp_add_Click(GL.main, e);
                }
                catch(SqlException)
                {
                    throw new ArgumentException("Unexpected error trying to write to the database");
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
