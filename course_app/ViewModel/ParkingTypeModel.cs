using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ParkingTypeModel
    {
        public List<parking_type> types { get; set; }
        public ParkingTypeModel()
        {
            types = GL.db.parking_type.ToList();
        }
    }
}
