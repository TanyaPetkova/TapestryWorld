namespace TapestryWorld.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StitchedTapestry
    {
        public StitchedTapestry()
        {
            this.Users = new HashSet<User>();
            this.Comments = new HashSet<Comment>();
            this.Votes = new HashSet<Vote>();
        }

        [Key]
        public int Id { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
