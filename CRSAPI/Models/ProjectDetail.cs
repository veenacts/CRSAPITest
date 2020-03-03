using System;
using System.Collections.Generic;

namespace CRSAPI.Models
{
    public partial class ProjectDetail
    {
        public int AssociateId { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int VerticalId { get; set; }
        public string VerticalName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime ProjectEndDate { get; set; }
    }
}
