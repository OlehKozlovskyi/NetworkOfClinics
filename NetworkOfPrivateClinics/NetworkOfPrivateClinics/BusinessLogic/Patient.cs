using System.Text.RegularExpressions;
using CsvHelper.Configuration.Attributes;
using NetworkOfPrivateClinics.Exceptions;

namespace NetworkOfPrivateClinics.BisinessLogic
{
    public class Patient
    {
        private string _email;
        private string _contactNumber;

        public Patient(int id, string name, string surname, string email, string phoneNumber)
        {
            PatientID = id;
            Name = name;
            Surname = surname;
            Email = email;
            ContactNumber = phoneNumber;
        }

        public int PatientID { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email
        {
            get => _email;
            private set
            {
                string template = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$";
                if (!Regex.IsMatch(value, template))
                    throw new InvalidPatientEmailException(value);
                _email = value;

            }
        }

        public string ContactNumber
        {
            get => _contactNumber;
            private set
            {
                string template = @"(?=.*\+[0-9]{3}\s?[0-9]{2}\s?[0-9]{3}\s?[0-9]{4,5}$)";
                if (!Regex.IsMatch(value, template))
                    throw new InvalidPatientPhoneNumberException(value);
                _contactNumber = value;
            }
        }
    }
}
