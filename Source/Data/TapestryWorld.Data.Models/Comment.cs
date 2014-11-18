namespace TapestryWorld.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TapestryWorld.Data.Common.Models;

    public class Comment : IAuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int StitchedTapestryId { get; set; }

        public virtual StitchedTapestry StitchedTapestry { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
