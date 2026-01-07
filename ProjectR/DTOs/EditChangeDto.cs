namespace ProjectR.DTOs
{
    public class EditChangeDto
    {
        public int Id { get; set; }
        public string ChangeHash { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
