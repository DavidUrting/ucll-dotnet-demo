using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Web.Models.Binding
{
    public class DropDownViewModel
    {
        public List<SelectListItem> DropDownItems { get; set; } = new List<SelectListItem>();
        public string SelectedValue { get; set; }
    }
}
