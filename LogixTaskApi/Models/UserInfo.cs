using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Numerics;

namespace LogixTaskApi.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } //[minimum three character]
        public string LastName { get; set; } //[minimum three character]
        public DateTime DateOfBirth { get; set; } //[Format 01 / 01 / 2000]
        public string FullName { get; set; } //[should be generate automatic]
        public string Email { get; set; } //[email format]
        public string PhoneNumber { get; set; } //[Format(999) 999 - 9999]
        public string Address { get; set; }//[The address should be change and save in database same as below]
        public string Role { get; set; }


    }
}
