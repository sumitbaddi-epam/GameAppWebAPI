using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameAppWebAPI.Entities
{
    [Table("Games")]
    public class Game
    {
        /// <summary>
        /// The key identifier of the game title represented by a GUID value
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The tile of the game only accepts a maximum of 200 characters
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// The game genre value
        /// </summary>
        [Required]
        public string Genre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        [RegularExpression("[^0-9]*$", ErrorMessage = "Price must be numeric")]
        public int Price { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Released Date")]
        public DateTimeOffset ReleaseDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DisplayName("Stock Quantity")]
        [RegularExpression("[^0-9]*$", ErrorMessage = "Stock Quantity must be numeric")]
        public int StockQuantity { get; set; }
    }
}
