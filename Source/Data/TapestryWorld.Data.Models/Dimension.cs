namespace TapestryWorld.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Dimension 
    {
        [Key]
        public int Id { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
