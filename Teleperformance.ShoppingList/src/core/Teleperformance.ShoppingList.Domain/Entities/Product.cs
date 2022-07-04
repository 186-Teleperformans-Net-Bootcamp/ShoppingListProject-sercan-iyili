﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Domain.Common;
using Teleperformance.Bootcamp.Domain.Enums;

namespace Teleperformance.Bootcamp.Domain.Entities
{
   
    public class Product : IBaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool? IsBuy { get; set; }
        public int? Quantity { get; set; }
        public Unit? Unit { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;

        //nav props
        public string ShoppingListId { get; set; }
        public virtual ShoppingList ShoppingList { get; set; }

    }
}
