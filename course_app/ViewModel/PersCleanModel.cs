using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class PersCleanModel
    { public List<cleaning_schedule> cl_shifts { get; set; }
        public PersCleanModel()
        { credential c = GL.db.credential.Where(i => i.credential_id == GL.cred_id).FirstOrDefault();
            cl_shifts = GL.db.cleaning_schedule.Where(i => i.employee_id == c.employee_id).ToList();
        }
    }
}
