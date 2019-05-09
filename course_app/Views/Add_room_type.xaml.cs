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
    /// Interaction logic for Add_room_type.xaml
    /// </summary>
    public partial class Add_room_type : Window
    {
        public Add_room_type()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            room_type t = new room_type();
            t.room_type_name = t1.Text;
            t.room_type_description = t4.Text;
            GL.db.room_type.Add(t);
            GL.db.SaveChanges();
            this.Close();
        }
    }
}
