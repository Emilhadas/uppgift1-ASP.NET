using AssignmentWebApp.Models;
using AssignmentWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using System.Diagnostics;
using uppgift1_test.Models.ViewModels;

namespace AssignmentWebApp.Controllers
{
    public class testarController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var viewModel = new ProductViewModel();
            viewModel.Product = new List<ProductModel>();
            using (var client = new HttpClient())

                viewModel.Product = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7109/api/product");
            return View(viewModel);
        }
    }
}
