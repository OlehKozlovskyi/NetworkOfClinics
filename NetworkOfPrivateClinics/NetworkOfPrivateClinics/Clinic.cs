namespace NetworkOfPrivateClinics
{
    public class Clinic
    {
        public static int ClinicID { get; private set; }
        public string Name { get; private set; }
        public string Location {  get; private set; }
        public List<Doctor> Doctors { get; private set; }

        public Clinic(string name, string location, List<Doctor> doctors)
        {
            ClinicID += 1;
            Name = name;
            Location = location;
            Doctors = doctors;
        }

        public void AddDoctor(Doctor doctor) => Doctors.Add(doctor);
    }
}
