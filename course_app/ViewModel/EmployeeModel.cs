using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class EmployeeModel
    {
        public List<employee> employee { get; set; }
       
       public EmployeeModel()
        {
            this.employee = GL.db.employee.ToList();
        

        }
    }
}
