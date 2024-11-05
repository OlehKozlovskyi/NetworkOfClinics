using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetworkOfPrivateClinics
{
    public class Patient
    {
        public static int PatientID { get; private set; }
        public string Name {  get; private set; }
        public string Surname {  get; private set; }
        private string email;
        public string Email 
        {
            get => email;
            private set 
            {
                string template = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$";
                if (!Regex.IsMatch(email, template))
                    throw new InvalidDataException("Input string isn`t email address");
                email = value;
                
            }
        }
        private string phoneNumber;
        public string PhoneNumber 
        { 
            get => phoneNumber; 
            private set
            {
                string template = @"(?=.*\+[0-9]{3}\s?[0-9]{2}\s?[0-9]{3}\s?[0-9]{4,5}$)";
                if (!Regex.IsMatch(phoneNumber, template))
                    throw new InvalidDataException("Input string isn`t ukrainian phone number");
                phoneNumber = value;
            } 
        }

        public Patient(int id, string name, string surname, string email, string phoneNumber)
        {
            PatientID = id;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }

    }
}
