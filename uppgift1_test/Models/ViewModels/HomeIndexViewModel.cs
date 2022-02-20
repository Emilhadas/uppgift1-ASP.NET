namespace AssignmentWebApp.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public ProductModel ProductForm { get; set; }

        public IEnumerable<ProductModel> Product { get; set; }
        public CategoryModel CategoryForm { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }


    }
}
