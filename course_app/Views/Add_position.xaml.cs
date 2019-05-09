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
    /// Interaction logic for Add_position.xaml
    /// </summary>
    public partial class Add_position : Window
    {
        public Add_position()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (l11.Text.StartsWith(" ")) { l11.Text.Remove(0, 1); }
                if( (l11.Text.Length < 2)||(l212.Text.Length<1)||(l222.Text.Length<1)||(desc.Text.Length<1))
                    throw new ArgumentNullException("You should fill all fields!");
                employee_position position = new employee_position();
                position.position_name = l11.Text;
                position.wage_lower_bound = Convert.ToDecimal(l212.Text);
                position.wage_upper_bound = Convert.ToDecimal(l222.Text);
                position.position_description = desc.Text;
                if (position.wage_upper_bound < position.wage_lower_bound) throw new ArgumentException("Second value of wage must be greater than first!");
                GL.db.employee_position.Add(position);
                GL.db.SaveChanges();
                this.Close();
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
