﻿
namespace NetworkOfPrivateClinics.Exceptions
{
    public class InvalidPatientPhoneNumberException:Exception
    {
        public InvalidPatientPhoneNumberException(string phoneNumber) 
            : base(String.Format($"Invalid Patient Phone number: {phoneNumber}")) { }
    }
}
