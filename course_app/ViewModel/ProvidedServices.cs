using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ProvidedServices
    { public List<service_request> services { get; set; }
        public ProvidedServices(reservation r)
        {
            services = r.service_request.ToList();
        }
    }
}
