using System.ComponentModel.DataAnnotations;

namespace GameAppWebAPI.Model
{
    public record struct CreateRequest
    {
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required] 
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTimeOffset ReleaseDate { get; set; }

        [Required]
        public int StockQuantity { get; set; }
    }
}
