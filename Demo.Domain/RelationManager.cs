using Microsoft.EntityFrameworkCore;
using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Demo.Domain
{
    public class RelationManager
    {
        public Parent GetParent(int id, bool includeChildren = true)
        {
            using (var ctx = new DemoDbContext())
            {
                var parent = ctx.ParentSet.Where(p => p.Id == id);
                if (includeChildren)
                {
                    parent = parent.Include(p => p.Children);
                }
                return parent.FirstOrDefault();
            }
        }

        public void AddParent(Parent parent)
        {
            using (var ctx = new DemoDbContext())
            {
                ctx.Add(parent);
                foreach (var child in parent.Children)
                {
                    ctx.Add(child);
                }
                ctx.SaveChanges();
            }
        }
    }
}
