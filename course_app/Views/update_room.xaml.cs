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
    /// Interaction logic for update_room.xaml
    /// </summary>
    public partial class update_room : Window
    {room temp { get; set; }
        public update_room(room t)
        {
            InitializeComponent();
            t1.Text = t.room_number;
            t2.Text = Convert.ToString(t.room_price);
            t3.SelectedValue = t.room_type;
            t4.Text = t.room_description;
            temp = GL.db.room.Where(r => r.room_id == t.room_id).FirstOrDefault();
            DataContext = new course_app.ViewModel.RoomModel();
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
                room temp1 = new room();
                temp1.room_number = t1.Text;
                temp1.room_price = Convert.ToDecimal(t2.Text);
                temp1.room_type_id = ((room_type)t3.SelectedValue).room_type_id;
                temp1.room_description = t4.Text;
                if (temp1.room_number != temp.room_number || temp1.room_description != temp.room_description || temp1.room_price != temp.room_price || temp1.room_type_id != temp.room_type_id)
                {
                    temp.room_number = temp1.room_number;
                    temp.room_price = temp1.room_price;
                    temp.room_type_id = temp1.room_type_id;
                    temp.room_description = temp1.room_description;
                    GL.db.Entry(temp).State = System.Data.Entity.EntityState.Modified;
                    GL.db.SaveChanges();
                }
                this.Close();
            } catch( Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
