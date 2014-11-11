namespace TapestryWorld.Data.Models
{
    using System.Collections.Generic;

    public class StitchedTapestry
    {
        public StitchedTapestry()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public byte[] ProductImage { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
