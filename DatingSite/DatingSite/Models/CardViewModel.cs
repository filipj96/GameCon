﻿using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingSite.Models
{
    public class CardViewModel
    {
        public User User { get; set; }

        public List<Game> Games { get; set; }

        public List<Genre> Genres { get; set; }

        public List<Platform> Platforms { get; set; }

        public Nullable<int> Score { get; set; }

        public string ScoreDescription { get; set; }
    }
}