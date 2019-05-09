using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ClientTypeModel
    { public List<client_type> types { get; set; }
        public ClientTypeModel()
        {
            types = GL.db.client_type.ToList();
        }
    }
}
