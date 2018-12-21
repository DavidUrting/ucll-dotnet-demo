using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Demo.Models.Kendo;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class KendoController : Controller
    {
        public IActionResult Grid()
        {
            return View();
        }

        public IActionResult Grid_Read(DataSourceRequest request)
        {
            List<GridViewModel> model = new List<GridViewModel>();
            model.Add(new GridViewModel()
            {
                ID = 1,
                Name = "Test",
                Description = "Dit is een test"
            });
            return Json(model.ToDataSourceResult(request));
        }
    }
}