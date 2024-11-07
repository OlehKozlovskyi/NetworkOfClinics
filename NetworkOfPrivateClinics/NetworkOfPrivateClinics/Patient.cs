using System.Text.RegularExpressions;
using NetworkOfPrivateClinics.Exceptions;

namespace NetworkOfPrivateClinics
{
    public class Patient
    {
        public static int PatientID { get; private set; }
        public string Name {  get; private set; }
        public string Surname {  get; private set; }
        private string _email;

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

        private string _contactNumber;
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

        public Patient(string name, string surname, string email, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            ContactNumber = phoneNumber;
        }

        public void ChangePhoneNumber(string phoneNumber) => ContactNumber = phoneNumber;

        public void ChangeEmailAddress(string email) => Email = email;
    }
}
