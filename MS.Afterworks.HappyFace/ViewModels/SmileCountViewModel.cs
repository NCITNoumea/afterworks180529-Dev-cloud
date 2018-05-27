﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MS.Afterworks.HappyFace.Core.Models;

namespace app.Models
{
    public class SmileCountViewModel
    {
        public Smile Smile { get; set; }

        public int SmileUpCount { get; set; }

        public int SmileDownCount { get; set; }
    }
}
