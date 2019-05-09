using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class PositionModel
    { public List<employee_position> positions { get; set; }
        public PositionModel()
        {
            this.positions = GL.db.employee_position.ToList();
        }
    }
}
