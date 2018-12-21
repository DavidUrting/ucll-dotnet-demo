using System;
using System.Collections.Generic;

namespace Demo.Domain
{
    public class Parent
    {
        public int Id { get; set; }

        public ICollection<Child> Children { get; set; }
    }
}
