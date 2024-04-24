namespace Certificate.Domain.Entities
{
    public class Course : BaseEntity
    {
        public int Id {  get; set; }
        public string courseName { get; set; }
        public string groupId { get; set; }
        public string headSign {  get; set; }
        public string mentorSign {  get; set; }
        public ICollection<UserInfo> userInfoes { get; set; }
    }
}
