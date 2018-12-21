using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Binding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo.Controllers
{
    public class BindingController : Controller
    {
        #region Multiple checkbox
        [HttpGet]
        public IActionResult MultipleCheckboxViaFormPost()
        {
            var model = CreateViewModelWithDummyData();
            return View(model);
        }

        [HttpPost]
        public IActionResult MultipleCheckboxViaFormPost(MultipleCheckboxViewModel model)
        {
            var aangvinkteIds = model.Checkboxen.Where(c => c.Selected).Select(c => c.ID).ToList();
            return Json($"Jij vinkte {string.Join(',',aangvinkteIds)} aan");
        }

        public IActionResult MultipleCheckboxViaAjaxPost()
        {
            var model = CreateViewModelWithDummyData();
            return View(model);
        }

        [HttpPost]
        public IActionResult MultipleCheckboxViaAjaxPost(MultipleCheckboxViewModel model)
        {
            var aangvinkteIds = model.Checkboxen.Where(c => c.Selected).Select(c => c.ID).ToList();
            return Json($"Jij vinkte {string.Join(',', aangvinkteIds)} aan");
        }

        private MultipleCheckboxViewModel CreateViewModelWithDummyData()
        {
            MultipleCheckboxViewModel model = new MultipleCheckboxViewModel();
            foreach (var id in new string[] { "A", "B", "C", "D", "E" })
            {
                model.Checkboxen.Add(new MultipleCheckboxViewModel.Checkbox()
                {
                    Selected = false,
                    ID = id,
                    Text = $"Hier wat uitleg over {id}"
                });
            }
            return model;
        }
        #endregion
    }
}