using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class AddREservationModel
    {public List<client> clients { get; set; }
        public List<room> rooms { get; set; }
        public List<room_type> types { get; set; }
        public AddREservationModel()
        {
            clients = GL.db.client.ToList();
            rooms = GL.db.room.ToList();
            types = GL.db.room_type.ToList();
        }
    }
}
