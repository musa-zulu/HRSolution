﻿using System;

namespace HRSolution.Data.Models
{
    public class Language : BaseEntity
    {
        public Guid LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
