namespace MyRestaurant.Model
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }
        public string LoginEmployee { get; set; }
        public string PasswordEmployee { get; set; }
        public int IdPosition { get; set; }
        public string NamePosition { get; set; }
        public Employee(int idEmployee, string fullName, string dateOfBirth, string passport,
            string phoneNumber, string loginEmployee, string passwordEmployee, int idPosition, string namePosition)
        {
            IdEmployee = idEmployee;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Passport = passport;
            PhoneNumber = phoneNumber;
            LoginEmployee = loginEmployee;
            PasswordEmployee = passwordEmployee;
            IdPosition = idPosition;
            NamePosition = namePosition;
        }
    }
}
