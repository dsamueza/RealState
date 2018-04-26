using System;
using System.Collections.Generic;

namespace Realstate.Models.BaseDatos
{
    public partial class AspNetUserRoles
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public AspNetRoles Role { get; set; }
        public AspNetUsers User { get; set; }
    }
}
