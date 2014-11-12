namespace TapestryWorld.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Vote
    {
        [Key]
        public int Id { get; set; }

        public string VotedById { get; set; }

        [Required]
        public virtual User VotedBy { get; set; }

        public int StitchedTapestryId { get; set; }

        [Required]
        public virtual StitchedTapestry StitchedTapestry { get; set; }
    }
}
