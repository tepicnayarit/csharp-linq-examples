﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCourse
{
    internal class Game
    {
        public required string Title { get; set; }
        public  string? Genre { get; set; }
        public int RealeaseYear { get; set; } 
        public double Rating { get; set; }
        public int Price { get; set; }

    }
}
