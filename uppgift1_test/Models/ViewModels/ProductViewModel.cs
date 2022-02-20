namespace AssignmentWebApp.Models.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<ProductModel> Product { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }


    }
}
