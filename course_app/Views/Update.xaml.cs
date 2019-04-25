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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
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
        }
    }
}
