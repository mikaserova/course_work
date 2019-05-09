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
    public partial class UpdatePosition : Window
    {
        employee_position l { get; set; }

        public UpdatePosition(employee_position t)
        {
            InitializeComponent();
            l11.Text = t.position_name;
            l212.Text = t.wage_lower_bound.ToString();
            l222.Text = t.wage_upper_bound.ToString();
            desc.Text = t.position_description;
            l = GL.db.employee_position.Where(i => i.position_id == t.position_id).FirstOrDefault();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (l11.Text.Length < 2)
                {
                    MessageBox.Show("Please enter correct position name");
                    return;
                }
                if (l212.Text.Length < 1 || l222.Text.Length < 1)
                {
                    MessageBox.Show("Please enter correct wage bounds");
                    return;
                }

                l.position_name = l11.Text;
                l.wage_lower_bound = Convert.ToDecimal(l212.Text);
                l.wage_upper_bound = Convert.ToDecimal(l222.Text);
                l.position_description = desc.Text;
                GL.db.Entry(l).State = System.Data.Entity.EntityState.Modified;
                GL.db.SaveChanges();

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter correct values");
            }
        }
    }
}
