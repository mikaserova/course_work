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
using course_app.ViewModel;
namespace course_app.Views
{
    /// <summary>
    /// Interaction logic for add_room.xaml
    /// </summary>
    public partial class add_room : Window
    {
        public add_room()
        {
            InitializeComponent();
            DataContext = new RoomModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (t1.Text.Length < 1)
                {
                    MessageBox.Show("Please enter correct room number");
                    return;
                }
                if (t2.Text.Length < 1)
                {
                    MessageBox.Show("Please enter correct room price");
                    return;
                }
                if (t3.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose room type");
                    return;
                }
                room r = new room();
                r.room_number = t1.Text;
                r.room_price = Convert.ToDecimal(t2.Text);
                r.room_type_id = ((room_type)t3.SelectedValue).room_type_id;
                r.room_description = t4.Text;
                GL.db.room.Add(r);
                GL.db.SaveChanges();
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Please enter correct values");
                return;
            }
        }
    }
}
