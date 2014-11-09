namespace TapestryWorld.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TapestryWorld.Data.Common.Models;

    public class Tapestry : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        // TODO: Designer, 

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set;  }
    }
}
