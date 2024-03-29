﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string Postcode { get; set; }

        public string Country { get; set; }

        public bool Active { get; set; }
        public bool HasActiveClaims { get; set; }

        public DateTime InsuranceEndDate { get; set; }
    }
}
