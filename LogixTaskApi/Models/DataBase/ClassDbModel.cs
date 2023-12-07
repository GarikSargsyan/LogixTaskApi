using System.ComponentModel.DataAnnotations;

namespace LogixTaskApi.Models.DataBase
{
    public class ClassDbModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public ICollection<ClassUser> ClassUsers { get; set; }
    }
}
