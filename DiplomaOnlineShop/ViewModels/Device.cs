﻿using System.Collections.Generic;
using DiplomaOnlineShop.Models;

namespace DiplomaOnlineShop.ViewsModels
{
    public class Device 
    {
       public List<Telephones> telephones { get; set; }
       public List<Products> tablets { get; set; }
    }
}