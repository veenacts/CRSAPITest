using System;
using System.Collections.Generic;

namespace CRSAPI.Models
{
    public partial class AssociateRole
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int RoleId { get; set; }
    }
}
