namespace AssignmentWebApp.Models.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<CategoryModel> Category { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
