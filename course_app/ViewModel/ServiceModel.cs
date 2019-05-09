using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ServicesModel
    {
        public List<additional_service> services { get; set; }
        public ServicesModel()
        {
            services = GL.db.additional_service.ToList();
        }

    }
}
