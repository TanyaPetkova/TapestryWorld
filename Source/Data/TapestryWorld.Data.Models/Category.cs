namespace TapestryWorld.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Category 
    {
        public Category()
        {
            this.Tapestries = new HashSet<Tapestry>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Tapestry> Tapestries { get; set; }
    }
}
