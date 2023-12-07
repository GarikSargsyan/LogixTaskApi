namespace LogixTaskApi.Models.DataBase
{
    public class ClassUser
    {
        public Guid UserId { get; set; }
        public UserProfileDBModel User { get; set; }
        public int ClassId { get; set; }
        public ClassDbModel Class { get; set; }
    }
}
