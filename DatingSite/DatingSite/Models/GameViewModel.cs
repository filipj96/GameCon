﻿using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class GameViewModel
    {
        [Display(Name = "Game")]
        public string Name { get; set; }
    }
}