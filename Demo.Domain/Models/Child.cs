using System;

namespace Demo.Domain
{
    public class Child
    {
        public int Id { get; set; }

        public Parent Parent { get; set; }
        public int ParentID { get; set; }
    }
}
