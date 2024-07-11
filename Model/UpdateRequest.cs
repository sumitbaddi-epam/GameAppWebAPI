namespace GameAppWebAPI.Model
{
    using System.ComponentModel.DataAnnotations;
    using GameAppWebAPI.Entities;
    public record struct UpdateRequest
    {
        /// <summary>
        /// The unique key represented by a GUID value
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the game
        /// </summary>
        public string Title { get; set; }        

        /// <summary>
        /// 
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// 
        /// </summary>        
        public string Description { get; set; }     
        
        /// <summary>
        /// 
        /// </summary>
        public int Price { get; set; }   
        
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset ReleaseDate { get; set; }       

        /// <summary>
        /// The avaialble stock quantity
        /// </summary>
        public int StockQuantity { get; set; }
    }
}
