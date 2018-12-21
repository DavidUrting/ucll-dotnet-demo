using System.Collections.Generic;

namespace Demo.Models.Binding
{
    public class MultipleCheckboxViewModel
    {
        public class Checkbox
        {
            public bool Selected { get; set; }
            public string ID { get; set; }
            public string Text { get; set; }
        }

        public List<Checkbox> Checkboxen { get; set; } = new List<Checkbox>();
    }
}
