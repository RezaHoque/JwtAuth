using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuth.Models
{
    public class SupplierInfo
    {
        public string Id { get; set; }
        public string ProfileName { get; set; }
        public ApplicationUser UserInfo { get; set; }
        public bool Status { get; set; }

    }
}
