namespace TapestryWorld.Data.Models
{
    using System.Collections.Generic;

    public class StitchedTapestry
    {
        public StitchedTapestry()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public byte[] ProductImage { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

    }
}
