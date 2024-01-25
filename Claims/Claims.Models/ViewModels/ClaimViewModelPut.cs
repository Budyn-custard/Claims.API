using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Models.ViewModels
{
    public class ClaimViewModelPut
    {
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }
        public int ClaimTypeId { get; set; }
    }
}
