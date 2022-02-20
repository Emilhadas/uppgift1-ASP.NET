using AssignmentWebApp.Models;
using AssignmentWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var viewModel = new CategoryViewModel();
            viewModel.Category = new List<CategoryModel>();
            using (var client = new HttpClient())

                viewModel.Category = await client.GetFromJsonAsync<IEnumerable<CategoryModel>>("https://localhost:7109/api/category");
            return View(viewModel );


        }




    }
}
