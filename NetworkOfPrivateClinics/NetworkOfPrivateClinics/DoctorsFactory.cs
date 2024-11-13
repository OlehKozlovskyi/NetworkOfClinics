using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class DoctorsFactory
    {
        private readonly int id;
        private readonly string name;
        private readonly string surname;
        private readonly DoctorType type;
        private readonly decimal costOfPermission;
        private readonly Dictionary<int, DailyRoutine> appointments;

        public DoctorsFactory(int id, string name, string surname, DoctorType type, decimal costOfPermission, AppointmentsFactory appointmentsFactory) 
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.type = type;
            this.costOfPermission = costOfPermission;
            appointments = appointmentsFactory.GetMonthlyAppointment();
        }

        public Doctor GetDoctor()
        {
            return new Doctor(id, name, surname, type, costOfPermission, appointments);
        }
    }
}
