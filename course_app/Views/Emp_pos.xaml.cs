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
    /// Interaction logic for Emp_pos.xaml
    /// </summary>
    public partial class Emp_pos : UserControl
    {
        public Emp_pos()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //add
            Add_position w = new Add_position();
            w.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UpdatePosition w = new UpdatePosition((employee_position)p_table.SelectedValue);
            w.ShowDialog();
            GL.main.MenuItem_Click(sender, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                employee_position p = (employee_position)p_table.SelectedValue;
                GL.db.employee_position.Remove(p);
                GL.db.SaveChanges();
                GL.main.MenuItem_Click(sender, e);
            }catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
