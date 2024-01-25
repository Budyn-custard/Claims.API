using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Claims.Data.Entities
{
    public class Claim
    {
        [Key]
        [MaxLength(20)]
        public string UCR { get; set; }

        public int CompanyId { get; set; }

        public DateTime ClaimDate { get; set; }

        public DateTime LossDate { get; set; }

        [MaxLength(100)]
        public string AssuredName { get; set; }

        public decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }
        public int ClaimTypeId { get; set; }
        public ClaimType ClaimType { get; set; }
        public Company Company { get; set; }
    }
}
