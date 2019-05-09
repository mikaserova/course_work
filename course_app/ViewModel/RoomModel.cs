using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class RoomModel
    {
        public List<room> rooms{get;set;}
        public List<room_type> types { get; set; }
        public RoomModel()
        {
            rooms = GL.db.room.ToList();
            types = GL.db.room_type.ToList();
            
        }
    }
}
