﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLNG.PEAR.Services.Requests.Menu
{
    public class GetSiteMenusRequest
    {
        public int? ParentId { get; set; }
        public bool IncludeChildren { get; set; }
    }
}