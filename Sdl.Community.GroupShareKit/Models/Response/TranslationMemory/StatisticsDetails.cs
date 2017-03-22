﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdl.Community.GroupShareKit.Models.Response.TranslationMemory
{
    public class StatisticsDetails
    {
        /// <summary>
        /// Gets or sets recompute date
        /// </summary>
        public DateTime? RecomputeDate { get; set; }
        /// <summary>
        /// Gets or sets duration
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// Gets or sets total tus
        /// </summary>
        public int TotalTus { get; set; }
    }
}
