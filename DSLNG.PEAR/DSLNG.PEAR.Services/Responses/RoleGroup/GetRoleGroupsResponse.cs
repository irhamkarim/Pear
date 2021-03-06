﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSLNG.PEAR.Services.Responses.RoleGroup
{
    public class GetRoleGroupsResponse : BaseResponse
    {
        public IList<RoleGroup> RoleGroups { get; set; }
        public class RoleGroup
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
            public string Remark { get; set; }
            public bool IsActive { get; set; }
            public Level Level { get; set; }
            public string LevelName { get; set; }
        }
    }
}
