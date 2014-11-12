namespace TapestryWorld.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public virtual User Author { get; set; }

        public int StitchedTapestryId { get; set; }

        [Required]
        public virtual StitchedTapestry StitchedTapestry { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
