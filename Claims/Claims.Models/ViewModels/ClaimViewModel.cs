using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Models.ViewModels
{
    public class ClaimViewModel
    {
        public ClaimViewModel()
        {
            AgeDays = (DateTime.Now - ClaimDate).Days;
        }
        public string UCR { get; set; }
        public int CompanyId { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }

        public bool Closed { get; set; }
        public int ClaimTypeId { get; set; }
        public int AgeDays { get; private  set; }
        public ClaimTypeViewModel ClaimType { get; set; }
        public CompanyViewModel Company { get; set; }
    }
}
