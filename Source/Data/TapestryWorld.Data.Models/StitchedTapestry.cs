namespace TapestryWorld.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StitchedTapestry
    {
        public StitchedTapestry()
        {
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        public int ImageId { get; set; }

        public virtual Image Image { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
