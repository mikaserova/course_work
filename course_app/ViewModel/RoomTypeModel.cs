using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class RoomTypeModel
    { 
        public List<room_type> types { get; set; }
        public RoomTypeModel()
        {
            types = GL.db.room_type.ToList();
        }
    }
}
