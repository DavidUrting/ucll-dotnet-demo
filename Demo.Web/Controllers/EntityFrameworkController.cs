﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain;
using Demo.Domain.Models;
using Demo.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class EntityFrameworkController : Controller
    {
        public IActionResult Include()
        {
            CreateInitialDataIfNecessary();

            RelationManager mgr = new RelationManager();
            Parent p = mgr.GetParent(1, true);

            return View(p);
        }

        private void CreateInitialDataIfNecessary()
        {
            RelationManager mgr = new RelationManager();
            if (mgr.GetParent(1, false) == null)
            {
                mgr.AddParent(new Parent()
                {
                    Children = new List<Child>
                    {
                        new Child() { ParentID = 1 },
                        new Child() { ParentID = 1 }, 
                        new Child() { ParentID = 1 }
                    }
                });
            }
        }

        public IActionResult IdentityColumn()
        {
            KeyManager mgr = new KeyManager();
            KeyViewModel model = new KeyViewModel()
            {
                KeySuggestionForNoAutoGeneratedKey = mgr.GetMaxKey() + 1
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult IdentityColumn(KeyViewModel model)
        {
            // model bevat nu de suggestie (of een key die door de gebruiker zelf werd gekozen).
            KeyManager mgr = new KeyManager();

            AutoGeneratedKey agkEntity = new AutoGeneratedKey()
            {
                Id = 0 // eigenlijk overbodig, want default value van een int is 0
            };
            NoAutoGeneratedKey nagkEntity = new NoAutoGeneratedKey()
            {
                Id = model.KeySuggestionForNoAutoGeneratedKey
            };

            mgr.AddAutoGeneratedKey(agkEntity);
            mgr.AddNoAutoGeneratedKey(nagkEntity);

            return Json($"Created entities. Auto generated key: {agkEntity.Id}, No auto generated key: {nagkEntity.Id}.");
        }
    }
}