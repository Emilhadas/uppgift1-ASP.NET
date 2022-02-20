using System.ComponentModel.DataAnnotations;

namespace AssignmentWebApi.model.Entities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {

        }        
        public CategoryEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public CategoryEntity(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
