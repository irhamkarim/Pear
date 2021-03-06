﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLNG.PEAR.Services.Responses.RoleGroup
{
    public class GetRoleGroupResponse : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
        public string Code { get; set; }
        public Level Level { get; set; } 
    }
}
