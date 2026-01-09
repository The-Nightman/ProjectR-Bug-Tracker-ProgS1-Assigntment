namespace ProjectR.DTOs
{
    public class EditChangeDto
    {
        public required int Id { get; set; }
        public required string ChangeHash { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
