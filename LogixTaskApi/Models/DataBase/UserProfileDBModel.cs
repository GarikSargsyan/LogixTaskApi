using System.ComponentModel.DataAnnotations;

namespace LogixTaskApi.Models.DataBase
{
    public class UserProfileDBModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; } //[minimum three character]
        [Required]
        public string LastName { get; set; } //[minimum three character]
        [Required]
        public string DateOfBirth { get; set; } //[Format 01 / 01 / 2000]
        [Required]
        public string FullName { get; set; } //[should be generate automatic]
        [Required]
        public string Email { get; set; } //[email format]
        [Required]
        public string PhoneNumber { get; set; } //[Format(999) 999 - 9999]
        [Required]
        public string Address { get; set; }//[The address should be change and save in database same as below]
        [Required]
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<ClassUser> ClassUsers { get; set; }

    }
}
