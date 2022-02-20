namespace AssignmentWebApi.model
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }


    }
}
