using AssignmentWebApp.Models;
using AssignmentWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using System.Diagnostics;
using uppgift1_test.Models.ViewModels;

namespace AssignmentWebApp.Controllers
{


    public class ProductController : Controller
    {
        public async Task<IActionResult> Index(string input)
        {
            var viewModel = new ProductViewModel();
            viewModel.Product = new List<ProductModel>();

            using (var client = new HttpClient())
            {
                if (input == null)
                    viewModel.Product = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7109/api/product");
                else
                    viewModel.Product = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7109/api/Product?subcategory=" + $"{input}");
                    //viewModel.Product = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7109/api/product&subcategoryId=" + $"{input}");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? productId)
        {
            var viewModel = new ProductDetailsModel();
            viewModel.Product = new ProductModel();

            if (productId == null || productId == 0)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                viewModel.Product = await client.GetFromJsonAsync<ProductModel>($"https://localhost:7109/api/product/{productId}");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new HomeIndexViewModel();
            viewModel.Product = new List<ProductModel>();
            viewModel.ProductForm = new ProductModel();

            using (var client = new HttpClient())
            {
                viewModel.Product = await client.GetFromJsonAsync<IEnumerable<ProductModel>>("https://localhost:7109/api/product/");
            }

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(HomeIndexViewModel model)
        {
            using (var client = new HttpClient())
            {
                var result = await client.PostAsJsonAsync("https://localhost:7109/api/product", model.ProductForm);

            }
            return RedirectToAction("Index", "Product");
        }




    }


        
    }