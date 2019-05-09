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
    /// Interaction logic for update_room_type.xaml
    /// </summary>
    public partial class update_room_type : Window
    { room_type l { get; set; }
        public update_room_type( room_type t)
        {
            InitializeComponent();
            t1.Text = t.room_type_name;
            t4.Text = t.room_type_description;
            l = GL.db.room_type.Where(i => i.room_type_id == t.room_type_id).FirstOrDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (l.room_type_name == t1.Text && l.room_type_description == t4.Text) this.Close();
            else
            {
                
                l.room_type_description = t4.Text;
                l.room_type_name = t1.Text;
                GL.db.Entry(l).State = System.Data.Entity.EntityState.Modified;
                GL.db.SaveChanges();
                this.Close();
                
            }
        }
    }
}
