using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBook.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }
        [Required]
        [Key]
        [Column(Order = 2)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The field Author must be a string with a maximun lenght of 50"), MinLength(5)]
        public string Author { get; set; }
        [Required]
        [Range(100,10000 ,ErrorMessage = "The field PagesNumber must be between 100 and 1000")]
        public int PagesNumber { get; set; }
   
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$",ErrorMessage = "Ingrese formato de fecha válido")]
        public string PublicationDate { get; set; }
        public string Content { get; set; }
        
        [Display(Name="Price")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "PriceConfirm")]
        [System.ComponentModel.DataAnnotations.Compare("Price")]
        public decimal PriceConfirm { get; set; }

    }
}