using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ClientDataModel
    {
        public List<reservation> res_list { get; set; }
       
        public List<client_type> types { get; set; }
        public ClientDataModel(client c)
        {
            res_list = GL.db.reservation.Where(i => i.client_id == c.client_id).ToList();
            
            types = GL.db.client_type.ToList();



        }
    }
}
