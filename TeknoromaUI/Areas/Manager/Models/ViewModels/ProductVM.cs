﻿using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeknoromaUI.Areas.Manager.Models.ViewModels
{
    public class ProductVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
