using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class AppViewModel
    {
        private int cred_id;
        private hotel_newEntities db;
        

        public AppViewModel(int id)
        {
            this.cred_id = id;
        }

    }
}
