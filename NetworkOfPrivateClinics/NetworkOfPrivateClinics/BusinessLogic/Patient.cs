using System.Text.RegularExpressions;
using CsvHelper.Configuration.Attributes;
using NetworkOfPrivateClinics.Exceptions;
using Newtonsoft.Json;

namespace NetworkOfPrivateClinics.BusinessLogic
{
    public class Patient
    {
        private string _email;
        private string _contactNumber;

        public Patient(int id, string name, string surname, string email, string phoneNumber)
        {
            PatientID = id;
            PatientName = name;
            PatientSurname = surname;
            Email = email;
            ContactNumber = phoneNumber;
        }

        public Patient() 
        {
            PatientID = 0;
            PatientName = "null";
            PatientSurname = "null";
            Email = "example@gmail.com";
            ContactNumber = "+380 63 123 4567";
        }

        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string Email
        {
            get => _email;
            set
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
            set
            {
                string template = @"(?=.*\+[0-9]{3}\s?[0-9]{2}\s?[0-9]{3}\s?[0-9]{4,5}$)";
                if (!Regex.IsMatch(value, template))
                    throw new InvalidPatientPhoneNumberException(value);
                _contactNumber = value;
            }
        }
    }
}
