using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models.Binding;
using Demo.Web.Models.Binding;
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
            var model = CreateMultipleCheckboxViewModelWithDummyData();
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
            var model = CreateMultipleCheckboxViewModelWithDummyData();
            return View(model);
        }

        [HttpPost]
        public IActionResult MultipleCheckboxViaAjaxPost(MultipleCheckboxViewModel model)
        {
            var aangvinkteIds = model.Checkboxen.Where(c => c.Selected).Select(c => c.ID).ToList();
            return Json($"Jij vinkte {string.Join(',', aangvinkteIds)} aan");
        }

        private MultipleCheckboxViewModel CreateMultipleCheckboxViewModelWithDummyData()
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

        #region DropDown
        public IActionResult DropDownViaFormPost()
        {
            DropDownViewModel model = CreateDropDownViewModelWithDummyData();
            return View(model);
        }

        [HttpPost]
        public IActionResult DropDownViaFormPost(DropDownViewModel model)
        {
            return Json($"Jij selecteerde de value '{model.SelectedValue}'.");
        }

        private DropDownViewModel CreateDropDownViewModelWithDummyData()
        {
            DropDownViewModel model = new DropDownViewModel();
            model.DropDownItems.Add(new SelectListItem()
            {
                Value = "value1",
                Text = "Value One",
                Selected = false
            });
            model.DropDownItems.Add(new SelectListItem()
            {
                Value = "value2",
                Text = "Value Two",
                Selected = false
            });
            model.DropDownItems.Add(new SelectListItem()
            {
                Value = "value3",
                Text = "Value Three",
                Selected = true // <- Deze wordt 'gepreselecteerd'.
            });
            model.DropDownItems.Add(new SelectListItem()
            {
                Value = "value4",
                Text = "Value Four",
                Selected = false
            });
            return model;
        }
        #endregion
    }
}