﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DSLNG.PEAR.Web.ViewModels.Pillar
{
    public class CreatePillarViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public int Order { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
    }
}