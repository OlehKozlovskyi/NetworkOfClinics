
namespace NetworkOfPrivateClinics.Exceptions
{
    public class InvalidPatientEmailException:Exception
    {
        public InvalidPatientEmailException() { }
        public InvalidPatientEmailException(string email) 
            : base(String.Format($"Invalid Patient E-mail: {email}")) { }
    }
}
