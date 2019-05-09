using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_app.ViewModel
{
    class ProfileModel
    { public employee me { get; set; }
        public double salary { get; set; }
        public string number_shifts { get; set; }
        public ProfileModel()
        {
            credential cr = GL.db.credential.Where(t => t.credential_id == GL.cred_id).FirstOrDefault();
            me = GL.db.employee.Where(t => t.employee_id == cr.employee_id).FirstOrDefault();
            CountSalary();
        }
        private void CountSalary()
        {
            int month = DateTime.Today.Month;
            List<working_schedule> shifts = GL.db.working_schedule.Where(t => t.employee_id == me.employee_id&&t.shift_start_time.Day==month).ToList();
            double sum = 0;
            foreach( working_schedule w in shifts)
            {
                TimeSpan dif = w.shift_end_time - w.shift_start_time;
                sum += dif.TotalHours;
            }
            sum *= (double)me.wage;
            number_shifts ="( "+Convert.ToString(shifts.Count)+" shifts"+" this month"+" )";
            salary = sum;
            
            
        }
    }
}
