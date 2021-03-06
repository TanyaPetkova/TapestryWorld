﻿namespace TapestryWorld.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Tapestry 
    {
        public Tapestry()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string DesignerName { get; set; }

        public decimal Price { get; set; }

        [DefaultValue("false")]
        public bool InStock { get; set; }

        public StitchType StitchType { get; set; }

        public int? ItemsInStock { get; set; }

        public int SoldItems { get; set; }

        public int? DimensionId { get; set; }

        public virtual Dimension Dimension { get; set; }

        public int ImageId { get; set; } 

        public virtual Image Image { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
