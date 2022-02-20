using AssignmentWebApi.model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentWebApi.Entities
{
    public class ProductEntity
    {


        public ProductEntity(string name, string description, decimal price, string categoryName, int subCategoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryName = categoryName;
            SubCategoryId = subCategoryId;
        }


        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategoryEntity SubCategory { get; set; }

    }
}
