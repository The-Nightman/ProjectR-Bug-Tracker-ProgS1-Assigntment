using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectR.Entities
{
    [Table("Issues")]
    public class Issue
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Severity { get; set; }
        public required string Status { get; set; }
        public required DateTime LastUpdated { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Issue> Issues { get; set; } = [];
        public List<Media> Media { get; set; } = [];
    }
}
