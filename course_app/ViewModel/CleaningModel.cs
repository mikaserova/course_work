using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class CleaningModel
    {
        public List<cleaning_schedule> cleanings { get; set; }
        public List<room> rooms { get; set; }
        public List<employee> employees { get; set; }
        public List<employee> employees1 { get; set; }
        public CleaningModel()
        {
            cleanings = GL.db.cleaning_schedule.ToList();
            rooms= GL.db.room.ToList();
            employees= GL.db.employee.ToList();
            employees1 = GL.db.employee.Where(i => i.employee_position.position_name == "Maid").ToList();
        }
    }
}
