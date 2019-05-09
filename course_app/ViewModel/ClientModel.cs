using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ClientModel
    {
        public List<client> clients { get; set; }
        public List<client_type> types { get; set; }
        public List<reservation> res_list { get; set; }
        public List<string> list_fields { get; set; }

      
        public ClientModel()
        {
            clients = GL.db.client.ToList();
            types = GL.db.client_type.ToList();
            list_fields = new List<string>();
            list_fields.Add("First name");
            list_fields.Add("Middle name");
            list_fields.Add("Last name");
            list_fields.Add("Phone");
            list_fields.Add("Email");
            list_fields.Add("Passport");
            list_fields.Add("Type");

        }
    }
}
