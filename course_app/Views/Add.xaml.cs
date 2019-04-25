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
            employee p = new employee();
            p.employye_first_name = f_n.Text;
            p.employye_middle_name = m_n.Text;
            p.employee_last_name = l_n.Text;
            p.employee_phone_number = ph_n.Text;
            p.employee_passport_serial_number = pas_n.Text;
            p.employee_email = e_n.Text;
            employee_position pos = (employee_position)pos_n.SelectedValue;
            p.position_id = pos.position_id;
            p.tax_payer_id = t_n.Text;
            p.wage = (decimal)Convert.ToDouble(w_n.Text);
            GL.db.employee.Add(p);
            GL.db.SaveChanges();
            this.Close();

        }
    }
}
