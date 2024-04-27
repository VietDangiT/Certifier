namespace Certificate.Domain.Entities
{
    public class UserInfo : BaseEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string? issueDate { get; set; }
        public string? publishId { get; set; }
        public byte[]? pdfFile { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
