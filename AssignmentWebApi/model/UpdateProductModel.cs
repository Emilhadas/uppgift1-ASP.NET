﻿namespace AssignmentWebApi.model
{
    public class UpdateProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
    }
}
